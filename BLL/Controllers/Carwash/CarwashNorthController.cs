using Exceptions;
using UI.Screen;
using DAL;
namespace BLL.Controllers
{
  public class CarwashController : ICarwashController
  {
    private readonly ICarwashRepository _carwashRepository;
    private readonly ITicketRepository _ticketRepository;

    public CarwashController (ICarwashRepository carwashRepository, ITicketRepository ticketRepository) {
        _carwashRepository = carwashRepository;
        _ticketRepository = ticketRepository;
    }

    public void Select(){
      Ticket latest = _ticketRepository.GetTicketByID(LatestID.latestId);
      Text.ClearTop();
      Console.WriteLine(@"Tryk 1 - 3 for at vælge vask:
      1 - Economy
      2 - Basis
      3 - Premium
      Tryk ESC for at ANNULLERE");

        bool optionChosen = false;
        while(!optionChosen)
        {
          string wash = SmallestQueue();
          var key = Console.ReadKey(true);
          switch (key.Key)
          {
            case ConsoleKey.D1:
              List<string> economyTimes = SetStartAndEndTime(30, wash);
              _carwashRepository.InsertToWashQueue(wash, latest.LicensePlate, 1, 50m, economyTimes[0], economyTimes[1]);
              optionChosen = !optionChosen;
              break;
            case ConsoleKey.D2:
              List<string> basisTimes = SetStartAndEndTime(60, wash);
              _carwashRepository.InsertToWashQueue(wash, latest.LicensePlate, 2, 75m, basisTimes[0], basisTimes[1]);
              optionChosen = !optionChosen;
              break;
            case ConsoleKey.D3:
            List<string> premiumTimes = SetStartAndEndTime(90, wash);
            _carwashRepository.InsertToWashQueue(wash, latest.LicensePlate, 3, 100m, premiumTimes[0], premiumTimes[1]);
            optionChosen = !optionChosen;
            break;
            case ConsoleKey.Escape:
            throw new ReturnToMainException();
            default:
            break;
          }
        }
    }

    private string SmallestQueue () {
      var north = _carwashRepository.GetCarwashQueue("North");
      var south = _carwashRepository.GetCarwashQueue("South");
      if(north.Count > south.Count) {
        return "South";
      } else {
        return "North";
      }
    }

    public bool CanChooseCarwash(){
      Ticket latestTicket = _ticketRepository.GetTicketByID(LatestID.latestId);
      if((int)latestTicket.VehicleType == 1){
        return true;
      } else {
        return false;
      }
    }
    public async Task RunningCarwash (string wash) {
      await Task.Delay(1000);
      while(true)
      {
        List<CarwashEntries> queue = _carwashRepository.GetCarwashQueue(wash);
        if(queue.Count == 0 && CurrentScreenType.type == UI.Screen.Type.Select)
        {
          if(wash == "North"){
            Console.SetCursorPosition(0, 14);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, 14);
            Console.WriteLine($"Vaskehal {wash} er ledig.");
            await Task.Delay(2000);
          } else {
            Console.SetCursorPosition(0, 15);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, 15);
            Console.WriteLine($"Vaskehal {wash} er ledig.");
          }
          await Task.Delay(2000);
        } else {
            DisplayQueue(wash);
            await WashVehicle(wash);
          }
        }
      }

    public void DisplayQueue(string wash){
      int washId = 0;
      if(wash == "North"){
        washId = 0;
      } else {
        washId = 1;
      }
      List<CarwashEntries> queue = _carwashRepository.GetCarwashQueue(wash);
      if(queue.Count > 0){
        Console.SetCursorPosition(0, (14 + washId));
        Console.Write(new string(' ', Console.WindowWidth));
        Console.SetCursorPosition(0, (14 + washId));
        Console.Write($"Den nuværende kø er: {queue.Count} - Vaskehal {wash} er ledig igen {queue.Last().EndTime}");
      }
    }

    private List<string> SetStartAndEndTime(int washInterval, string wash){
      List<string> result = new();
      List<CarwashEntries> queue = _carwashRepository.GetCarwashQueue(wash);
      if(queue.Count == 0){
        DateTime start = DateTime.Now;
        DateTime end = start.AddSeconds(washInterval);
        result.Add(start.ToString());
        result.Add(end.ToString());
        return result;
      } else {
        CarwashEntries entry = queue.Last();
        DateTime entryEndTime = Convert.ToDateTime(entry.EndTime);
        DateTime start = entryEndTime.AddSeconds(2);
        DateTime end = start.AddSeconds(washInterval);
        result.Add(start.ToString());
        result.Add(end.ToString());
        return result;
        }
    }

    private Task WashVehicle(string wash)
    {
      List<CarwashEntries> queue = _carwashRepository.GetCarwashQueue(wash);
      if(queue.Count > 0)
      {
        DateTime end = Convert.ToDateTime(queue[0].EndTime);
        while(DateTime.Now < end){
          
        }
        _carwashRepository.DeleteWashed(queue[0].QueueID, wash);
      }
      return Task.CompletedTask;
    }
  }
}

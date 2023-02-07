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
        var key = Console.ReadKey(true);
          switch (key.Key)
          {
            case ConsoleKey.D1:
              List<string> economyTimes = SetStartAndEndTime(30);
              _carwashRepository.InsertToWashQueue(latest.LicensePlate, 1, 50m, economyTimes[0], economyTimes[1]);
              optionChosen = !optionChosen;
              break;
            case ConsoleKey.D2:
              List<string> basisTimes = SetStartAndEndTime(60);
              _carwashRepository.InsertToWashQueue(latest.LicensePlate, 2, 75m, basisTimes[0], basisTimes[1]);
              optionChosen = !optionChosen;
              break;
            case ConsoleKey.D3:
            List<string> premiumTimes = SetStartAndEndTime(90);
            _carwashRepository.InsertToWashQueue(latest.LicensePlate, 3, 100m, premiumTimes[0], premiumTimes[1]);
            optionChosen = !optionChosen;
            break;
            case ConsoleKey.Escape:
            throw new ReturnToMainException();
            default:
            break;
          }
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

    public async Task RunningCarwash () {
      await Task.Delay(1000);
      while(true)
      {
        List<CarwashEntries> queue = _carwashRepository.GetCarwashQueue();
        if(queue.Count == 0)
        {
          if(CurrentScreenType.type == UI.Screen.Type.Select){
            Console.SetCursorPosition(0, 15);
            Console.WriteLine("Vaskehallen er ledig.");
            Console.WriteLine(new string (' ', Console.WindowWidth));
            Console.WriteLine(new string (' ', Console.WindowWidth));
            Console.WriteLine(new string (' ', Console.WindowWidth));
            Console.WriteLine(new string (' ', Console.WindowWidth));
            await Task.Delay(2000);
          }
        } else {
            DisplayQueue();
            WashPrompt((Washtype)queue[0].Washtype);
            await WashVehicle();
          }
        }
      }

    public void DisplayQueue(){
      List<CarwashEntries> queue = _carwashRepository.GetCarwashQueue();
      if(queue.Count > 0){
        Console.SetCursorPosition(0, 15);
        Console.Write(new string(' ', Console.WindowWidth));
        Console.WriteLine($"Den nuværende kø er: {queue.Count}");
        Console.WriteLine($"Vaskehallen er ledig igen {queue.Last().EndTime}");
      } else {
        Console.SetCursorPosition(0, 15);
        Console.WriteLine("Vaskehallen er ledig.");
        Console.WriteLine(new string (' ', Console.WindowWidth));
        Console.WriteLine(new string (' ', Console.WindowWidth));
        Console.WriteLine(new string (' ', Console.WindowWidth));
        Console.WriteLine(new string (' ', Console.WindowWidth));
      }
    }

    private List<string> SetStartAndEndTime(int washInterval){
      List<string> result = new();
      List<CarwashEntries> queue = _carwashRepository.GetCarwashQueue();
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
    
    private void WashPrompt(Washtype washType){
        Console.SetCursorPosition(0, 18);
        Console.WriteLine(new string(' ', Console.WindowWidth));
        Console.WriteLine($"{washType} vask igang.");
    }

    private Task WashVehicle()
    {
      List<CarwashEntries> queue = _carwashRepository.GetCarwashQueue();
      if(queue.Count > 0)
      {
        DateTime end = Convert.ToDateTime(queue[0].EndTime);
        while(DateTime.Now < end){
          
        }
        _carwashRepository.DeleteWashed(queue[0].QueueID);
      }
      return Task.CompletedTask;
    }
  }
}

using Exceptions;
using UI;
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
      Console.Clear();
      Console.WriteLine(@"Tryk 1 - 3 for at vælge vask:
      1 - Economy
      2 - Basis
      3 - Premium
      Tryk ESC for at ANNULLERE");

      //NEVER DO THIS ____________________________
      bool optionChosen = false;
        while(!optionChosen)
        {
        var key = Console.ReadKey();
          switch (key.Key)
          {
            case ConsoleKey.D1:
            _carwashRepository.InsertToWashQueue(latest.LicensePlate, 1, 50m);
            optionChosen = !optionChosen;
            break;
            case ConsoleKey.D2:
            _carwashRepository.InsertToWashQueue(latest.LicensePlate, 2, 75m);
            optionChosen = !optionChosen;
            break;
            case ConsoleKey.D3:
            _carwashRepository.InsertToWashQueue(latest.LicensePlate, 3, 100m);
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
          if(CurrentScreenType.type == ScreenType.Select){
            Console.SetCursorPosition(0, 31);
            Console.WriteLine("No cars in carwash.");
            await Task.Delay(10000);
          }
        } else {
            if(CurrentScreenType.type == ScreenType.Select){
            Console.SetCursorPosition(0, 19);
            Console.Write($"Current queue is: {queue.Count}");
            WashPrompt((Washtype)queue[0].Washtype);
            await WashVehicle((Washtype)queue[0].Washtype);
            try{
              _carwashRepository.DeleteWashed(queue[0].QueueID);
            } catch{
              Console.WriteLine("Shitdontwork");
            }
            await AwaitNextVehicle();
          }
        }
      }
    }

    private void WashPrompt(Washtype washType){
        Console.SetCursorPosition(0, 20);
        Console.WriteLine(new string(' ', Console.WindowWidth));
        Console.WriteLine($"{washType} wash in progress.");
    }

    private async Task WashVehicle(Washtype washType){
      int economyWait = 10000;
      int basisWait = 15000;
      int premiumWait = 20000;
      switch (washType)
      {
        case Washtype.Economy:
          await Task.Delay(economyWait);
          break;
        case Washtype.Basis:
          await Task.Delay(basisWait);
          break;
        case Washtype.Premium:
          await Task.Delay(premiumWait);
          break;
        default:
        break;
      }
    }

    private async Task AwaitNextVehicle(){
      await Task.Delay(2000);
    }
  }
}

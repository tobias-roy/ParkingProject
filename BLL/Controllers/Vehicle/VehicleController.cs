using Service;
using Exceptions;
using DAL;
using UI.Screen;
namespace BLL.Controllers
{
  public class VehicleController : IVehicleController
  {
    private readonly IVehicleRepository _vehicleRepository;
    private readonly ILotRepository _lotRepository;
    public VehicleController (IVehicleRepository vehicleRepository, ILotRepository lotRepository)
    {
      _vehicleRepository = vehicleRepository;
      _lotRepository = lotRepository;
    }

    public void ChooseVehicle()
    {
      List<VehicleLot> lots = new();
      lots = _lotRepository.GetAllLots();
      while(lots.Count == 0){
        Console.Clear();
        Console.WriteLine("Henter data..");
      }
      Console.CursorVisible = false;
      LatestID.latestId = 0;
      Text.ClearTop();
      Console.WriteLine(@"Tryk 1 - 4 for at vælge køretøjstype:
      1 - Bil
      2 - Bil + Trailer
      3 - Bus
      4 - Lastbil
      Tryk ESC for at ANNULLERE");
      bool optionChosen = false;
      while(!optionChosen)
      {
        var key = Console.ReadKey(true);
        switch (key.Key)
        {
          case ConsoleKey.D1:
            optionChosen = SelectedVehicle(1);
            break;

          case ConsoleKey.D2:
            optionChosen = SelectedVehicle(2);
            break;

          case ConsoleKey.D3:
            optionChosen = SelectedVehicle(2);
            break;

          case ConsoleKey.D4:
            optionChosen = SelectedVehicle(2);
            break;

          case ConsoleKey.Escape:
            throw new ReturnToMainExceptionNoTicketCreation();
          default:
            break;
        }
      } 
    }

    private bool CheckAvailableLots(int type){
      List<VehicleLot> lots = new();
      try
      {
        lots = _lotRepository.GetAllLotsByType(type);
      }
      catch
      {
        throw new DatabaseUnreachableException();
      }
      foreach (var lot in lots)
      {
        if(lot.Status == 0){
          return true;
        }
      }
      return false;
    }

    private void NoLotsAvailablePrompt(int type){
      Console.SetCursorPosition(6,(type));
      Console.ForegroundColor = ConsoleColor.Red;
      Console.WriteLine($"Vi har desværre ikke flere {(Vehicle.Type)(type)} pladser tilbage.");
      Console.ForegroundColor = ConsoleColor.White;
    }

    private bool SelectedVehicle(int type){
      if(CheckAvailableLots(type)){
        Services.TicketController.CreateTicket(type);
        return true;
      } else {
        NoLotsAvailablePrompt(type);
        return false;
      }
    }
  }
}
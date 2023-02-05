using Service;
using Exceptions;
namespace BLL.Controllers
{
  public class VehicleController : IVehicleController
  {
    private readonly IVehicleRepository _vehicleRepository;
    public VehicleController (IVehicleRepository vehicleRepository)
    {
      _vehicleRepository = vehicleRepository;
    }

    public void ChooseVehicle()
    {
    Console.Clear();
    Console.WriteLine(@"Tryk 1 - 4 for at vælge køretøjstype:
    1 - Bil
    2 - Bil + Trailer
    3 - Bus
    4 - Lastbil
    Tryk ESC for at ANNULLERE");

    //NEVER DO THIS ____________________________
    bool optionChosen = false;
      while(!optionChosen)
      {
       var key = Console.ReadKey();
        switch (key.Key)
        {
          case ConsoleKey.D1:
            Services.TicketController.CreateTicket(1);
            optionChosen = !optionChosen;
            break;

          case ConsoleKey.D2:
            Services.TicketController.CreateTicket(2);
            optionChosen = !optionChosen;
            break;

          case ConsoleKey.D3:
            Services.TicketController.CreateTicket(3);
            optionChosen = !optionChosen;
            break;

          case ConsoleKey.D4:
            Services.TicketController.CreateTicket(4);
            optionChosen = !optionChosen;
            break;

          case ConsoleKey.Escape:
            optionChosen = !optionChosen;
            throw new ReturnToMainExceptionNoTicketCreation();
          default:
            break;
        }
      } 
    }
  }
}
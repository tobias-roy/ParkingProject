using Exceptions;
using Service;
using UI.Screen;
namespace UI
{
  class MainScreen
  {
    ///<summary>
    ///Starts the program and initiates two Async Carwashes.
    ///</summary>
    public void Start () {
      Console.CursorVisible = false;
      //Set screentype so the carwashes can write on screen.
      Screen.CurrentScreenType.type = Screen.Type.Select;
      //Initiates carwash North and South.
      Services.CarwashController.RunningCarwashAsync("North");
      Services.CarwashController.RunningCarwashAsync("South");
      //Wraps menu navigation so ReturnToMainException can be thrown anytime and return.
      try
      {
        while(true)
        {
          Text.ClearTop();
          Console.WriteLine("Tryk ENTER for at registrere køretøj");
          Console.WriteLine("Tryk ESC for at afslutte parkering");
          var key = Console.ReadKey();
          switch (key.Key)
          {
            case ConsoleKey.Enter:
              Text.ClearExceptionMessage();
              Screen.CurrentScreenType.type = Screen.Type.Select;
              new VehicleSelectScreen().Show();
              Screen.CurrentScreenType.type = Screen.Type.Input;
              new LicensePlateScreen().Show();
              Screen.CurrentScreenType.type = Screen.Type.Select;
              new CarwashSelectScreen().Show();
              Screen.CurrentScreenType.type = Screen.Type.Select;
              new LotInfoScreen().Show();
              break;
            case ConsoleKey.Escape:
              Screen.CurrentScreenType.type = Screen.Type.Input;
              new EndParkingScreen().Show();
              break;
            default:
              break;
          }
        }
      }
      catch (ReturnToMainExceptionDeleteCreated){
        Services.TicketController.UndoTicketCreation();
        Text.ClearTop();
        Console.WriteLine("Annulleret p-billet.");
        Thread.Sleep(1500);
      }
      catch (ReturnToMainException){
        Text.ClearTop();
        Console.WriteLine("Vender tilbage til startsiden.");
        Thread.Sleep(1500);
      }
      catch (ReturnToMainExceptionNoTicketCreation){
        Text.ClearTop();
        Console.WriteLine("Annulleret oprettelse.");
        Thread.Sleep(1500);
      }
    }
  }
}
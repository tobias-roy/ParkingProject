using Exceptions;
using Service;
using UI.Screen;

namespace UI
{
  ///<summary>
  ///Main menu screen
  ///</summary>
  class MainScreen
  {
    public void Start () {
      Console.CursorVisible = false;
      Screen.CurrentScreenType.type = Screen.Type.Select;
      Services.CarwashController.RunningCarwash();
      try
      {
      bool enterPressed = false;
      while(!enterPressed)
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
      catch (ReturnToMainException){
        Services.TicketController.CancelledTicketCreation();
        Text.ClearTop();
        Console.WriteLine("Annulleret p-billet.");
        Thread.Sleep(1500);
      }
      catch (ReturnToMainExceptionNoDB){
        Text.ClearTop();
        Console.WriteLine("Vender tilbage til startsiden..");
        Thread.Sleep(2000);
      }
      catch (ReturnToMainExceptionNoTicketCreation){
        Text.ClearTop();
        Console.WriteLine("Annulleret oprettelse.");
        Thread.Sleep(1500);
      }
    }
  }
}
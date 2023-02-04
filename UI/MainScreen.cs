using Exceptions;
using Service;
namespace UI
{
  ///<summary>
  ///Main menu screen
  ///</summary>
  class MainScreen
  {
    public void Start () {
      try
      {
      bool enterPressed = false;
      while(!enterPressed)
      {
        Console.Clear();
        Console.WriteLine("Tryk ENTER for at registrere køretøj");
        Console.WriteLine("Tryk ESC for at afslutte parkering");
        var key = Console.ReadKey();
        switch (key.Key)
        {
          case ConsoleKey.Enter:
            new VehicleSelectScreen().Show();
            new LicensePlateScreen().Show();
            new CarwashSelectScreen().Show();
            new LotInfoScreen().Show();
            break;
          case ConsoleKey.Escape:
            new EndParkingScreen().Show();
            break;
          default:
            break;
        }
      }
      }
      catch (ReturnToMainException){
        Services.TicketController.CancelledTicketCreation();
        Console.Clear();
        Console.WriteLine("Annulleret p-billet.");
        Thread.Sleep(3000);
      }
      catch (ReturnToMainExceptionNoDB){
        Console.Clear();
        Console.WriteLine("Annulleret udtjekning.");
        Thread.Sleep(3000);
      }
    }
  }
}
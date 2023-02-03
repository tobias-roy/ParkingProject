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
        var key = Console.ReadKey();
        switch (key.Key)
        {
          case ConsoleKey.Enter:
            new VehicleSelectScreen().Show();
            new LicensePlateScreen().Show();
            new CarwashSelectScreen().Show();
            new LotInfoScreen().Show();
            break;
          default:
            break;
        }
      }
      }
      catch (ReturnToMainException){
        Services.TicketController.CancelledTicketCreation();
        Console.Clear();
        Console.WriteLine("Handling annulleret");
      }
    }
  }
}
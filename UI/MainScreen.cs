using Service;
namespace UI
{
  ///<summary>
  ///Main menu screen
  ///</summary>
  class MainScreen
  {
    static int width = 200;
    static int height = 60;

    public void Start () {
      Services.TicketController.WriteOutAllTickets();
      Console.Clear();
      //Todo Lot Overview
      Console.WriteLine("Tryk ENTER for at registrere køretøj");
      bool enterPressed = false;
      while(!enterPressed)
      {
       var key = Console.ReadKey();
        switch (key.Key)
        {
          case ConsoleKey.Enter:
            Flow();
            enterPressed = !enterPressed;
            break;
          default:
            break;
        }
      }
      Console.ReadKey(); 
    }

    public void Flow () {
      VehicleSelectScreen VehicleSelectScreen = new();
      VehicleSelectScreen.Show();
      LicensePlateScreen LicensePlateScreen = new();
      LicensePlateScreen.Show();

    }
  }
}
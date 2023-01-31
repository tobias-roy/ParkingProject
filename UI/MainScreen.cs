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
            VehicleSelectScreen VehicleSelectScreen = new();
            VehicleSelectScreen.UI();
            enterPressed = !enterPressed;
            break;
          default:
            break;
        }
      }
    }
  }
}
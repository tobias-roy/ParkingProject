using ST_Parking;

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
      Services.TicketController.WriteOutAllTickets();
      Console.ReadKey(); 
    }
  }
}
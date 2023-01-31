using Service;
class VehicleSelectScreen
{
  public void UI (){
    Console.Clear();
    Console.WriteLine(@"Tryk 1 - 4 for at vælge køretøjstype:
    1 - Bil
    2 - Bil + Trailer
    3 - Bus
    4 - Lastbil
    Tryk ESC for at ANNULLERE");

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
            break;

          default:
            break;
        }
      }


    Console.ReadKey();
  }
}
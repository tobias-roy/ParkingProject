using UI;
Console.WriteLine(DateTime.UtcNow);
MainScreen main = new();
while (true)
{
  main.Start();
  // Services.TicketController.WriteOutAllTickets();
  // Services.TicketController.WriteOutTicketFromID(1);
}
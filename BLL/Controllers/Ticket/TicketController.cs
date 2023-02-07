using DAL;
namespace BLL.Controllers
{
  public class TicketController : ITicketController
  {
    private readonly ITicketRepository _ticketRepository;

    public TicketController (ITicketRepository ticketRepository) {
        _ticketRepository = ticketRepository;
    }
    public void CreateTicket(int type){
      
        Console.SetCursorPosition(0, 7);
        Console.Write("Opretter billet, vent venligst..");
        _ticketRepository.CreateTicket(type);
        LatestID.latestId = _ticketRepository.GetLatestID();
        Console.SetCursorPosition(0, 7);
        Console.Write(new string(' ', Console.WindowWidth));
    }
    

    public void UpdateTicket(int id, string column, string value)
    {
      _ticketRepository.UpdateTicket(id, column, value);
    }

    public void UpdateTicket(int id, string column, int value)
    {
      _ticketRepository.UpdateTicket(id, column, value);
    }

    public void CancelledTicketCreation(){
      _ticketRepository.DeleteTicketByID(LatestID.latestId);
    }

    public void SetParkingTimeStart(){
      _ticketRepository.UpdateTicket(LatestID.latestId, "ParkingStart", DateTime.Now.ToString());
    }
  }
}

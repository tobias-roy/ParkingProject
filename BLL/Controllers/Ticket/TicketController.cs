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
      _ticketRepository.CreateTicket(type);
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

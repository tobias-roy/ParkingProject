using DAL;
namespace BLL.Controllers
{
  public class CancellationController : ICancellationController
  {
    private readonly ILotRepository _lotRepository;
    private readonly ITicketRepository _ticketRepository;

    public CancellationController ( ITicketRepository ticketRepository, ILotRepository lotRepository) {
        _ticketRepository = ticketRepository;
        _lotRepository = lotRepository;
    }

    public void CancelTicketCreation(){
      Ticket latestTicket = _ticketRepository.GetTicketByID(LatestID.latestId);
      _lotRepository.UpdateLot(latestTicket.LotID, "Status", 0);
      _ticketRepository.DeleteTicketByID(LatestID.latestId);
    }
  }
}

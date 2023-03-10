using DAL;
namespace BLL.Controllers
{
  public class CancellationController : ICancellationController
  {
    private readonly ILotInfoRepository _lotInfoRepository;
    private readonly ILotRepository _lotRepository;
    private readonly ITicketRepository _ticketRepository;

    public CancellationController (ILotInfoRepository lotInfoRepository, ITicketRepository ticketRepository, ILotRepository lotRepository) {
        _lotInfoRepository = lotInfoRepository;
        _ticketRepository = ticketRepository;
        _lotRepository = lotRepository;
    }

    public void CancelCreation(){
      Ticket latestTicket = _ticketRepository.GetTicketByID(LatestID.latestId);
      _lotRepository.UpdateLot(latestTicket.LotID, "Status", 0);
      _ticketRepository.DeleteTicketByID(LatestID.latestId);
    }
  }
}

namespace BLL.Controllers
{
  public class LotInfoController : ILotInfoController
  {
    private readonly ILotInfoRepository _lotInfoRepository;
    private readonly ILotRepository _lotRepository;
    private readonly ITicketRepository _ticketRepository;

    public LotInfoController (ILotInfoRepository lotInfoRepository, ITicketRepository ticketRepository, ILotRepository lotRepository) {
        _lotInfoRepository = lotInfoRepository;
        _ticketRepository = ticketRepository;
        _lotRepository = lotRepository;
    }

    public void ChangeLotStatus()
    {
      int id = _ticketRepository.GetLatestID();
      _ticketRepository.UpdateTicket(id, "ParkingStart", DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ssK"));
    }

  }
}

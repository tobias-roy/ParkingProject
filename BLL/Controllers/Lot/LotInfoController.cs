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

    public void PrintLotAndTicketInfo()
    {
      int id = _ticketRepository.GetLatestID();
      Ticket yourTicket = _ticketRepository.GetTicketByID(id);
      DateTime parkingStart = Convert.ToDateTime(yourTicket.ParkingStart);
      Console.WriteLine($"Kør til plads {yourTicket.LotID}");
      Console.WriteLine($"Prisen i pr. påbegyndt time er {yourTicket.Price} kr.-");
      Console.WriteLine($"Din parkering er registreret påbegyndt {parkingStart.ToString("dddd, dd MMMM yyyy HH:mm:ss")}");
      Thread.Sleep(8000);
    }
  }
}

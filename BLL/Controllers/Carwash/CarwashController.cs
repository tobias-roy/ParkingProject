namespace BLL.Controllers
{
  public class CarwashController : ICarwashController
  {
    private readonly ICarwashRepository _carwashRepository;
    private readonly ITicketRepository _ticketRepository;

    public CarwashController (ICarwashRepository carwashRepository, ITicketRepository ticketRepository) {
        _carwashRepository = carwashRepository;
        _ticketRepository = ticketRepository;
    }

    public void Start(){

    }

    public bool CanChooseCarwash(){
      int ticketId = _ticketRepository.GetLatestID();
      Ticket latestTicket = _ticketRepository.GetTicketByID(ticketId);
      if((int)latestTicket.VehicleType == 1){
        return true;
      } else {
        return false;
      }
    }

   
  }
}

namespace BLL.Controllers
{
    public interface ITicketController
    {
        void CreateTicket(int type);
        void WriteOutAllTickets();
        void WriteOutTicketFromID(int id);
    }
}

namespace BLL.Controllers
{
    public interface ITicketController
    {
        void CreateTicket(int type);
        void WriteOutAllTickets();
        void WriteOutTicketFromID(int id);
        void UpdateTicket(int id, string column, string value);
        void UpdateTicket(int id, string column, int value);
    }
}

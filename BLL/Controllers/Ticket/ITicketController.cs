namespace BLL.Controllers
{
    public interface ITicketController
    {
        void CreateTicket(int type);
        void UpdateTicket(int id, string column, string value);
        void UpdateTicket(int id, string column, int value);
        void UndoTicketCreation();
        void SetParkingTimeStart();
    }
}

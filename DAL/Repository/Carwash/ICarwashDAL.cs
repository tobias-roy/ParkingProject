using BLL;
namespace DAL
{
  public interface ICarwashDAL{
    List<Ticket> GetQueue();
  }
}

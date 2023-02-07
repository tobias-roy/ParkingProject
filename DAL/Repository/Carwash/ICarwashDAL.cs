using BLL;
namespace DAL
{
  public interface ICarwashDAL{
    List<CarwashEntries> GetCarwashQueue(string wash);
    void DeleteWashed(int id, string wash);

    void InsertToWashQueue(string wash, string licensePlate, int washtype, decimal price, string startTime, string endTime);

  }
}

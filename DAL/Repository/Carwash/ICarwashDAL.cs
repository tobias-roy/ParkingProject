using BLL;
namespace DAL
{
  public interface ICarwashDAL{
    List<CarwashEntries> GetCarwashQueue();
    void DeleteWashed(int id);

    void InsertToWashQueue(string licensePlate, int washtype, decimal price, string startTime, string endTime);

  }
}

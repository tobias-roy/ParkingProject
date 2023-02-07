namespace BLL
{
  public interface ICarwashRepository{

    List<CarwashEntries> GetCarwashQueue(string wash);
    void DeleteWashed(int id, string wash);

    void InsertToWashQueue(string wash, string licensePlate, int washtype, decimal price, string startTime, string endTime);

  } 
}
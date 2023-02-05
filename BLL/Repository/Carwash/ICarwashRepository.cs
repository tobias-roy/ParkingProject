namespace BLL
{
  public interface ICarwashRepository{

    List<CarwashEntries> GetCarwashQueue();
    void DeleteWashed(int id);

    void InsertToWashQueue(string licensePlate, int washtype, decimal price);

  } 
}
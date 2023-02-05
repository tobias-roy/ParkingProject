using DAL;

namespace BLL
{
  public class CarwashRepository : ICarwashRepository
  {
    
    public ICarwashDAL _carwashData;
    public CarwashRepository(ICarwashDAL carwashData)
    {
      _carwashData = carwashData;
    }

    public void DeleteWashed(int id)
    {
      _carwashData.DeleteWashed(id);
    }

    public List<CarwashEntries> GetCarwashQueue()
    {
      return _carwashData.GetCarwashQueue();
    }

    public void InsertToWashQueue(string licensePlate, int washtype, decimal price)
    {
      _carwashData.InsertToWashQueue(licensePlate, washtype, price);
    }
  } 
}
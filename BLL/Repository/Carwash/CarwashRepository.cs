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

    public void DeleteWashed(int id, string wash)
    {
      _carwashData.DeleteWashed(id, wash);
    }

    public List<CarwashEntries> GetCarwashQueue(string wash)
    {
      return _carwashData.GetCarwashQueue(wash);
    }

    public void InsertToWashQueue(string wash, string licensePlate, int washtype, decimal price, string startTime, string endTime)
    {
      _carwashData.InsertToWashQueue(wash, licensePlate, washtype, price, startTime, endTime);
    }
  } 
}
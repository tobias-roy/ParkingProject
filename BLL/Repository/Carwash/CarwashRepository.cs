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
  } 
}
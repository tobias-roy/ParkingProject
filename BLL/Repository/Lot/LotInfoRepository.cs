using DAL;

namespace BLL
{
  public class LotInfoRepository : ILotInfoRepository
  {
    
    public ILotDAL _lotData;
    public LotInfoRepository(ILotDAL lotData)
    {
      _lotData = lotData;
    }
    
  } 
}
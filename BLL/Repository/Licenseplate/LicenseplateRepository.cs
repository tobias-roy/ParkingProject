using DAL;

namespace BLL
{
  public class LicenseplateRepository : ILicenseplateRepository
  {
    public ILicenseplateDAL _licenseplateData;
    public LicenseplateRepository(ILicenseplateDAL licenseplateData)
    {
      _licenseplateData = licenseplateData;
    }

    public List<string> GetAllLicenseplates()
    {
      return _licenseplateData.GetAllLicenseplates();
    }

    public void UpdateTicket(int id, string column, string value)
    {
      throw new NotImplementedException();
    }
  }
}
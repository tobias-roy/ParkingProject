namespace BLL
{
  public interface ILicenseplateRepository
  {

    List<string> GetAllLicenseplates();
    void UpdateTicket(int id, string column, string value);
  } 
}
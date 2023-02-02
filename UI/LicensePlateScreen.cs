using Service;
class LicensePlateScreen
{
  public void Show () {
    Console.Clear();
    Services.LicenseplateController.EnterLicenseplate();
  }
}
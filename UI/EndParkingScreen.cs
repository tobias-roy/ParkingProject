using Service;
class EndParkingScreen
{
  public void Show (){
    Console.Clear();
    Services.LicenseplateController.EndParkingEnterLicenseplate();
  }
}
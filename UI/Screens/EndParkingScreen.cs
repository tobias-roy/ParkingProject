using Service;
using UI.Screen;
class EndParkingScreen
{
  public void Show (){
    Text.ClearTop();
    Services.LicenseplateController.EndParkingEnterLicenseplate();
  }
}
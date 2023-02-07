using Service;
using UI.Screen;
class LicensePlateScreen
{
  public void Show () {
    Text.ClearTop();
    Services.LicenseplateController.EnterLicenseplate();
    Console.CursorVisible = false;
  }
}
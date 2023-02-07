using Service;
using UI.Screen;
class CarwashSelectScreen
{
  public void Show () {
    if(Services.CarwashController.CanChooseCarwash()){
      Text.ClearTop();
      Services.CarwashController.Select();
    }
  }
}
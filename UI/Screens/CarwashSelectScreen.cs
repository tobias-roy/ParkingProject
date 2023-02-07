using Service;
using UI.Screen;
class CarwashSelectScreen
{
  public void Show () {
    if(Services.CarwashController.CanChooseCarwash()){
      Text.ClearTop();
      Services.CarwashController.DisplayQueue("North");
      Services.CarwashController.DisplayQueue("South");
      Services.CarwashController.Select();
    }
  }
}
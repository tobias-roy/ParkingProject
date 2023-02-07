using Service;
using UI.Screen;
class VehicleSelectScreen
{
  public void Show (){
    Text.ClearTop();
    Services.VehicleController.ChooseVehicle();
    Services.CarwashController.DisplayQueue("North");
    Services.CarwashController.DisplayQueue("South");
  }
}
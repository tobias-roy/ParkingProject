using Service;
using UI.Screen;
class VehicleSelectScreen
{
  ///<summary>
  ///Start the vehicle selection screen, awaiting user input
  ///</summary>
  public void Show (){
    Text.ClearTop();
    Services.VehicleController.ChooseVehicle();
    Services.CarwashController.DisplayQueue("North");
    Services.CarwashController.DisplayQueue("South");
  }
}
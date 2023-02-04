using Service;
class VehicleSelectScreen
{
  public void Show (){
    Console.Clear();
    Services.VehicleController.ChooseVehicle();
  }
}
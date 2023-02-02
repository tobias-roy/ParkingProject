using Service;
class CarwashSelectScreen
{
  public void Show () {
    Console.Clear();
    if(Services.CarwashController.CanChooseCarwash()){
      Console.Clear();
      Console.WriteLine("Yeaaaaaahaw");
    }
  }
}
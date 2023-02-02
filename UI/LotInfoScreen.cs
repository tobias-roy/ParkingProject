using Service;
class LotInfoScreen
{
  public void Show () {
    Console.Clear();
    Services.LotInfoController.ChangeLotStatus();
  }
}
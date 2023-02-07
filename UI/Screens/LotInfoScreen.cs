using Service;
using UI.Screen;
class LotInfoScreen
{
  public void Show () {
    Text.ClearTop();
    Services.TicketController.SetParkingTimeStart();
    Services.LotInfoController.PrintLotAndTicketInfo();
    Services.CarwashController.DisplayQueue("North");
    Services.CarwashController.DisplayQueue("South");
  }
}
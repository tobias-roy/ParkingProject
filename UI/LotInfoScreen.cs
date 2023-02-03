using Service;
class LotInfoScreen
{
  public void Show () {
    Console.Clear();
    Services.TicketController.SetParkingTimeStart();
    Services.LotInfoController.PrintLotAndTicketInfo();
  }
}
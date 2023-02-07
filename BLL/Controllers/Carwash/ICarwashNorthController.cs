namespace BLL.Controllers
{
  public interface ICarwashController
  {
    bool CanChooseCarwash();
    void Select();
    // Task RunningCarwash(string washName, int washId);
    Task RunningCarwash(string washName);
    void DisplayQueue(string wash);
  }
}

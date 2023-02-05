namespace BLL.Controllers
{
  public interface ICarwashController
  {
    bool CanChooseCarwash();
    void Select();
    Task RunningCarwash();
  }
}

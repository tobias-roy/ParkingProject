namespace BLL.Controllers
{
  public interface ICarwashController
  {
    bool CanChooseCarwash();
    void Select();

    ///<summary>
    ///Will start an async instance of the carwash <br/>
    ///<paramref name="washName"/> is the Name of the carwash <br/>
    ///For this to work you need a corresponding database table
    ///</summary>
    Task RunningCarwashAsync(string washName);
    
    ///<summary>
    ///Will display the current queue in carwash <br/>
    ///<paramref name="wash"/> Name of wash you want to display info from
    ///</summary>
    void DisplayQueue(string wash);
  }
}

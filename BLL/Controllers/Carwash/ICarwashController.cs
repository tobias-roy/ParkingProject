namespace BLL.Controllers
{
  public interface ICarwashController
  {
    ///<summary>
    ///Checks to see if vehicle type is allowed in the carwash <br/>
    ///<returns>True if vehicle is car <br/>
    ///False if vehicle is any other</returns>
    ///</summary>
    bool CanChooseCarwash();
    
    ///<summary>
    ///Prints the selectable washes and makes it possible to choose one <br/>
    ///Sets the start and end time for the wash in the database
    ///</summary>
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

namespace BLL.Controllers
{
    public interface ILicenseplateController
    {
        ///<summary>
        ///Prompts the user to enter the licenseplate for the vehicle they want to park.
        ///</summary>
        void EnterLicenseplate();

        ///<summary>
        ///Prompts the user to enter the licenseplate for the vehicle they want to end parking.
        ///</summary>
        void EndParkingEnterLicenseplate();
    }
}

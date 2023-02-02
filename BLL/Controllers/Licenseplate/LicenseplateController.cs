using System.Text;
using System.Text.RegularExpressions;
using Exceptions;

namespace BLL.Controllers
{
  public class LicenseplateController : ILicenseplateController
  {
    private readonly ILicenseplateRepository _licenseplateRepository;
    private readonly ITicketRepository _ticketRepository;
    public LicenseplateController (ILicenseplateRepository licenseplateRepository, ITicketRepository ticketRepository)
    {
      _licenseplateRepository = licenseplateRepository;
      _ticketRepository = ticketRepository;
    }

    public void EnterLicenseplate()
    {
      bool cancelledLicenseplateInput = false;
      Console.Clear();
      Console.WriteLine("Indtast nummerplade og afslut med enter.");
      Console.WriteLine("Nummerplade:");
      bool validLicenseplate = false;
      while(!validLicenseplate && !cancelledLicenseplateInput)
      {
        Console.CursorVisible = true;
        string licenseplateInput = readLineWithCancel();
        if(licenseplateInput != null){
          licenseplateInput = Regex.Replace(licenseplateInput, @"\s+", "");
          if (licenseplateInput.Length > 7)
          {
            LicenseplateCheckErrorPrompt(licenseplateInput, "er for lang.");
          }
          else if (licenseplateInput.Length < 2)
          {
            LicenseplateCheckErrorPrompt(licenseplateInput, "er for kort.");
          }
          else if (!(Regex.IsMatch(licenseplateInput, "^[a-zA-Z0-9 ]*$")))
          {
            LicenseplateCheckErrorPrompt(licenseplateInput, "indeholder ugyldige tegn.");
          }
          else if (CheckLicenseplateDatabase(licenseplateInput))
          {
            LicenseplateCheckErrorPrompt(licenseplateInput, "er allerede registreret som parkeret.");
          }
          else
          {
            validLicenseplate = !validLicenseplate;
            int ticketId = _ticketRepository.GetLatestID();
            _ticketRepository.UpdateTicket(ticketId, "LicensePlate", licenseplateInput);
          }
        } else {
          cancelledLicenseplateInput = !cancelledLicenseplateInput;
          throw new ReturnToMainException();
        }
      }
    }

    private static string readLineWithCancel()
    {
      string result = null;

      StringBuilder buffer = new StringBuilder();

      //The key is read passing true for the intercept argument to prevent
      //any characters from displaying when the Escape key is pressed.
      ConsoleKeyInfo info = Console.ReadKey(true);
      while (info.Key != ConsoleKey.Enter && info.Key != ConsoleKey.Escape)
      {
          Console.Write(info.KeyChar);
          buffer.Append(info.KeyChar);
          info = Console.ReadKey(true);
      } 

      if (info.Key == ConsoleKey.Enter)
      {
          result = buffer.ToString();
      }

      return result;
    }


    ///<summary>
    ///Returns true if licenseplate already is actively parked and assigned to a lot.
    ///</summary>
    private bool CheckLicenseplateDatabase(string licenseplate){
      List<string> plates = _licenseplateRepository.GetAllLicenseplates();
      foreach (var plate in plates)
      {
        if(licenseplate == plate){
          return true;
        }
      }
      return false;
    }

    private void LicenseplateCheckErrorPrompt(string licenseplate, string reason){
      Console.SetCursorPosition(0, 2);
      Console.WriteLine(new string(' ', Console.WindowWidth));
      Console.ForegroundColor = ConsoleColor.Red;
      Console.WriteLine($"Nummerplade {licenseplate} {reason}.\nIndtast venligst en gyldig nummerplade");
      Console.SetCursorPosition(0, 2);
      Console.ForegroundColor = ConsoleColor.White;
    }
  }
}

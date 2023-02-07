using System.Text;
using System.Text.RegularExpressions;
using Exceptions;
using DAL;
using UI.Screen;

namespace BLL.Controllers
{
  public class LicenseplateController : ILicenseplateController
  {
    private readonly ICarwashRepository _carwashRepository;
    private readonly ILicenseplateRepository _licenseplateRepository;
    private readonly ITicketRepository _ticketRepository;
    private readonly ILotRepository _lotRepository;
    public LicenseplateController (ICarwashRepository carwashRepository, ILicenseplateRepository licenseplateRepository, ITicketRepository ticketRepository, ILotRepository lotRepository)
    {
      _licenseplateRepository = licenseplateRepository;
      _ticketRepository = ticketRepository;
      _lotRepository = lotRepository;
      _carwashRepository = carwashRepository;
    }

    public void EnterLicenseplate()
    {
      bool cancelledLicenseplateInput = false;
      Text.ClearTop();
      Console.WriteLine("Indtast nummerplade og afslut med enter.");
      Console.WriteLine("Nummerplade:");
      Console.SetCursorPosition(0, 6);
      Console.WriteLine("Tryk ESC for at annullere.");
      Console.SetCursorPosition(0, 2);

      bool validLicenseplate = false;
      while(!validLicenseplate && !cancelledLicenseplateInput)
      {
        Console.CursorVisible = true;
        string licenseplateInput = readLineWithCancel();
        licenseplateInput = licenseplateInput.ToUpper();
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
            _ticketRepository.UpdateTicket(LatestID.latestId, "LicensePlate", licenseplateInput);
          }
        } else {
          cancelledLicenseplateInput = !cancelledLicenseplateInput;
          throw new ReturnToMainExceptionDeleteCreated();
        }
      }
    }

    public void EndParkingEnterLicenseplate()
    {
      bool cancelledLicenseplateInput = false;
      Text.ClearTop();
      Console.WriteLine("Indtast nummerplade og afslut med enter.");
      Console.WriteLine("Nummerplade:");
      Console.SetCursorPosition(0, 6);
      Console.WriteLine("Tryk ESC for at annullere.");
      Console.SetCursorPosition(0, 2);

      bool validLicenseplate = false;
      while(!validLicenseplate && !cancelledLicenseplateInput)
      {
        Console.CursorVisible = true;
        string licenseplateInput = readLineWithCancel();
        licenseplateInput = licenseplateInput.ToUpper();
        if(licenseplateInput != null){
          licenseplateInput = Regex.Replace(licenseplateInput, @"\s+", "");
          if (!CheckLicenseplateDatabase(licenseplateInput))
          {
            LicenseplateCheckErrorPrompt(licenseplateInput, "er ikke registreret i systemet.");
          }
          else
          {
            Ticket ticket = _ticketRepository.GetTicketByLicenseplate(licenseplateInput);
            DateTime parkingEnd = new DateTime();
            parkingEnd = DateTime.Now;
            _ticketRepository.UpdateTicket(ticket.ID, "ParkingEnd", parkingEnd.ToString());
            DateTime parkingStart = Convert.ToDateTime(ticket.ParkingStart);
            int hoursBetween = Convert.ToInt32((parkingStart - parkingEnd).TotalHours) + 1;
            decimal fullPrice = hoursBetween * ticket.Price;
            if(ticket.OrderedWash == 1){
              fullPrice += ticket.WashPrice;
            }
            _ticketRepository.UpdateTicket(ticket.ID, "Price", fullPrice);
            _lotRepository.UpdateLot(ticket.LotID, "Status", 0);
            validLicenseplate = !validLicenseplate;
            Text.ClearTop();
            Console.WriteLine("Tak fordi du parkerede hos os.");
            Console.WriteLine($"Din fulde pris til betaling er: {fullPrice}");
            Console.WriteLine("Vi sender regningen til din addresse.");
            Console.WriteLine("God dag.");
            Thread.Sleep(8000);
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
        if (info.Key == ConsoleKey.Backspace){
          Console.SetCursorPosition(Console.GetCursorPosition().Left - 1, Console.GetCursorPosition().Top);
          Console.Write(new string(' ', 1));
          Console.SetCursorPosition(Console.GetCursorPosition().Left - 1, Console.GetCursorPosition().Top);
          buffer.Length = buffer.Length - 1;
          info = Console.ReadKey(true);
        } else {
        Console.Write(info.KeyChar);
        buffer.Append(info.KeyChar);
        info = Console.ReadKey(true);
        }
      }

      if (info.Key == ConsoleKey.Backspace)
      {
        buffer.Length--;
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

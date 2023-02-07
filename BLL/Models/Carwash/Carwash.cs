namespace BLL 
{
  public class CarwashEntries
  {
    public int QueueID { get; set; }
    public string LicensePlate { get; set; }
    public Washtype Washtype { get; set; }
    public decimal Price { get; set; }
    public string StartTime { get; set; }
    public string EndTime { get; set; }
  }
}

public enum Washtype {
  Economy = 1,
  Basis = 2,
  Premium = 3
}
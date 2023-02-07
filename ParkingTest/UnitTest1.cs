using BLL;
using Moq;
using Xunit;
namespace UnitTest;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        var lotMem = new List<VehicleLot>
        {
            new VehicleLot() {LotID = "101", Status = Status.Free, LotType = LotType.CarLot, Price = 50m},
            new VehicleLot() {LotID = "102", Status = Status.Free, LotType = LotType.CarLot, Price = 50m},
            new VehicleLot() {LotID = "103", Status = Status.Free, LotType = LotType.CarLot, Price = 50m},
            new VehicleLot() {LotID = "104", Status = Status.Free, LotType = LotType.CarLot, Price = 50m},
            new VehicleLot() {LotID = "105", Status = Status.Free, LotType = LotType.CarLot, Price = 50m}
        };

        var repository = new Mock<ILotRepository>();
        repository.Setup(x => x.GetLotByID(It.IsAny<int>))
            .Returns((int i) => lotMem.Single(lot => lot.LotID == i));

        var lotRepo = new LotRepository(repository.Object);
        var lotThatIs = lotRepo.GetLotByID(101);
        Assert.NotNull(lotThatIs);
        Assert.Equal(lotThatIs.LotID = "103");
    }
}
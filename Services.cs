using Microsoft.Extensions.DependencyInjection;
using DAL;
using BLL;
using BLL.Controllers;

namespace Service
{
  public static class Services
    {
        private static IServiceProvider _serviceProvider;
        private static IServiceProvider ServiceProvider { 
            get 
            {
                if(_serviceProvider == null) {
                    _serviceProvider = CreateServiceProvider();
                }
                return _serviceProvider;
            }
        }
        private static IServiceProvider CreateServiceProvider () {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<ITicketDAL, TicketDAL>()
                .AddSingleton<ITicketRepository, TicketRepository>(sp => 
                {
                    var ticketDALRepository = sp.GetRequiredService<ITicketDAL>(); 
                    return new TicketRepository(ticketDALRepository);
                })
                .AddSingleton<ILotDAL, LotDAL>()
                .AddSingleton<ILotRepository, LotRepository>(sp => 
                {
                    var lotDALRepository = sp.GetRequiredService<ILotDAL>(); 
                    return new LotRepository(lotDALRepository);
                })
                .AddSingleton<ILicenseplateDAL, LicenseplateDAL>()
                .AddSingleton<ILicenseplateRepository, LicenseplateRepository>(sp => 
                {
                    var licenseplateDALRepository = sp.GetRequiredService<ILicenseplateDAL>(); 
                    return new LicenseplateRepository(licenseplateDALRepository);
                })
                .AddSingleton<ICarwashDAL, CarwashDAL>()
                .AddSingleton<ICarwashRepository, CarwashRepository>(sp => 
                {
                    var carwashDALRepository = sp.GetRequiredService<ICarwashDAL>(); 
                    return new CarwashRepository(carwashDALRepository);
                })
                .AddSingleton<ILotInfoRepository, LotInfoRepository>(sp => 
                {
                    var lotDALRepository = sp.GetRequiredService<ILotDAL>(); 
                    return new LotInfoRepository(lotDALRepository);
                })
                .AddSingleton<IVehicleRepository, VehicleRepository>()
                .BuildServiceProvider();
            return serviceProvider;
        }

        //Ticket controller
        private static ITicketController _ticketController;
        public static ITicketController TicketController { 
            get 
            {
                if(_ticketController == null) {
                    _ticketController = new TicketController(ServiceProvider.GetRequiredService<ITicketRepository>());
                }
                return _ticketController;
            }
        }

        //Lot controller
        private static ILicenseplateController _licenseplateController;
        public static ILicenseplateController LicenseplateController { 
            get 
            {
                if(_licenseplateController == null) {
                    _licenseplateController = new LicenseplateController(ServiceProvider.GetRequiredService<ILicenseplateRepository>(), ServiceProvider.GetRequiredService<ITicketRepository>(), ServiceProvider.GetRequiredService<ILotRepository>());
                }
                return _licenseplateController;
            }
        }

        private static ILotController _lotController;
        public static ILotController LotController { 
            get 
            {
                if(_lotController == null) {
                    _lotController = new LotController(ServiceProvider.GetRequiredService<ILotRepository>());
                }
                return _lotController;
            }
        }

        private static ILotInfoController _lotInfoController;
        public static ILotInfoController LotInfoController { 
            get 
            {
                if(_lotInfoController == null) {
                    _lotInfoController = new LotInfoController(ServiceProvider.GetRequiredService<ILotInfoRepository>(), ServiceProvider.GetRequiredService<ITicketRepository>(), ServiceProvider.GetRequiredService<ILotRepository>());
                }
                return _lotInfoController;
            }
        }

        private static ICarwashController _carwashController;
        public static ICarwashController CarwashController { 
            get 
            {
                if(_carwashController == null) {
                    _carwashController = new CarwashController(ServiceProvider.GetRequiredService<ICarwashRepository>(), ServiceProvider.GetRequiredService<ITicketRepository>());
                }
                return _carwashController;
            }
        }

        private static IVehicleController _vehicleController;
        public static IVehicleController VehicleController { 
            get 
            {
                if(_vehicleController == null) {
                    _vehicleController = new VehicleController(ServiceProvider.GetRequiredService<IVehicleRepository>());
                }
                return _vehicleController;
            }
        }
}

}

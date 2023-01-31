using Microsoft.Extensions.DependencyInjection;
using DAL;
using BLL;
using BLL.Controllers;

namespace Service
{
  public static class Services
    {
        private static IServiceProvider? _serviceProvider;
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
                .BuildServiceProvider();
            return serviceProvider;
        }

        //Ticket controller
        private static ITicketController? _ticketController;
        public static ITicketController TicketController { 
            get 
            {
                if(_ticketController == null) {
                    _ticketController = new TicketController(ServiceProvider.GetRequiredService<ITicketRepository>());
;
                }
                return _ticketController;
            }
        }

        //Lot controller
        private static ILotController? _lotController;
        public static ILotController LotController { 
            get 
            {
                if(_lotController == null) {
                    _lotController = new LotController(ServiceProvider.GetRequiredService<ILotRepository>());
;
                }
                return _lotController;
            }
        }
    }

}

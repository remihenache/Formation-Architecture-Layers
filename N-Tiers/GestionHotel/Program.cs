using GestionHotel.Application;
using GestionHotel.Business;
using GestionHotel.DAL;

namespace GestionHotel;

public class Program
{
    public static void Main(string[] args)
    {
        if(args[0] == "Reserver")
            GetReservationUseCase().Execute(int.Parse(args[1]), int.Parse(args[2]), DateTime.Parse(args[3]), DateTime.Parse(args[4]), bool.Parse(args[5]));
    }

    private static ReservationUseCase GetReservationUseCase()
        => new ReservationUseCase(new ReservationServices(new MemoryReservationRepository(), new FakePayementService()), new MemoryReservationRepository());
}


using GestionHotel.Adapter;
using GestionHotel.Application;

namespace GestionHotel;

public class Program
{
    public static void Main(string[] args)
    {
        if(args[0] == "Reserver")
            GetReservationUseCase().Execute(int.Parse(args[1]), int.Parse(args[2]), DateTime.Parse(args[3]), DateTime.Parse(args[4]), bool.Parse(args[5]));
    }

    private static ReservationUseCase GetReservationUseCase()
        => new ReservationUseCase(new InMemoryRoomAvailability(), new FakePayementService(), new InMemoryReservationRepository());
}
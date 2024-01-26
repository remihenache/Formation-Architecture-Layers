using GestionHotel.Domain;

namespace GestionHotel.Application;


public class ReservationUseCase
{
    private readonly IRoomAvailabilityService roomAvailabilityService;
    private readonly IPayementService payementService;
    private readonly IReservationRepository repository;

    public ReservationUseCase(
        IRoomAvailabilityService roomAvailabilityService,
        IPayementService payementService,
        IReservationRepository repository)
    {
        this.roomAvailabilityService = roomAvailabilityService;
        this.payementService = payementService;
        this.repository = repository;
    }
    public void Execute(int chambreId, int clientId, DateTime start, DateTime end, bool pay)
    {
        var reservation = Reservation.Create(chambreId, clientId, start, end, roomAvailabilityService);
        if(pay)
            reservation.Pay(payementService);
        repository.Save(reservation);
    }
}
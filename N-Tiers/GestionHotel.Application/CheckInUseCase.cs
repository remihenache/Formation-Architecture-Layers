using GestionHotel.Business;
using GestionHotel.DAL;

namespace GestionHotel.Application;

public class CheckInUseCase
{
    private readonly ReservationServices service;
    private readonly ReservationRepository repository;

    public CheckInUseCase(
        ReservationServices service, 
        ReservationRepository repository)
    {
        this.service = service;
        this.repository = repository;
    }
    public void Execute(int reservationId, bool pay)
    {
        var reservation = repository.GetById(reservationId);
        reservation = service.MarkAsArrived(reservation);
        if(pay)
            service.Pay(reservation);
        repository.Save(reservation);
    }
}
using GestionHotel.Business;
using GestionHotel.DAL;

namespace GestionHotel.Application;

public class ReservationUseCase
{
    private readonly ReservationServices service;
    private readonly ReservationRepository repository;

    public ReservationUseCase(
        ReservationServices service, 
        ReservationRepository repository)
    {
        this.service = service;
        this.repository = repository;
    }
    public void Execute(int chambreId, int clientId, DateTime start, DateTime end, bool pay)
    {
        var reservation = service.CreateReservation(chambreId, clientId,start, end);
        if(pay)
            service.Pay(reservation);
        repository.Save(reservation);
    }
}
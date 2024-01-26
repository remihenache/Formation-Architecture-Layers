using GestionHotel.DAL;

namespace GestionHotel.Business;

public class ReservationServices
{
    private readonly ReservationRepository repository;
    private readonly IPayementService payementService;

    public ReservationServices(ReservationRepository repository, IPayementService payementService)
    {
        this.repository = repository;
        this.payementService = payementService;
    }
    
    public ReservationEntity CreateReservation(int chambreId, int clientId, DateTime start, DateTime end)
    {
        if(end < start)
            throw new ArgumentException("End date must be after start date");
        if (repository.GetForRoom(chambreId, start, end).Count() != 0)
            throw new ArgumentException("Room is already booked for this period");
        return new ReservationEntity()
        {
            DateDebut = start,
            DateFin = end,
            ChambreId = chambreId,
            ClientId = clientId
        };
    }

    public void Pay(ReservationEntity reservation)
    {
        if (reservation.IsPaid)
            return;
        double amount = (reservation.DateFin - reservation.DateDebut).TotalDays * 100;
        payementService.Pay(amount);
        reservation.IsPaid = true;
    }

    public ReservationEntity MarkAsArrived(ReservationEntity reservation)
    {
        if(DateTime.Now.DayOfYear != reservation.DateDebut.DayOfYear)
            throw new ArgumentException("Reservation date doesn't match today");
        reservation.IsArrived = true;
        return reservation;
    }
}
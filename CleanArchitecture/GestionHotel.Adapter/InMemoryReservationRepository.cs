using GestionHotel.Domain;

namespace GestionHotel.Adapter;

public class InMemoryReservationRepository : IReservationRepository
{
    private List<ReservationEntity> _reservations = new List<ReservationEntity>();
    public void Save(Reservation reservation)
    {
        var entity = new ReservationEntity
        {
            ChambreId = reservation.ChambreId,
            ClientId = reservation.ClientId,
            DateDebut = reservation.Start,
            DateFin = reservation.End,
            IsPaid = reservation.IsPaid
        };
        _reservations.Add(entity);
    }

    public Reservation GetById(int id) =>
        null; //_reservations.FirstOrDefault(r => r.Id == id);
}

public class InMemoryRoomAvailability : IRoomAvailabilityService
{
    private List<ReservationEntity> _reservations = new List<ReservationEntity>();
    public bool IsAvailable(int chambreId, DateTime start, DateTime end) => 
        !_reservations.Any(r => r.ChambreId == chambreId && r.DateDebut < end && r.DateFin > start);
}
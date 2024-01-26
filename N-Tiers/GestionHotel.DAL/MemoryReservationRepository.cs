namespace GestionHotel.DAL;

public class MemoryReservationRepository : ReservationRepository
{
    private readonly List<ReservationEntity> _reservations = new();

    public void Save(ReservationEntity reservation)
    {
        _reservations.Add(reservation);
    }

    public IEnumerable<ReservationEntity> GetForRoom(int chambreId, DateTime start, DateTime end)
    {
        return _reservations.Where(r => r.ChambreId == chambreId && r.DateDebut < end && r.DateFin > start);
    }

    public ReservationEntity GetById(int reservationId) => _reservations.Single(r => r.Id == reservationId);
}
namespace GestionHotel.DAL;

public interface ReservationRepository
{
    void Save(ReservationEntity reservation);
    IEnumerable<ReservationEntity> GetForRoom(int chambreId, DateTime start, DateTime end);
    ReservationEntity GetById(int reservationId);
}
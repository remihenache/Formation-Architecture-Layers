namespace GestionHotel.Domain;

public interface IReservationRepository
{
    void Save(Reservation reservation);
    Reservation GetById(int id);
}
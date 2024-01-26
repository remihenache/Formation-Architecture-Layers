namespace GestionHotel.Domain;

public interface IRoomAvailabilityService
{
    bool IsAvailable(int chambreId, DateTime start, DateTime end);
}
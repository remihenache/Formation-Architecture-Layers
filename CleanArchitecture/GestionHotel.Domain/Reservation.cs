namespace GestionHotel.Domain;

public class Reservation
{
    public int ChambreId { get; }
    public int ClientId { get; }
    public DateTime Start { get; }
    public DateTime End { get; }
    public bool IsPaid { get; private set; }

    private Reservation(int chambreId, int clientId, DateTime start, DateTime end)
    {
        ChambreId = chambreId;
        ClientId = clientId;
        Start = start;
        End = end;
    }

    public static Reservation Create(int chambreId, int clientId, DateTime start, DateTime end, IRoomAvailabilityService roomAvailabilityService)
    {
        if(end < start)
            throw new Exception("Date de fin avant date de début");
        if(!roomAvailabilityService.IsAvailable(chambreId, start, end))
            throw new Exception("Chambre non disponible");
        return new Reservation(chambreId, clientId, start, end);
    }

    public void Pay(IPayementService payementService)
    {
        var amount = this.End.Subtract(this.Start).Days * 100.0;
        payementService.Pay(amount);
        this.IsPaid = true;
    }

}
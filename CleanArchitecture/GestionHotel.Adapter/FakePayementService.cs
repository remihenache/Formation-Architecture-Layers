using GestionHotel.Domain;

namespace GestionHotel.Adapter;

public class FakePayementService : IPayementService
{
    public void Pay(double amount)
    {
        // call paypal api
        return;
    }
}
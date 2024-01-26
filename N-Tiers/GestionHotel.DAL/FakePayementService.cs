namespace GestionHotel.DAL;

public class FakePayementService : IPayementService
{
    public void Pay(double amount)
    {
        Console.WriteLine($"Paying {amount}");
    }
}
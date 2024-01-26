using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace GestionHotel.Adapter;

public class ReservationEntity
{
    public int Id { get; set; }
    public int ClientId { get; set; }
    public int ChambreId { get; set; }
    public DateTime DateDebut { get; set; }
    public DateTime DateFin { get; set; }
    public bool IsPaid { get; set; }
    public bool IsArrived { get; set; }
}
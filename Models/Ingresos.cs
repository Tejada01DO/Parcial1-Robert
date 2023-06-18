using System.ComponentModel.DataAnnotations;

public class Ingresos
{
    [Key]
    public int IngresoId { get; set; }
    public DateTime Fecha { get; set; } = DateTime.Today;

    [Required(ErrorMessage = "El concepto es un campo obligatorio")]
    public string? Concepto { get; set; }

    [Required(ErrorMessage = "Es necesario especificar el monto")]
    [Range(minimum: 1, maximum: 50000, ErrorMessage = "El monto debe estar entre 1 a 50000")]
    public float Monto { get; set; }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CamilySolorzano.Models
{
    public class Reserva
    {
        [Key]
        public int idReserva { get; set;}
        [Required]
        public double Precio { get; set;}
        public String infCliente { get; set;}

        [ForeignKey("infCliente")]
        public Cliente? cliente { get; set; }

        [Required]
        public DateOnly fechaEntrada { get; set; }
        [Required]
        public DateOnly fechaSalida { get; set; }

        public String Recompensa { get; set;}
    }
}

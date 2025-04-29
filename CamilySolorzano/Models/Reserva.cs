using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CamilySolorzano.Models
{
    public class Reserva
    {
        [Key]
        public int idReserva { get; set;}

        //Fecha Reserva
        [Required]
        [DisplayName("Fecha Reserva")]
        public DateOnly fechaReserva { get; set; }

        //Fecha Entrada

        [Required]
        [DisplayName("Fecha Entrada")]
        public DateOnly fechaEntrada { get; set; }

        //Fecha Salida

        [Required]
        [DisplayName("Fecha Salida")]
        public DateOnly fechaSalida { get; set; }

        //Valor a Pagar
        [Required]
        [DisplayName("Valor a Pagar")]
        public double Precio { get; set;}

        //Int Cantidad de Reservas
        [Required]
        [DisplayName("Cantidad Reservas Realizadas")]
        public int cantidadReservas { get; set; }


        //FK
        //Info Cliente

        [ForeignKey("Cliente")]
        public int idCliente { get; set; }
        public Cliente? Cliente { get; set; }
    }
}

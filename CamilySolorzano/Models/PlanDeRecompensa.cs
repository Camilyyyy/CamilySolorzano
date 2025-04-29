using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CamilySolorzano.Models
{
    public class PlanDeRecompensa
    {
        [Key]
        public int idPlanRecompensa { get; set;}

        //Nombre
        [Required]
        [DisplayName("Nombre Plan Recompensa")]
        public string nombre { get; set;}
        
        //Fecha Inicio 
        [Required]
        [DisplayName("Fecha de Inicio")]
        public DateOnly FechaInicio { get; set; }

        //P.A

        [DisplayName("Puntos Acumulados")]

        public int puntosAcumulados { get; set; }

        //Categoria 
        [Required]
        [DisplayName("Categoria ")]
        public Recompensa recompensa { get; set; }

        //F.K
        [ForeignKey("Cliente")]
        public int idCliente { get; set; }
        public Cliente? Cliente { get; set; }

        //F.k
        [ForeignKey("Reserva")]
        public int idReserva { get; set; }
        public Reserva? Reserva { get; set; }

        public void CalcularRecompensa()
        {
            if (puntosAcumulados <= 500)
            {
                recompensa = Recompensa.SILVER;
            }
          else
            {
                recompensa = Recompensa.GOLD;
            }
        }

       public void Calcularpuntos()
        {
            if (Cliente != null)
            {
                puntosAcumulados = Cliente.cantidadReservas * 100;
            }
        }
        public enum Recompensa
        {
            SILVER,GOLD
        }


    }
}

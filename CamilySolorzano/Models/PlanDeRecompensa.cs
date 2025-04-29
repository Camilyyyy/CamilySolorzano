using System.ComponentModel.DataAnnotations;

namespace CamilySolorzano.Models
{
    public class PlanDeRecompensa
    {
        [Key]
        public int id { get; set;}

        [Required]
        [MaxLength(11)]
        public string idCedula { get; set;}

        [Required]
        public DateOnly FechaInicio { get; set;}

        [Required]
        public int puntosAcumulados { get; set;}


    }
}

using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CamilySolorzano.Models
{
    public class Cliente
    {
        [Key]
        public int idCliente { get; set;}

        [Required]
        [MaxLength(80)]
        public String NombreCliente { get; set;}

        [Required]
        public bool MayorEdad { get; set;}

        [Required]
        public DateOnly fecha { get; set;}

        public String CamilyS { get; set; }


    }
}

using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CamilySolorzano.Models
{
    public class Cliente
    {
        [Key]
        public int idCliente { get; set;}

        //Int
        [Required]
        [DisplayName("Edad")]
        public int Edad {  get; set;}

        //Decimal
        [Required]
        [DisplayName("Altura")]
        public decimal altura { get; set;}

        //String
        [Required]
        [StringLength(30)]
        [DisplayName("Nombre Cliente")]
        public string NombreCliente { get; set; }


        //Bool
        [Required]
        [DisplayName("Mayor de Edad")]
        public bool IsMayorEdad { get; set; }
        
        //Date
        [Required]
        [DisplayName("Fecha Nacimiento")]
        public DateOnly fechaNacimiento { get; set;}

        //Atributo Nombre
        public string camilyS { get; set; }


    }
}

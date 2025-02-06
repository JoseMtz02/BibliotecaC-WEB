using System.ComponentModel.DataAnnotations;

namespace _2_Biblioteca.Models.Domain
{
    public class Rol
    {
        [Key]
        public int PkRol {  get; set; }
        public string Nombre { get; set; }
    }
}

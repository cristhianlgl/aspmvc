using System.ComponentModel.DataAnnotations;

namespace aspmvc.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "El titulo es requerido")]
        [StringLength(50,ErrorMessage = "El campo {0} debe ser al menos de {2} y maximo {1} carateres")]
        [Display(Name ="Titulo")]
        public string Title { get; set; }

        [Required(ErrorMessage = "El autor es requerido")]
        public string Author { get; set; }
        
        [Required(ErrorMessage = "La Fecha es requerido")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha publicaccion")]
        public DateTime PublicationDate { get; set; }
    }
}

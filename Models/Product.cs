using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment_12._1.Models
{
    public class Product    //Step 1. Add Model //product class with properties
    {
        [Display(Name="Product Id") ]
        [Required(ErrorMessage = "Product Id required.")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]   //None indicates that the database will not generate its own Id field column. This will make this Id the unique primary key
        public int Id { get; set; }
        [Display(Name="Product Name")]
        [Required(ErrorMessage ="Product name required.")]
        [AllLetters(ErrorMessage ="Please enter letters only.")]    //custom validation
        public string? Name { get; set; }

        [Display(Name ="Product Description")]
        [DataType(DataType.MultilineText)]
        [MaxLength(255, ErrorMessage ="Description exceeds max length (255 characters).")]
        public string? Description { get; set; }

        [DataType(DataType.Currency)]
        public double Price { get; set; }
        public string? ImageName { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;

namespace BulkyBook.Model
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Display(Name = "Display Order")] // to put same Name on View Web
        [Range(1,100,ErrorMessage ="DisPlay must be on 1 to 100 !!")]
        public int DisplayOrder { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
        public ICollection<Product> Products { get; set; }
    }
}


using System.ComponentModel.DataAnnotations;


namespace RecipeWebsite.Models
{
    public class UploadImages
    {
        [Key]
        public int ImageId { get; set; }
        public byte[] Image{get; set;}
   
        public int RecipeId { get; set; }
        public virtual Recipe Recipe { get; set; }

}
}

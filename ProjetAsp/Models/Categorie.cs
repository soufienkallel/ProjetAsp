using System.ComponentModel.DataAnnotations;

namespace ProjetAsp.Models
{
    public class Categorie
    {
        [Key]
        public int CatID { get; set; }
        public string CatName { get; set;}
    }
}

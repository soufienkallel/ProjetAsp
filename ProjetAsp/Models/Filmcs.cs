using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetAsp.Models
{
    public class Film
    {
        [Key]
        public int FilmId { get; set; }
        public string FilmName { get; set; }
        public string FilmDescription { get; set; }
        public string Image { get; set; }
        public string Trailer { get; set; }
        public int CatID { get; set; }

        [ForeignKey(nameof(CatID))]
        public Categorie Categorie { get; set; }

    }
}

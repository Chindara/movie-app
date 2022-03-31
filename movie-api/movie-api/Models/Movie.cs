using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace movie.api.Models
{
    [Table("Movie")]
    public class Movie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        [Required]
        [MaxLength(150)]
        public string Title { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        [MaxLength(5)]
        public string Rated { get; set; }

        [Required]
        public DateTime Released { get; set; }

        [Required]
        public int Runtime { get; set; }

        [Required]
        [MaxLength(50)]
        public string Genre { get; set; }

        [MaxLength(50)]
        public string Director { get; set; }

        [MaxLength(50)]
        public string Writer { get; set; }

        [MaxLength(500)]
        public string Actors { get; set; }

        [MaxLength(500)]
        public string Plot { get; set; }

        [MaxLength(100)]
        public string Language { get; set; }

        public string Poster { get; set; }
    }
}
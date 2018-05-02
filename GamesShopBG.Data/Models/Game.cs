namespace GamesShopBG.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Game
    {
        public int Id { get; set; }

        [Required]
        [MinLength(DataConstants.GamesTitleMinLenght)]
        [MaxLength(DataConstants.GamesTitleMaxLenght)]
        public string Title { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        //In GB
        [Range(0, double.MaxValue)]
        public double Size { get; set; }

        [Required]
        [MinLength(DataConstants.GamesVideoIdMinAndMaxLenght)]
        [MaxLength(DataConstants.GamesVideoIdMinAndMaxLenght)]
        public string VideoUrl { get; set; }

        [MaxLength(DataConstants.GamesThumbnailMaxLenght)]
        public string ThumbnailUrl { get; set; }

        [Required]
        [MinLength(DataConstants.GamesDescriptionMinLenght)]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        public virtual ICollection<Order> Order { get; set; } = new List<Order>();
    }
}

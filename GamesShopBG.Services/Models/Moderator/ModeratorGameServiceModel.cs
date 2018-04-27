namespace GamesShopBG.Services.Models.Moderator
{
    using GamesShopBG.Data;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ModeratorGameServiceModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(DataConstants.GamesTitleMinLenght, ErrorMessage = "Title minimum length is 3")]
        [MaxLength(DataConstants.GamesTitleMaxLenght, ErrorMessage = "Title maximum length is 100")]
        public string Title { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        //In GB
        [Range(0, double.MaxValue)]
        public double Size { get; set; }

        [Required]
        [MinLength(DataConstants.GamesvideoUrlMinAndMaxLenght)]
        [MaxLength(DataConstants.GamesvideoUrlMinAndMaxLenght)]
        [Display(Name = "YouTube Video Id")]
        public string videoUrl { get; set; }

        [Required]
        [Display(Name = "Thumbnail URL")]
        [MaxLength(DataConstants.GamesThumbnailMaxLenght, ErrorMessage = "Thumbnail URL max lenght is 2047")]
        public string ThumbnailUrl { get; set; }

        [Required]
        [MinLength(DataConstants.GamesDescriptionMinLenght, ErrorMessage = "Description minimum length is 20")]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

    }
}

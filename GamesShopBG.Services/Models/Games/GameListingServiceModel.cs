namespace GamesShopBG.Services.Models.Games
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class GameListingServiceModel
    {
        public int Id { get; set; }

        public string Title { get; set; }
        
        public decimal Price { get; set; }
        
        public double Size { get; set; }
        
        public string ThumbnailUrl { get; set; }
        
        public string Description { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }
    }
}

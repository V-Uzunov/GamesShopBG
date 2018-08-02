namespace GamesShopBG.Services.Models.Admin
{
    using GamesShopBG.Services.Models.Order;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class AdminOrdersWithUserInfo
    {
        [Display(Name = "First name")]
        public string FirstName { get; set; }
        
        [Display(Name = "Last name")]
        public string LastName { get; set; }
        
        [Display(Name = "Address Line")]
        public string AddressLine { get; set; }
        
        [Display(Name = "Zip code")]
        public string ZipCode { get; set; }
        
        public string City { get; set; }
        
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }
        
        public string Email { get; set; }

        public decimal OrderTotal { get; set; }

        public DateTime OrderDate { get; set; }

        public IEnumerable<OrderDetailsServiceModel> OrderDetails { get; set; }
    }
}

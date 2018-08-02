namespace GamesShopBG.Services.Models.Admin
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class AdminOrdersWithUserInfo
    {
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        
        [Display(Name = "Address Line")]
        public string AddressLine { get; set; }
        
        [Display(Name = "Zip code")]
        public string ZipCode { get; set; }
        
        public string City { get; set; }
        
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }
        
        public string Email { get; set; }

        [Display(Name = "Total Price")]
        public decimal OrderTotal { get; set; }

        [Display(Name = "Order Date")]
        public DateTime OrderDate { get; set; }

        public IEnumerable<AdminOrderDetailsServiceModel> OrderDetails { get; set; }
    }
}

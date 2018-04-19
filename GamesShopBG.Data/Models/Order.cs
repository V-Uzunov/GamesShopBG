using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GamesShopBG.Data.Models
{
    public class Order
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Please enter your first name")]
        [Display(Name = "First name")]
        [StringLength(DataConstants.OrderFirstNameMaxLenght)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your last name")]
        [Display(Name = "Last name")]
        [StringLength(DataConstants.OrderLastNameMaxLenght)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter your address")]
        [StringLength(DataConstants.OrderAdressLineMaxLenght)]
        [Display(Name = "Address Line")]
        public string AddressLine { get; set; }
        
        [Required(ErrorMessage = "Please enter your zip code")]
        [Display(Name = "Zip code")]
        [StringLength(DataConstants.OrderZipCodeMaxLenght, MinimumLength = DataConstants.OrderZipCodeMinLenght)]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "Please enter your city")]
        [StringLength(DataConstants.OrderCityMaxLenght)]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter your phone number")]
        [StringLength(DataConstants.OrderPhoneNumberMaxLenght)]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(DataConstants.OrderEmailMaxLenght)]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(DataConstants.OrderEmailRegEx,
            ErrorMessage = "The email address is not entered in a correct format")]
        public string Email { get; set; }
        
        public decimal OrderTotal { get; set; }
        
        public DateTime OrderPlaced { get; set; }

        public virtual ICollection<OrderDetail> OrderLines { get; set; } = new List<OrderDetail>();
    }
}

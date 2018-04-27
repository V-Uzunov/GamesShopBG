namespace GamesShopBG.Data
{
    public class DataConstants
    {
        public const int UserMinLenght = 3;
        public const int UserMaxLenght = 100;

        public const int GamesTitleMinLenght = 3;
        public const int GamesTitleMaxLenght = 100;
        public const int GamesvideoUrlMinAndMaxLenght = 2048;
        public const int GamesThumbnailMaxLenght = 2047;
        public const int GamesDescriptionMinLenght = 20;

        public const int OrderFirstNameMaxLenght = 50;
        public const int OrderLastNameMaxLenght = 50;
        public const int OrderAdressLineMaxLenght = 100;
        public const int OrderZipCodeMinLenght = 4;
        public const int OrderZipCodeMaxLenght = 10;
        public const int OrderCityMaxLenght = 50;
        public const int OrderPhoneNumberMaxLenght = 25;
        public const int OrderEmailMaxLenght = 50;

        public const string OrderEmailRegEx = @"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])";
    }
}

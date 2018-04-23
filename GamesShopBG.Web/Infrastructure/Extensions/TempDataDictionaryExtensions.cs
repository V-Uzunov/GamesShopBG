namespace GamesShopBG.Web.Infrastructure.Extensions
{
    using System.Web.Mvc;
    using GamesShopBG.Web.Infrastructure.WebConstants;
    public static class TempDataDictionaryExtensions
    {
        public static void AddSuccessMessage(this TempDataDictionary tempData, string message)
        {
            tempData[WebConstants.TempDataSuccessMessageKey] = message;
        }

        public static void AddErrorMessage(this TempDataDictionary tempData, string message)
        {
            tempData[WebConstants.TempDataErrorMessageKey] = message;
        }
    }
}
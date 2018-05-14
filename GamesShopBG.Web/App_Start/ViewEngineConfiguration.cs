namespace GamesShopBG.Web.App_Start
{
    using System.Web.Mvc;

    public class ViewEngineConfiguration
    {
        internal static void RegisterViewEngine(ViewEngineCollection engines)
        {
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());
        }
    }
}
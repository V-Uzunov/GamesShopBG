namespace GamesShopBG.Common.Mapping
{
    using AutoMapper;

    public interface IHaveCustomMapping
    {
        void CreateMappings(IConfigurationProvider configuration);
    }
}

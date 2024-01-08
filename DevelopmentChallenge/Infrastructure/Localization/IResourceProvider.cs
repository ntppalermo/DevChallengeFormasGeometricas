namespace DevelopmentChallenge.Infrastructure.Localization
{
    public interface IResourceProvider
    {
        string GetResourceString(string key, Idioma idioma);
    }
}

namespace DevelopmentChallenge.Infrastructure.Localization
{
    public class IdiomaManagerResourceProvider : IResourceProvider
    {
        public string GetResourceString(string key, Idioma idioma)
        {
            return IdiomaManager.GetResourceString(key, idioma);
        }
    }
}

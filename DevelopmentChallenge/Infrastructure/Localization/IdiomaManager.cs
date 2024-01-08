using System.Globalization;
using System.Resources;

namespace DevelopmentChallenge.Infrastructure.Localization
{
    public static class IdiomaManager
    {
        private static readonly ResourceManager resourceManager = new("DevelopmentChallenge.Infrastructure.Resources.Resource", typeof(IdiomaManager).Assembly);
        public static ResourceManager ResourceManager => resourceManager;

        public static string GetResourceString(string key, Idioma idioma)
        {
            CultureInfo cultura = GetCulture(idioma);
            return resourceManager.GetString(key, cultura) ?? key;
        }

        public static CultureInfo GetCulture(Idioma idioma)
        {
            string idiomaCode = GetLanguageCode(idioma);
            return CultureInfo.GetCultureInfo(idiomaCode);
        }
        public static string GetLanguageCode(Idioma idioma)
        {
            return idioma switch
            {
                Idioma.Castellano => "es",
                Idioma.Ingles => "en",
                Idioma.Italiano => "it",
                _ => "es"
            };
        }
    }
}

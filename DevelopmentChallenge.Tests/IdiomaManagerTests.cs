using DevelopmentChallenge.Infrastructure.Localization;
using System.Globalization;

namespace DevelopmentChallenge.Tests
{
    [TestFixture]
    public class IdiomaManagerTests
    {
        [Test]
        public void TestGetResourceStringEnCastellano()
        {
            string resultado = IdiomaManager.GetResourceString("Total", Idioma.Castellano);
            Assert.That(resultado, Is.EqualTo("TOTAL:<br/>"));
        }

        [Test]
        public void TestGetResourceStringEnIngles()
        {
            string resultado = IdiomaManager.GetResourceString("Forma_desconocida", Idioma.Ingles);
            Assert.That(resultado, Is.EqualTo("Unknow Shape"));
        }

        [Test]
        public void TestGetResourceStringEnItaliano()
        {
            string resultado = IdiomaManager.GetResourceString("ListaVacia", Idioma.Italiano);
            Assert.That(resultado, Is.EqualTo("<h1>Elenco vuoto di forme!</h1>"));
        }

        [Test]
        public void TestGetResourceStringClaveInexistente()
        {
            string resultado = IdiomaManager.GetResourceString("ClaveInexistente", Idioma.Castellano);
            Assert.That(resultado, Is.EqualTo("ClaveInexistente"));
            Assert.That(resultado, Is.Not.Null.Or.Empty);
        }

        [Test]
        public void TestGetCultureEnCastellano()
        {
            CultureInfo cultura = IdiomaManager.GetCulture(Idioma.Castellano);
            Assert.That(cultura.Name, Is.EqualTo("es"));
        }
    }
}

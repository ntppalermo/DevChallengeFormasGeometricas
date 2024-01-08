using DevelopmentChallenge.Application.Interfaces;
using DevelopmentChallenge.Application.UseCases;
using DevelopmentChallenge.Domain.Entities;
using DevelopmentChallenge.Infrastructure.Localization;

namespace DevelopmentChallenge.Data.Tests
{
    [TestFixture]
    public class DataTests
    {
        private IReporteFormasUseCase _reporteFormasUseCase;

        [SetUp]
        public void SetUp()
        {
            _reporteFormasUseCase = new ReporteFormasUseCase(new IdiomaManagerResourceProvider());
        }

        [TestCase]
        public void TestResumenListaVacia()
        {
            List<FormaGeometrica> formasGeometricas = new();

            var resumen = GenerarReporte(formasGeometricas, Idioma.Castellano);

            Assert.That(resumen, Is.EqualTo("<h1>�Lista vac�a de formas!</h1>"));
        }

        [TestCase]
        public void TestResumenListaVaciaFormasEnIngles()
        {
            List<FormaGeometrica> formasGeometricas = new();

            var resumen = GenerarReporte(formasGeometricas, Idioma.Ingles);

            Assert.That(resumen, Is.EqualTo("<h1>Empty list of shapes!</h1>"));

        }

        [TestCase]
        public void TestResumenListaConUnCuadrado()
        {
            List<FormaGeometrica> formasGeometricas = new()
                {
                    new Cuadrado(5)
                };

            var resumen = GenerarReporte(formasGeometricas, Idioma.Castellano);

            Assert.That(resumen, Is.EqualTo("<h1>Reporte de Formas</h1>1 Cuadrado | �rea 25 | Per�metro 20 <br/>TOTAL:<br/>1 Formas Per�metro 20 �rea 25"));
        }

        [TestCase]
        public void TestResumenListaConMasCuadrados()
        {
            List<FormaGeometrica> formasGeometricas = new()
                {
                    new Cuadrado(5),
                    new Cuadrado(1),
                    new Cuadrado(3)
                };

            var resumen = GenerarReporte(formasGeometricas, Idioma.Ingles);

            Assert.That(resumen, Is.EqualTo("<h1>Shapes Report</h1>3 Squares | Area 35 | Perimeter 36 <br/>TOTAL:<br/>3 Shapes Perimeter 36 Area 35"));
        }

        [TestCaseSource(nameof(DatosFormasGeometricas))]
        public void TestResumenListaConMasTipos(List<FormaGeometrica> formasGeometricas)
        {
            var resumen = GenerarReporte(formasGeometricas, Idioma.Ingles);
            Assert.That(resumen, Is.EqualTo("<h1>Shapes Report</h1>2 Squares | Area 29 | Perimeter 28 <br/>2 Circles | Area 52,03 | Perimeter 36,13 <br/>3 Triangles | Area 49,64 | Perimeter 51,6 <br/>TOTAL:<br/>7 Shapes Perimeter 115,73 Area 130,67"));
        }

        [TestCaseSource(nameof(DatosFormasGeometricas))]
        public void TestResumenListaConMasTiposEnCastellano(List<FormaGeometrica> formasGeometricas)
        {
            var resumen = GenerarReporte(formasGeometricas, Idioma.Castellano);
            Assert.That(resumen, Is.EqualTo("<h1>Reporte de Formas</h1>2 Cuadrados | �rea 29 | Per�metro 28 <br/>2 C�rculos | �rea 52,03 | Per�metro 36,13 <br/>3 Tri�ngulos | �rea 49,64 | Per�metro 51,6 <br/>TOTAL:<br/>7 Formas Per�metro 115,73 �rea 130,67"));
        }

        [TestCase]
        public void TestResumenListaConUnCirculo()
        {
            List<FormaGeometrica> formasGeometricas = new()
            {
                new Circulo(3)
            };

            var resumen = GenerarReporte(formasGeometricas, Idioma.Ingles);

            Assert.That(resumen, Is.EqualTo("<h1>Shapes Report</h1>1 Circle | Area 28,27 | Perimeter 18,85 <br/>TOTAL:<br/>1 Shapes Perimeter 18,85 Area 28,27"));
        }

        [TestCase]
        public void TestResumenListaConTrianguloYCuadrado()
        {
            List<FormaGeometrica> formasGeometricas = new()
            {
                new TrianguloEquilatero(4),
                new Cuadrado(2)
            };

            var resumen = GenerarReporte(formasGeometricas, Idioma.Castellano);

            Assert.That(resumen, Is.EqualTo("<h1>Reporte de Formas</h1>1 Tri�ngulo | �rea 6,93 | Per�metro 12 <br/>1 Cuadrado | �rea 4 | Per�metro 8 <br/>TOTAL:<br/>2 Formas Per�metro 20 �rea 10,93"));
        }

        private static IEnumerable<List<FormaGeometrica>> DatosFormasGeometricas()
        {
            yield return new List<FormaGeometrica>
                {
                    new Cuadrado(5),
                    new Circulo(3),
                    new TrianguloEquilatero(4),
                    new Cuadrado(2),
                    new TrianguloEquilatero(9),
                    new Circulo(2.75m),
                    new TrianguloEquilatero(4.2m)
                };
        }
        private string GenerarReporte(List<FormaGeometrica> formasGeometricas, Idioma idioma)
        {
            return _reporteFormasUseCase.GenerarReporte(formasGeometricas, idioma);
        }
    }
}
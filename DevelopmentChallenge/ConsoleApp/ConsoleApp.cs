using DevelopmentChallenge.Application.Interfaces;
using DevelopmentChallenge.Domain.Entities;
using DevelopmentChallenge.Infrastructure.Localization;
using Microsoft.Extensions.Logging;

namespace DevelopmentChallenge.ConsoleApp
{
    public class ConsoleApp
    {
        private readonly IReporteFormasUseCase reporteFormasUseCase;
        private readonly ILogger<ConsoleApp> logger;

        public ConsoleApp(IReporteFormasUseCase reporteFormasUseCase, ILogger<ConsoleApp> logger)
        {
            this.reporteFormasUseCase = reporteFormasUseCase;
            this.logger = logger;
        }
        public void Run()
        {
            try
            {
                var formas = new List<FormaGeometrica>
                {
                    new Cuadrado(5),
                    new Circulo(3),
                    new TrianguloEquilatero(3)
                };

                ImprimirReportes(formas);
                logger.LogInformation("La aplicación se ejecutó correctamente.");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Ocurrió un error durante la ejecución de la aplicación.");
            }
        }

        private void ImprimirReportes(List<FormaGeometrica> formas)
        {
            ImprimirReporte(Idioma.Castellano, formas);
            ImprimirReporte(Idioma.Ingles, formas);
            ImprimirReporte(Idioma.Italiano, formas);
        }
        private void ImprimirReporte(Idioma idioma, List<FormaGeometrica> formas)
        {
            Console.WriteLine(reporteFormasUseCase.GenerarReporte(formas, idioma));
        }
    }
}

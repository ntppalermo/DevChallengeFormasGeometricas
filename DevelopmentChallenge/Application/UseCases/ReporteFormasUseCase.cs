using DevelopmentChallenge.Application.Interfaces;
using DevelopmentChallenge.Domain.Entities;
using DevelopmentChallenge.Infrastructure.Localization;
using DevelopmentChallenge.Infrastructure.Presenters;

namespace DevelopmentChallenge.Application.UseCases
{
    public class ReporteFormasUseCase : IReporteFormasUseCase
    {
        private readonly IResourceProvider _resourceProvider;

        public ReporteFormasUseCase(IResourceProvider resourceProvider)
        {
            _resourceProvider = resourceProvider;
        }

        public string GenerarReporte(List<FormaGeometrica> formas, Idioma idioma)
        {
            var presenter = new ReporteFormasPresenter(_resourceProvider);
            return presenter.Imprimir(formas, idioma);
        }
    }
}

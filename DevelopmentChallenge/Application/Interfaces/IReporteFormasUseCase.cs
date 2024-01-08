using DevelopmentChallenge.Domain.Entities;
using DevelopmentChallenge.Infrastructure.Localization;

namespace DevelopmentChallenge.Application.Interfaces
{
    public interface IReporteFormasUseCase
    {
        string GenerarReporte(List<FormaGeometrica> formas, Idioma idioma);
    }
}

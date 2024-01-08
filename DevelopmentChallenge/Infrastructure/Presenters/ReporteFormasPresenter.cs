using DevelopmentChallenge.Domain.Entities;
using System.Text;
using DevelopmentChallenge.Infrastructure.Localization;


namespace DevelopmentChallenge.Infrastructure.Presenters
{
    public  class ReporteFormasPresenter
    {
        private readonly IResourceProvider _resourceProvider;

        public ReporteFormasPresenter(IResourceProvider resourceProvider)
        {
            _resourceProvider = resourceProvider;
        }
     
        public string Imprimir(List<FormaGeometrica> formas, Idioma idioma)
        {

            var sb = new StringBuilder();

            sb.Append(!formas.Any()
                ? _resourceProvider.GetResourceString("ListaVacia", idioma)
                : GenerarReporteFormas(formas, idioma));

            return sb.ToString();
        }

        private string GenerarReporteFormas(List<FormaGeometrica> formas, Idioma idioma)
        {
            StringBuilder sb = new();

            sb.Append(_resourceProvider.GetResourceString("ReporteFormas", idioma));

            var formasAgrupadas = formas.GroupBy(f => f.GetType());

            sb.AppendJoin(string.Empty, formasAgrupadas.Select(grupo =>
            {
                return ObtenerLineaPorGrupo(grupo, idioma);
            }));

            sb.Append(ConstruirFooter(formas, idioma));

            return sb.ToString();
        }

        private string ObtenerLineaPorGrupo(IGrouping<Type, FormaGeometrica> grupo, Idioma idioma)
        {
            int cantidad = grupo.Count();
            decimal areaTotal = grupo.Sum(f => f.CalcularArea());
            decimal perimetroTotal = grupo.Sum(f => f.CalcularPerimetro());

            return ObtenerLinea(cantidad, areaTotal, perimetroTotal, grupo.First(), idioma);
        }

        private string ConstruirFooter(List<FormaGeometrica> formas, Idioma idioma)
        {
            int numeroCuadrados = formas.Count(f => f is Cuadrado);
            int numeroCirculos = formas.Count(f => f is Circulo);
            int numeroTriangulos = formas.Count(f => f is TrianguloEquilatero);

            decimal perimetroTotal = formas.Sum(f => f.CalcularPerimetro());
            decimal areaTotal = formas.Sum(f => f.CalcularArea());

            return $"{_resourceProvider.GetResourceString("Total", idioma)}" +
                   $"{formas.Count} {_resourceProvider.GetResourceString("Formas", idioma)} " +
                   $"{_resourceProvider.GetResourceString("Perimetro", idioma)} {perimetroTotal:#.##} " +
                   $"{_resourceProvider.GetResourceString("Area", idioma)} {areaTotal:#.##}";
        }

        private string ObtenerLinea(int cantidad, decimal area, decimal perimetro, FormaGeometrica forma, Idioma idioma)
        {
            return $"{cantidad} {TraducirForma(forma, cantidad, idioma)} | {_resourceProvider.GetResourceString("Area", idioma)} {area:#.##} | {_resourceProvider.GetResourceString("Perimetro", idioma)} {perimetro:#.##} <br/>";
        }

        private string TraducirForma(FormaGeometrica forma, int cantidad, Idioma idioma)
        {
            string nombreATraducir = cantidad switch
            {
                1 => forma.NombreSingular,
                _ => forma.NombrePlural
            };

            return _resourceProvider.GetResourceString(nombreATraducir, idioma);
        }
    }
}


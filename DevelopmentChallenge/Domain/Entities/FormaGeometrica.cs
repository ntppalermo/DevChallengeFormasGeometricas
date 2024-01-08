
namespace DevelopmentChallenge.Domain.Entities
{
    public abstract class FormaGeometrica
    {
        public abstract string NombreSingular { get; }
        public abstract string NombrePlural { get; }

        public abstract decimal CalcularArea();
        public abstract decimal CalcularPerimetro();
    }
}

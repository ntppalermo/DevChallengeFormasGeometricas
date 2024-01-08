namespace DevelopmentChallenge.Domain.Entities
{
    public class TrianguloEquilatero : FormaGeometrica
    {
        public TrianguloEquilatero(decimal lado)
        {
            Lado = lado;
        }
        public override string NombreSingular => "TrianguloEquilatero";
        public override string NombrePlural => "TriangulosEquilateros";
        public decimal Lado { get; }
        public override decimal CalcularArea() => (decimal)Math.Sqrt(3) / 4 * Lado * Lado;
        public override decimal CalcularPerimetro() =>  Lado * 3;
    }
}

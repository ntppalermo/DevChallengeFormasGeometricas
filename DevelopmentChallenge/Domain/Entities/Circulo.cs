namespace DevelopmentChallenge.Domain.Entities
{
    public class Circulo : FormaGeometrica
    {
        public Circulo(decimal radio)
        {
            Radio = radio;
        }

        public override string NombreSingular => "Circulo";
        public override string NombrePlural => "Circulos";

        public decimal Radio { get; }
        public override decimal CalcularArea() => (decimal) Math.PI * Radio* Radio;
        public override decimal CalcularPerimetro() => 2 * (decimal)Math.PI * Radio;
    }
}
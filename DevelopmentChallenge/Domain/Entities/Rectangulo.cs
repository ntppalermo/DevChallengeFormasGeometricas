namespace DevelopmentChallenge.Domain.Entities
{
    public class Rectangulo : FormaGeometrica
    {
        public Rectangulo(decimal lado1, decimal lado2)
        {
            Lado1 = lado1;
            Lado2 = lado2;
        }

        public override string NombreSingular => "Rectangulo";
        public override string NombrePlural => "Rectangulos";
        public decimal Lado1 { get; }
        public decimal Lado2 { get; }
        public override decimal CalcularArea() => Lado1 * Lado2;
        public override decimal CalcularPerimetro() => 2 * (Lado1 + Lado2);
    }
}

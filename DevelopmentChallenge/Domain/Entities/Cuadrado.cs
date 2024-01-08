namespace DevelopmentChallenge.Domain.Entities
{
    public class Cuadrado : FormaGeometrica
    {
        public Cuadrado(decimal lado)
        {
            Lado = lado;
        }

        public override string NombreSingular => "Cuadrado";
        public override string NombrePlural => "Cuadrados";
        public decimal Lado { get;}
        public override decimal CalcularArea() => Lado * Lado;
        public override decimal CalcularPerimetro() => Lado * 4;
    }
}

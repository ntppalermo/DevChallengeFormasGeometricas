using System;
using System.Collections.Generic;
namespace DevelopmentChallenge.Domain.Entities
{
    public class Trapecio : FormaGeometrica
    {
        public Trapecio(decimal baseMayor, decimal baseMenor, decimal altura, decimal lado1, decimal lado2)
        {
            BaseMayor = baseMayor;
            BaseMenor = baseMenor;
            Altura = altura;
            Lado1 = lado1;
            Lado2 = lado2;
        }

        public override string NombreSingular => "Trapecio";
        public override string NombrePlural => "Trapecios";
        public decimal BaseMayor { get; }
        public decimal BaseMenor { get; }
        public decimal Altura { get; }
        public decimal Lado1 { get; }
        public decimal Lado2 { get; }

        public override decimal CalcularArea() => (BaseMayor + BaseMenor) * Altura / 2;
        public override decimal CalcularPerimetro() => BaseMayor + BaseMenor + Lado1 + Lado2;
    }
}

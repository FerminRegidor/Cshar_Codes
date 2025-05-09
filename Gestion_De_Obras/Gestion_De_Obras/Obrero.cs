using System;

namespace Reparar
{
    internal class Obrero : Empleado
    {
        public string Categoria {  get; set; }
        public decimal Sueldo 
        { get 
            {
                return Categoria.ToLower() switch
                {
                    "oficial" => Sueldos.MontoReferencia,
                    "mediooficial" => Sueldos.MontoReferencia * 0.65m,
                    "aprendiz" => Sueldos.MontoReferencia * 0.25m,
                    _ => 0
                };
            } 
        }
    }
}

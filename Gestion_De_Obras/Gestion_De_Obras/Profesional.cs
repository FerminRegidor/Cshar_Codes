using System;

namespace Reparar
{
    internal class Profesional : Empleado
    {
        public string Titulo { get; set; }
        public string Matricula { get; set; }
        public string Consejo { get; set; }
        public decimal Porcentaje_Propio {  get; set; }
        public bool Supervisando { get; set; } // si/no
        public decimal Sueldo 
        {
            get
            {
                if (Supervisando == false)
                {
                    return Sueldos.MontoReferencia * (1 + Porcentaje_Propio);
                }
                else
                {
                    return (Sueldos.MontoReferencia + Sueldos.CanonMatricula) * (1 + Porcentaje_Propio);
                }
            }
        }
    }
}

using System;

namespace Viajes
{
    internal class CViajes
    {
        private float precio_kilometraje; // precio por kilometro recorrido
        private ushort kilometraje_minimo; // kilometraje minimo de cada viaje con el que si el viaje fue menor a este minimo, se le cobrara lo minimo en kilometro * precio de kilometraje
        private string dominio; // patente del viaje
        private ushort kilometraje_recorrido; // kilometros recorridos
        private ushort peajes; // la suma total de los peajes cobrados


        public CViajes()
        {
            precio_kilometraje = 0;
            kilometraje_minimo = 0;
            dominio = " ";
            kilometraje_recorrido = 0;
        }
        public CViajes(float precio_kilometraje, ushort kilometraje_minimo, string dominio, ushort kilometraje_recorrido, ushort peajes)
        {
            this.precio_kilometraje = precio_kilometraje;
            this.kilometraje_minimo = kilometraje_minimo;
            this.dominio = dominio;
            this.kilometraje_recorrido = kilometraje_recorrido;
            this.peajes = peajes;
        }
        // Retornos
        public float RetornoPrecioKilometraje()
        {
            return precio_kilometraje;
        } 
        public ushort RetornoKilometrajeMinimo()
        {
            return kilometraje_minimo;
        }
        public string RetornoDominio()
        {
            return dominio;
        }
        public ushort RetornoKilometrajeRecorrido()
        {
            return kilometraje_recorrido;
        }
        public ushort RetornoPeajes()
        {
            return peajes;
        }

        // Precios
        public float precio_viaje_sin_peajes()
        {
            if(kilometraje_recorrido < kilometraje_minimo)
            {
                return precio_kilometraje * kilometraje_minimo;
            }
            else
            {
                return precio_kilometraje * kilometraje_recorrido;
            }
        }
        public float precio_viaje_con_peajes()
        {
            if (kilometraje_recorrido < kilometraje_minimo)
            {
                return (precio_kilometraje * kilometraje_minimo) + peajes;
            }
            else
            {
                return (precio_kilometraje * kilometraje_recorrido) + peajes;
            }
        }
    }
}

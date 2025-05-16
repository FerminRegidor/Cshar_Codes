using System;

namespace Viajes
{
    class Program
    {
        private static Viajes sucursal = new Viajes();
        static void Main(string[] args)
        {
            Console.WriteLine(">>Inicio del programa.");
            Console.ReadKey();
            sucursal.Carga();
            sucursal.Impresion();
            sucursal.Mayor();
        }
    }
    class Viajes
    {
        private List<CViajes> viajes = new List<CViajes>();
        public void Carga()
        {
            Console.WriteLine();
            Console.WriteLine(">>Carga de datos:");
            Console.WriteLine("Ingrese el precio por kilometro: ");
            float precio_kilometraje = float.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el kilometraje minimo: ");
            ushort kilometraje_minimo = ushort.Parse(Console.ReadLine());
            bool flagWhile = false;

            do
            {
                Console.WriteLine("Patente del viaje (Ingresar 'FIN' si no desea ingresar mas viajes): ");
                string dominio = Console.ReadLine();
                if (dominio == "FIN")
                {
                    flagWhile = true;
                }
                if (string.IsNullOrEmpty(dominio))
                {
                    Console.WriteLine("Ingrese un valor valido...");
                }
                else if (flagWhile != true)
                {
                    Console.WriteLine("Kilometros recorridos: ");
                    ushort kilometraje_recorrido = ushort.Parse(Console.ReadLine());
                    Console.WriteLine("Peajes (La suma total de los peajes cobrados):");
                    ushort peajes = ushort.Parse(Console.ReadLine());
                    viajes.Add(new CViajes(precio_kilometraje, kilometraje_minimo, dominio, kilometraje_recorrido, peajes));
                    Console.WriteLine("Ingreso exitoso!");
                }
            } while (flagWhile != true);
        }
        public void Impresion()
        {
            Console.WriteLine(">>Impresion de datos:");
            if(viajes.Count == 0)
            {
                Console.WriteLine("No se ingresaron viajes validos...");
            }
            foreach(CViajes cvi in viajes)
            {
                Console.WriteLine($"Precio kilometraje: {cvi.RetornoPrecioKilometraje} - Kilometraje minimo: {cvi.RetornoKilometrajeMinimo} - Patente: {cvi.RetornoDominio} - Kilometraje recorrido: {cvi.RetornoKilometrajeRecorrido}");
                Console.WriteLine($"Precio total del viaje (sin peajes): {cvi.precio_viaje_sin_peajes} ");
                Console.WriteLine($"Precio total del viaje (con peajes): {cvi.precio_viaje_con_peajes} ");
            }
        }
        public void Mayor()
        {
            string mayor = " ";
            float mayorPrecio = 0;
            foreach(CViajes cvi in viajes)
            {
                if(cvi.precio_viaje_sin_peajes() > mayorPrecio)
                {
                    mayorPrecio = cvi.precio_viaje_sin_peajes();
                    mayor = cvi.RetornoDominio();
                }
            }
            foreach(CViajes cvi in viajes) // sergundo foreach para buscar al mayor por la patente y llamar a su impresion
            {
                if(cvi.RetornoDominio() == mayor)
                {
                    Console.WriteLine("Impresion del viaje mas caro:");
                    Console.WriteLine($"Precio kilometraje: {cvi.RetornoPrecioKilometraje} - Kilometraje minimo: {cvi.RetornoKilometrajeMinimo} - Patente: {cvi.RetornoDominio} - Kilometraje recorrido: {cvi.RetornoKilometrajeRecorrido}");
                    Console.WriteLine($"Precio total del viaje (sin peajes): {cvi.precio_viaje_sin_peajes} ");
                }
            }
        }
    }
}
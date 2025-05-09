using System;
using System.ComponentModel;

namespace Reparar
{
    internal class Gestion_De_Obras
    {
        private List<Empleado> empleados = new List<Empleado>();
        private List<Obra> obras = new List<Obra>();
        public void Iniciar()
        {
            Console.Write("--- BIENVENIDO A LA GESTION DE OBRAS ---");
            bool detener = false;
            while(detener != true)
            {
                Console.Clear();
                Console.WriteLine("--- MENU DE OPCIONES ---");
                Console.WriteLine("o# 1. Ingresar un nuevo empleado");
                Console.WriteLine("o# 2. Ingresar una nueva obra");
                Console.WriteLine("o# 3. Cambiar sueldos");
                Console.WriteLine("o# 4. Listar empleados");
                Console.WriteLine("o# 5. Salir");
                byte Opcion = byte.Parse(Console.ReadLine());
                switch(Opcion)
                {
                    case 1: 
                        Ingresar_Empleado();
                        break;
                    case 2:
                        Ingresar_Nueva_Obra();
                        break;
                    case 4:
                        Listar_Empleados();
                        break;
                    case 5: detener = true;
                        break;
                    default: 
                        Console.WriteLine("Opcion invalida.");
                        Console.ReadKey();
                        Console.Clear();
                        detener = true;
                        break;
                } 
            }
        }
        public void Ingresar_Empleado()
        {
            Console.Clear();
            Console.WriteLine("--- INGRESO DE NUEVO EMPLEADO ---");
            Console.WriteLine("Apellido: ");
            string Apellido = Console.ReadLine();
            Console.WriteLine("Nombre: ");
            string Nombre = Console.ReadLine();
            Console.WriteLine("Legajo: ");
            int Legajo = int.Parse(Console.ReadLine());
            foreach(Empleado emp in empleados)
            {
                if(emp.Legajo == Legajo)
                {
                    Console.WriteLine("Legajo ya existente");
                    return;
                }
            }
            Console.WriteLine("El empleado es Obrero o Profesional?: ");
            Console.WriteLine("o# 1. Obrero");
            Console.WriteLine("o# 2. Profesional");
            byte Tipo_Empleado = byte.Parse(Console.ReadLine());
            switch (Tipo_Empleado)
            {
                case 1: 
                    Console.WriteLine("Indique la categoria del obrero.");
                    Console.WriteLine("Oficial, MedioOficial, Aprendiz");
                    string Categoria = Console.ReadLine();
                    empleados.Add(new Obrero { Legajo = Legajo, Apellido = Apellido, Nombre = Nombre, Categoria = Categoria });
                    break;
                case 2:
                    Console.WriteLine("Titulo: ");
                    string Titulo = Console.ReadLine();
                    Console.WriteLine("Matricula: ");
                    string Matricula = Console.ReadLine();
                    Console.WriteLine("Consejo: ");
                    string Consejo = Console.ReadLine();
                    Console.WriteLine("Porcentaje propio para el sueldo (ej: 0,25): ");
                    decimal Porcentaje_Propio = decimal.Parse(Console.ReadLine());
                    if(Porcentaje_Propio > 1) 
                    {
                        Console.WriteLine("Ni que fueras de oro flaco");
                        while(Porcentaje_Propio > 1)
                        {
                            Porcentaje_Propio = decimal.Parse(Console.ReadLine());
                        }
                    }
                    empleados.Add(new Profesional { Legajo = Legajo, Apellido = Apellido, Nombre = Nombre, Titulo = Titulo, Matricula = Matricula, Consejo = Consejo, Porcentaje_Propio = Porcentaje_Propio, Supervisando = Supervisa });
                    break;
            }

        }
        public void Ingresar_Nueva_Obra()
        {

        }
        public void Listar_Empleados()
        {
            Console.Clear();
            Console.WriteLine("--- LISTADO DE EMPLEADOS ---");
            Console.WriteLine("o# 1. Listar empleados por apellido, nombre y legajo.");
            Console.WriteLine("o# 2. Listar empleados por apellido, nombre y legajo (ordenado alfabeticamente por apellido).");
            Console.WriteLine("o# 3. Listar Obreros");
            Console.WriteLine("o# 4. Listar Profesionales");
            byte Opcion = byte.Parse(Console.ReadLine());

            switch (Opcion)
            {
                case 1:
                    Console.Clear();
                    foreach(Empleado emp in empleados)
                    {
                        Console.WriteLine($"Apellido: {emp.Apellido} | Nombre: {emp.Nombre} | Legajo: {emp.Legajo}");
                    }
                    Console.ReadKey();
                    break;
                case 2:
                    Console.Clear();
                    var EmpleadosOrdenados = empleados.OrderBy(e => e.Apellido).ToList();
                    foreach(Empleado emp in EmpleadosOrdenados)
                    {
                        Console.WriteLine($"Apellido: {emp.Apellido} | Nombre: {emp.Nombre} | Legajo: {emp.Legajo}");
                    }
                    Console.ReadKey();
                    break;
                case 3:
                    Console.Clear();
                    foreach(Obrero obr in empleados)
                    {
                        Console.WriteLine($"Apellido: {obr.Apellido} | Nombre: {obr.Nombre} | Legajo: {obr.Legajo} | Sueldo: {obr.Sueldo}");
                    }
                    Console.ReadKey();
                    break;
                case 4:
                    Console.Clear();
                    foreach (Profesional pro in empleados)
                    {
                        Console.WriteLine($"Apellido: {pro.Apellido} | Nombre: {pro.Nombre} | Legajo: {pro.Legajo} | Sueldo: {pro.Sueldo}");
                    }
                    Console.ReadKey();
                    break;
                default:
                    Console.WriteLine("Opcion invalida.");
                    Console.ReadKey();
                    break;
            }
        }
    }
}

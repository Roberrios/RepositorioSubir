using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using BLL;

namespace CapaPresentacion
{
    class Program
    {
        static void Main(string[] args)
        {

            string nombre;
            string identificacion;
            string sexo;
            int edad;

            Persona persona;

            ConsoleKeyInfo opcion;

            PersonaServices PersonaServicio = new PersonaServices();

            do {

                try
                {
                    Console.Clear();
                    Console.WriteLine("Digite los datos");
                    Console.WriteLine("Digite la identificacion");
                    identificacion = Console.ReadLine();
                    Console.WriteLine("Digite el nombre");
                    nombre = Console.ReadLine();
                    Console.WriteLine("Digite el Sexo (f/m)");
                    sexo = Console.ReadLine();
                    Console.WriteLine("Digite la Edad");
                    edad= Convert.ToInt32(Console.ReadLine());
                    persona = new Persona(identificacion, nombre, sexo, edad);

                    PersonaServicio.CalcularPulsaciones(persona);
                    Console.WriteLine(PersonaServicio.Guardar(persona));
                    persona.ToString();
                }
                catch (Exception  e)
                {

                    Console.WriteLine("Error" + e.Message);
                }
                Console.WriteLine("Desea continuar (s/n)");
                opcion = Console.ReadKey();

            } while (opcion.Key == ConsoleKey.S);

            Console.Clear();
            Console.WriteLine("Consulta de pulsaciones");
            foreach (var item in PersonaServicio.Consultar())
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("Digite la identificaon a eliminar");
            identificacion = Console.ReadLine();
            Console.WriteLine(PersonaServicio.Eliminar(PersonaServicio.Buscar(identificacion)));

            Console.WriteLine("Consulta de pulsaciones");
            foreach (var item in PersonaServicio.Consultar())
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadKey();
        }
    }
}

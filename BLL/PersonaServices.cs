using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entity;

namespace BLL
{
    public class PersonaServices
    {

        PersonaRepository PersonaRepositorio = new PersonaRepository();

        public String Guardar(Persona persona) {

            if (PersonaRepositorio.BuscarIdentificacion(persona.Identificacion) == null)

            {
                PersonaRepositorio.Guardar(persona);
                return $"Se guardo la persona correctamente con identificacion {persona.Identificacion}";
            }
            return $"la persona con identificacion{persona.Identificacion} no se guardo, ya esta registrada";

        }

        public String Eliminar(Persona persona) {

            if (persona == null)
            {
                return $"La persona  no esta registrada. Favor ingresar una persona  registrada";
            }
             if (PersonaRepositorio.BuscarIdentificacion(persona.Identificacion) == null)
            {
                return $"La persona con idenetificaion {persona.Identificacion} no esta registrada. Favor ingresar una identificacion registrada";
            }

            PersonaRepositorio.Eliminar(persona);

            return $"La persona con idenetificaion{persona.Identificacion} se elimino correctamente";
        }

        public List<Persona> Consultar() {

            return PersonaRepositorio.Consultar();


        }

        public Persona Buscar(string id)
        {
            return PersonaRepositorio.BuscarIdentificacion(id);
           
        }

        public Persona CalcularPulsaciones(Persona persona) {

            persona.CalcularPulsaciones();

            return persona;

       
        }
    }
}

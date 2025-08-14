using System;

namespace ProyectoFinalPoo
{
    public class Persona
    {
        public string Nombre { get; protected set; }
        public int Edad { get; protected set; }
        public string Nacionalidad { get; protected set; }

        public Persona(string nombre, int edad, string nacionalidad = "")
        {
            Nombre = nombre;
            Edad = edad;
            Nacionalidad = nacionalidad;
        }

        public virtual string GetInfo()
        {
            return $"{Nombre}, {Edad} años" + (string.IsNullOrWhiteSpace(Nacionalidad) ? "" : $", {Nacionalidad}");
        }
    }
}

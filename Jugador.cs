using System;

namespace ProyectoFinalPoo
{
    public class Jugador : Persona
    {
        // Atributos privados
        private string _posicion;
        private int _dorsal;
        private int _goles;
        private int _amarillas;
        private int _rojas;

        // Properties públicas
        public string Posicion { get => _posicion; private set => _posicion = value; }
        public int Dorsal { get => _dorsal; private set => _dorsal = value; }
        public int Goles { get => _goles; private set => _goles = value; }

        // Constructor (con goles iniciales opcional)
        public Jugador(string nombre, int edad, string posicion, int dorsal, int golesIniciales = 0, string nacionalidad = "")
            : base(nombre, edad, nacionalidad)
        {
            _posicion = posicion;
            _dorsal = dorsal;
            _goles = golesIniciales;
            _amarillas = 0;
            _rojas = 0;
        }

        // Métodos funcionales
        public void MarcarGol() { Goles = ++_goles; }
        public void RecibirTarjeta(string tipo) { if (tipo.Equals("Amarilla", StringComparison.OrdinalIgnoreCase)) _amarillas++; else if (tipo.Equals("Roja", StringComparison.OrdinalIgnoreCase)) _rojas++; }
        public void CambiarDorsal(int d) { if (d <= 0) throw new ArgumentException("El dorsal debe ser positivo."); Dorsal = d; }
        public void CambiarPosicion(string pos) { if (string.IsNullOrWhiteSpace(pos)) throw new ArgumentException("Posición inválida."); Posicion = pos.Trim(); }

        // Sobreescritura
        public override string GetInfo()
            => $"{base.GetInfo()} — #{Dorsal}, {Posicion}, Goles: {Goles}, TA: {_amarillas}, TR: {_rojas}";
    }
}



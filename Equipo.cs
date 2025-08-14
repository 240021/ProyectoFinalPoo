using System;
using System.Collections.Generic;
using System.Linq;

namespace ProyectoFinalPoo
{
    public class Equipo
    {
        // Lista de jugadores
        private readonly List<Jugador> _jugadores = new List<Jugador>();

        public string Nombre { get; private set; }
        public string Ciudad { get; private set; }
        public IReadOnlyList<Jugador> Jugadores => _jugadores.AsReadOnly();

        // Constructor funcional
        public Equipo(string nombre, string ciudad)
        {
            Nombre = nombre;
            Ciudad = ciudad;
        }

        // Métodos para agregar/remover jugadores
        public void AgregarJugador(Jugador j)
        {
            if (j == null) throw new ArgumentNullException(nameof(j));
            if (!_jugadores.Contains(j)) _jugadores.Add(j);
        }

        public bool RemoverJugador(Jugador j) => _jugadores.Remove(j);

        public Jugador BuscarJugadorPorDorsal(int dorsal)
            => _jugadores.FirstOrDefault(x => x.Dorsal == dorsal);

        // Método para calcular estadísticas
        public int TotalGolesEquipo() => _jugadores.Sum(j => j.Goles);
    }
}

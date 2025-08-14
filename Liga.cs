using System;
using System.Collections.Generic;
using System.Linq;

namespace ProyectoFinalPoo
{
    public class TablaPosicionEntry
    {
        public Equipo Equipo { get; set; }
        public int PJ { get; set; }
        public int G { get; set; }
        public int E { get; set; }
        public int P { get; set; }
        public int GF { get; set; }
        public int GC { get; set; }
        public int DG => GF - GC;
        public int Pts { get; set; }
    }

    public class Liga
    {
        // Listas requeridas
        private readonly List<Equipo> _equipos = new List<Equipo>();
        private readonly List<Partido> _partidos = new List<Partido>();
        private readonly List<TablaPosicionEntry> _tabla = new List<TablaPosicionEntry>();

        public string Nombre { get; private set; }
        public int Temporada { get; private set; }

        // Constructor
        public Liga(string nombre, int temporada)
        {
            Nombre = nombre;
            Temporada = temporada;
        }

        // Gestión de liga
        public void AgregarEquipo(Equipo e)
        {
            if (e == null) throw new ArgumentNullException(nameof(e));
            if (_equipos.Any(x => x.Nombre.Equals(e.Nombre, StringComparison.OrdinalIgnoreCase))) return;
            _equipos.Add(e);
            _tabla.Add(new TablaPosicionEntry { Equipo = e });
        }

        public void AgregarPartido(Partido p)
        {
            if (p == null) throw new ArgumentNullException(nameof(p));
            _partidos.Add(p);
            // Suscribirse para actualizar la tabla cuando finalice
            p.PartidoFinalizado += ActualizarTabla;
        }

        public void ActualizarTabla(Partido _)
        {
            RecalcularTabla();
        }

        public void RecalcularTabla()
        {
            // Reiniciar
            foreach (var row in _tabla)
                row.PJ = row.G = row.E = row.P = row.GF = row.GC = row.Pts = 0;

            // Considerar solo finalizados
            foreach (var p in _partidos.Where(x => x.Estado == EstadoPartido.Finalizado))
            {
                var local = _tabla.First(r => r.Equipo == p.Local);
                var visita = _tabla.First(r => r.Equipo == p.Visitante);

                local.PJ++; visita.PJ++;
                local.GF += p.GolesLocal; local.GC += p.GolesVisitante;
                visita.GF += p.GolesVisitante; visita.GC += p.GolesLocal;

                if (p.GolesLocal > p.GolesVisitante)
                {
                    local.G++; local.Pts += 3;
                    visita.P++;
                }
                else if (p.GolesLocal < p.GolesVisitante)
                {
                    visita.G++; visita.Pts += 3;
                    local.P++;
                }
                else
                {
                    local.E++; visita.E++;
                    local.Pts++; visita.Pts++;
                }
            }
        }

        public void MostrarTablaPosiciones()
        {
            var ordenada = _tabla
                .OrderByDescending(r => r.Pts)
                .ThenByDescending(r => r.DG)
                .ThenByDescending(r => r.GF)
                .ThenBy(r => r.Equipo.Nombre)
                .ToList();

            Console.WriteLine("#  Equipo              PJ G  E  P  GF GC DG  Pts");
            Console.WriteLine(new string('-', 55));
            for (int i = 0; i < ordenada.Count; i++)
            {
                var r = ordenada[i];
                Console.WriteLine($"{i + 1,2} {r.Equipo.Nombre,-18} {r.PJ,2} {r.G,2} {r.E,2} {r.P,2} {r.GF,3} {r.GC,3} {r.DG,3} {r.Pts,4}");
            }
        }
    }
}

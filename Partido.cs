using System;

namespace ProyectoFinalPoo
{
    public enum EstadoPartido { Programado, EnJuego, Finalizado }

    public class Partido
    {
        // Referencia a dos equipos + control de goles y estado
        public int Id { get; private set; }
        public Equipo Local { get; private set; }
        public Equipo Visitante { get; private set; }
        public DateTime Fecha { get; private set; }
        public string Estadio { get; private set; }
        public int GolesLocal { get; private set; }
        public int GolesVisitante { get; private set; }
        public EstadoPartido Estado { get; private set; } = EstadoPartido.Programado;

        // Evento para notificar a la Liga al finalizar
        public event Action<Partido> PartidoFinalizado;

        // Constructor funcional
        public Partido(int id, Equipo local, Equipo visitante, DateTime fecha, string estadio)
        {
            Id = id;
            Local = local;
            Visitante = visitante;
            Fecha = fecha;
            Estadio = estadio;
        }

        // Métodos de gestión
        public void IniciarPartido()
        {
            if (Estado != EstadoPartido.Programado)
                throw new InvalidOperationException("El partido ya fue iniciado o finalizado.");
            Estado = EstadoPartido.EnJuego;
        }

        public void RegistrarGol(bool esLocal)
        {
            if (Estado != EstadoPartido.EnJuego)
                throw new InvalidOperationException("No se pueden registrar goles si el partido no está en juego.");
            if (esLocal) GolesLocal++;
            else GolesVisitante++;
        }

        public void FinalizarPartido()
        {
            if (Estado != EstadoPartido.EnJuego)
                throw new InvalidOperationException("Para finalizar, el partido debe estar en juego.");
            Estado = EstadoPartido.Finalizado;
            PartidoFinalizado?.Invoke(this);
        }

        public string GetResultado() => $"{Local.Nombre} {GolesLocal} - {GolesVisitante} {Visitante.Nombre}";
    }
}


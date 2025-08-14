using ProyectoFinalPoo;
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== SISTEMA DE LIGA DE FÚTBOL ===\n");

        // 1. CREAR LIGA
        Liga laLiga = new Liga("La Liga", 2024);
        Console.WriteLine($"Liga creada: {laLiga.Nombre}");

        // 2. CREAR EQUIPOS
        Equipo barcelona = new Equipo("FC Barcelona", "Barcelona");
        Equipo madrid = new Equipo("Real Madrid", "Madrid");

        // 3. CREAR JUGADORES
        Jugador messi = new Jugador("Lionel Messi", 36, "Delantero", 10);
        Jugador jugadorB1 = new Jugador("Pedri", 21, "Mediocampista", 8);
        Jugador jugadorB2 = new Jugador("Gavi", 20, "Mediocampista", 6);
        Jugador jugadorB3 = new Jugador("Lewandowski", 35, "Delantero", 9);

        Jugador cristiano = new Jugador("Cristiano Ronaldo", 39, "Delantero", 7);
        Jugador jugadorM1 = new Jugador("Vinicius Jr", 24, "Delantero", 11);
        Jugador jugadorM2 = new Jugador("Luka Modric", 39, "Mediocampista", 10);
        Jugador jugadorM3 = new Jugador("Toni Kroos", 35, "Mediocampista", 8);

        // 4. AGREGAR JUGADORES A EQUIPOS
        barcelona.AgregarJugador(messi);
        barcelona.AgregarJugador(jugadorB1);
        barcelona.AgregarJugador(jugadorB2);
        barcelona.AgregarJugador(jugadorB3);

        madrid.AgregarJugador(cristiano);
        madrid.AgregarJugador(jugadorM1);
        madrid.AgregarJugador(jugadorM2);
        madrid.AgregarJugador(jugadorM3);

        // 5. AGREGAR EQUIPOS A LA LIGA
        laLiga.AgregarEquipo(barcelona);
        laLiga.AgregarEquipo(madrid);

        // 6. CREAR Y JUGAR UN PARTIDO
        Partido clasico = new Partido(1, barcelona, madrid, DateTime.Now, "Camp Nou");
        laLiga.AgregarPartido(clasico);

        Console.WriteLine("\n=== INICIANDO EL CLÁSICO ===");
        clasico.IniciarPartido();

        // 7. SIMULAR GOLES
        Console.WriteLine("¡Messi marca para el Barcelona!");
        clasico.RegistrarGol(true); // Gol local
        messi.MarcarGol(); // Messi 1 gol

        Console.WriteLine("¡Cristiano Ronaldo marca para el Madrid!");
        clasico.RegistrarGol(false);
        cristiano.MarcarGol(); // Gol 1

        Console.WriteLine("¡Cristiano Ronaldo anota de nuevo!");
        clasico.RegistrarGol(false);
        cristiano.MarcarGol(); // Gol 2

        Console.WriteLine("¡Cristiano Ronaldo completa su hat-trick!");
        clasico.RegistrarGol(false);
        cristiano.MarcarGol(); // Gol 3

        // 8. FINALIZAR PARTIDO
        clasico.FinalizarPartido();
        Console.WriteLine($"\nResultado final: {clasico.GetResultado()}");

        // Recalcular tabla para reflejar resultados
        laLiga.RecalcularTabla();

        // 9. MOSTRAR ESTADÍSTICAS
        Console.WriteLine("\n=== ESTADÍSTICAS ===");
        Console.WriteLine($"Goles de Messi: {messi.Goles}");
        Console.WriteLine($"Goles de Cristiano Ronaldo: {cristiano.Goles}");
        Console.WriteLine($"Goles de Vinicius Jr: {jugadorM1.Goles}");
        Console.WriteLine($"Goles de Luka Modric: {jugadorM2.Goles}");
        Console.WriteLine($"Goles de Toni Kroos: {jugadorM3.Goles}");

        // 10. MOSTRAR TABLA DE POSICIONES
        Console.WriteLine("\n=== TABLA DE POSICIONES ===");
        laLiga.MostrarTablaPosiciones();

        Console.WriteLine("\nPresiona cualquier tecla para salir...");
        Console.ReadKey();
    }
}





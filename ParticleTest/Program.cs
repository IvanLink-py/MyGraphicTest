using ParticleTest;
using SFML.System;

internal static class Program
{
    private static void Main(string[] args)
    {
        var window = new ParticleWindow(new Vector2u(1200, 800), "Частички");
        window.Run();
    }
}
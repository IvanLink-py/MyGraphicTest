using SFML.Graphics;
using SFML.System;

namespace ParticleTest;

public class Particle : CircleShape
{
    private static readonly Random Rnd = new(0);

    public float Mass = (float)(Rnd.NextDouble() * 100) + 2;
    public ParticleSpace Space;
    public Vector2f Velocity;

    public Particle(ParticleSpace space)
    {
        Space = space;

        FillColor = Color.Cyan;
        OutlineThickness = 1;
        OutlineColor = Color.Blue;

        Radius = MathF.Sqrt(Mass);

        Position = new Vector2f(500f * (float)Rnd.NextDouble() + 200, (float)Rnd.NextDouble() * 500 + 100);
        Velocity = new Vector2f(((float)Rnd.NextDouble() - 0.5f) * 20, ((float)Rnd.NextDouble() - 0.5f) * 20);
    }

    public void UpdatePhysics()
    {
        var attraction = Space.CalculateAttraction(Position, Mass);
        Velocity += attraction / Mass;

        Position += Velocity;
    }
}
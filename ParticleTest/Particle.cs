using SFML.Graphics;
using SFML.System;

namespace ParticleTest;

public class Particle : CircleShape
{
    private static readonly Random Rnd = new(0);

    public float Mass = (float)(Rnd.NextDouble() * 100) + 2;
    public ParticleSpace Space;
    public Vector2f Vel;

    public Particle(ParticleSpace space)
    {
        Space = space;

        FillColor = Color.Cyan;
        OutlineThickness = 1;
        OutlineColor = Color.Blue;

        Radius = MathF.Sqrt(Mass);

        Position = new Vector2f(500f * (float)Rnd.NextDouble() + 200, (float)Rnd.NextDouble() * 500 + 100);
        Vel = new Vector2f(((float)Rnd.NextDouble() - 0.5f) * 20, ((float)Rnd.NextDouble() - 0.5f) * 20);
    }

    public void UpdatePhysics()
    {
        Vector2f force = new();
        
        force += Space.CalculateAttraction(Position, Mass); // Attraction
        force += CalculateFriction();                       // Friction
        
        
        Vel += force / Mass;

        Position += Vel;
    }

    private Vector2f CalculateFriction()
    {
        return -Vel * Space.GetFriction(Position) * MathF.Sqrt(Vel.X * Vel.X + Vel.Y * Vel.Y);
    }
}
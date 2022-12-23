using SFML.Graphics;
using SFML.System;
using System;

namespace ParticleTest;

public class Particle : CircleShape
{
    private static readonly Random Rnd = new(0);
    
    public float Mass = 5;
    public Vector2f Velocity;
    public ParticleSpace Space;

    public Particle(ParticleSpace space)
    {
        Space = space;
        
        FillColor = Color.Cyan;
        OutlineThickness = 1;
        OutlineColor = Color.Blue;

        Radius = Mass;

        Position = new Vector2f(500f * (float)Rnd.NextDouble() +200, (float)Rnd.NextDouble() * 500 +100);
        Velocity = new Vector2f((float)Rnd.NextDouble()-0.5f, (float)Rnd.NextDouble()-0.5f);
    }

    public void UpdatePhysics()
    {
        var attraction = Space.CalculateAttraction(Position, Mass);
        Velocity += attraction / Mass;
        
        Position += Velocity;
    }
}
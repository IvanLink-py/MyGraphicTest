using SFML.System;

namespace ParticleTest;

public class Attractor
{
    public Vector2f Position;
    public float Force;

    public Attractor(Vector2f position, float force)
    {
        Position = position;
        Force = force;
    }

    public Vector2f CalculateAttraction(Vector2f position, float mass)
    {
        return (Position - position) * Force * mass;
    }
}
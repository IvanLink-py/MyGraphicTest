using SFML.System;

namespace ParticleTest;

public class ParticleSpace
{
    public Particle[] Particles;
    public List<Attractor> Attractors = new();

    public ParticleSpace(int count)
    {
        Particles = new Particle[count];

        for (var i = 0; i < count; i++)
        {
            Particles[i] = new Particle(this);
        }
    }

    public Attractor NewAttractor()
    {
        Attractors.Add(new Attractor(new Vector2f(200, 200), 0.0001f));
        return Attractors.Last();
    }

    public Vector2f CalculateAttraction(Vector2f position, float mass)
    {
        var force = new Vector2f();
        return Attractors.Aggregate(force, (current, a) => current + a.CalculateAttraction(position, mass));
    }
    
    public void UpdateParticles()
    {
        foreach (var p in Particles)
        {
            p.UpdatePhysics();
        }
    }
}
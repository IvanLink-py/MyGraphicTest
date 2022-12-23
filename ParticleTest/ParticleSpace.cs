using SFML.System;

namespace ParticleTest;

public class ParticleSpace
{
    public List<Attractor> Attractors = new();
    public Particle[] Particles;

    public ParticleSpace(int count)
    {
        Particles = new Particle[count];

        for (var i = 0; i < count; i++) Particles[i] = new Particle(this);
    }

    public Attractor NewAttractor(Vector2f position, float force)
    {
        Attractors.Add(new Attractor(position, force));
        return Attractors.Last();
    }

    public Vector2f CalculateAttraction(Vector2f position, float mass)
    {
        var force = new Vector2f();
        return Attractors.Aggregate(force, (current, a) => current + a.CalculateAttraction(position, mass));
    }

    public void UpdateParticles()
    {
        foreach (var p in Particles) p.UpdatePhysics();
    }

    public float GetFriction(Vector2f pos) => 0.1f;
}
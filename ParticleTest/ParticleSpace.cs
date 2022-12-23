namespace ParticleTest;

public class ParticleSpace
{
    public Particle[] Particles;

    public ParticleSpace(int count)
    {
        Particles = new Particle[count];

        for (var i = 0; i < count; i++)
        {
            Particles[i] = new Particle();
        }
    }

    public void UpdateParticles()
    {
        foreach (var p in Particles)
        {
            p.UpdatePhysics();
        }
    }
}
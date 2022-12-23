using System.Numerics;
using SFML.Window;
using SFML.Graphics;
using SFML.System;

namespace ParticleTest;

public class ParticleWindow
{
    private readonly RenderWindow _window;
    public ParticleSpace Space;
    private readonly Clock _clock;
    public ParticleWindow(Vector2u size, string title)
    {
        VideoMode mode = new(size.X, size.Y);
        _window = new RenderWindow(mode, title);
        _window.SetFramerateLimit(60);
        _clock = new Clock();
        Space = new ParticleSpace(10000);

        Space.NewAttractor();
    }
    public void Run()
    {
        _window.KeyPressed += Window_KeyPressed;
        _window.Closed += (_, _) => { _window.Close(); };
        
        while (_window.IsOpen)
        {
            _window.DispatchEvents();
            ShowFramerate();

            Space.UpdateParticles();
            
            Render();

            _window.Display();
        }
    }

    private void ShowFramerate()
    {
        _window.SetTitle((1 / _clock.ElapsedTime.AsSeconds()).ToString());
        _clock.Restart();
    }

    private void Render()
    {
        _window.Clear();
        foreach (var particle in Space.Particles)
        {
            _window.Draw(particle);
        }
    }

    private void Window_KeyPressed(object? sender, KeyEventArgs e)
    {
        if (e.Code == Keyboard.Key.Escape) _window.Close();
    }
}
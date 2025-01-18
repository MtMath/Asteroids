
namespace NoTask.Asteroids.Input
{
    public interface IInputStrategy
    {
        bool Enabled { get; set; }
        InputPayload HandleTouchInput();
        InputPayload HandleKeyboardInput();
    }
}
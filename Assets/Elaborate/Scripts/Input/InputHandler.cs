using UnityEngine;
using UnityEngine.InputSystem;

namespace NoTask.Asteroids.Input
{
    public struct InputPayload
    {
        public Vector2 InputVector;
        public bool IsFiring;

        public static InputPayload Empty => new()
        {
            InputVector = Vector2.zero,
            IsFiring = false
        };
    }

    [DefaultExecutionOrder(-10)]
    public class InputHandler : MonoBehaviour
    {
        public InputPayload CurrentInputPayload { get; private set; }
        private IInputStrategy _inputStrategy;
        
        public bool EnabledInput
        {
            get => _inputStrategy.Enabled;
            set => _inputStrategy.Enabled = value;
        }

        private void Awake()
        {
#if ENABLE_INPUT_SYSTEM
            _inputStrategy = gameObject.AddComponent<InputSystemStrategy>();
#else
            _inputStrategy = gameObject.AddComponent<InputStrategy>();
#endif
        }

        private void Update()
        {
            if (_inputStrategy == null) return;
            
            CurrentInputPayload = Application.isMobilePlatform
                ? _inputStrategy.HandleTouchInput()
                : _inputStrategy.HandleKeyboardInput();
            
#if UNITY_EDITOR
            Debug.Log($"[Input Handler] - Vector: {CurrentInputPayload.InputVector}");
            Debug.Log($"[Input Handler] - Fire: {CurrentInputPayload.IsFiring}");
            Debug.Log($"[Input Handler] - Enabled: {EnabledInput}");
            
    #if ENABLE_INPUT_SYSTEM
            //Only for test Purposes ( New Input System )
            if (Keyboard.current.f5Key.wasPressedThisFrame) EnabledInput = !EnabledInput;
    #else
            //Only for test Purposes ( Old Input System )
            if(UnityEngine.Input.GetKeyDown(KeyCode.F5)) EnabledInput = !EnabledInput;
    #endif
            
#endif
            
        }
    }
}
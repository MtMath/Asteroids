using UnityEngine;
using UnityEngine.InputSystem;

namespace NoTask.Asteroids.Input
{
    public class InputSystemStrategy : MonoBehaviour, IInputStrategy
    {
        public bool Enabled
        {
            get => _inputActions.Player.enabled;
            set
            {
                if (value) _inputActions.Player.Move.Enable();
                else _inputActions.Player.Move.Disable();
            }
        }

        private InputMapper _inputActions;
        
        //Internal Variables to handle the input
        private Vector2 _inputVector;
        private bool _isFiring;
        
        public void OnEnable()
        {
            _inputActions = new InputMapper();
            
            _inputActions.Enable();
            
            _inputActions.Player.Move.performed += OnMove;
            _inputActions.Player.Move.canceled += OnMove;
            
            _inputActions.Player.Fire.performed += OnFire;
            _inputActions.Player.Fire.canceled += OnFire;
            
            _inputActions.Player.Enable();
        }
        
        public void OnDisable()
        {
            _inputActions.Disable();
            
            _inputActions.Player.Move.performed -= OnMove;
            _inputActions.Player.Move.canceled -= OnMove;
            
            _inputActions.Player.Fire.started -= OnFire;
            _inputActions.Player.Fire.performed -= OnFire;
            
            _inputActions.Player.Disable();
        }
        
        private void OnMove(InputAction.CallbackContext ctx)
        {
            _inputVector = ctx.ReadValue<Vector2>();
        }
        
        private void OnFire(InputAction.CallbackContext ctx)
        {
            _isFiring = ctx.started;
        }

        public InputPayload HandleTouchInput()
        {
            return new InputPayload
            {
                InputVector = _inputVector,
                IsFiring = _isFiring
            };
        }

        public InputPayload HandleKeyboardInput()
        {
            return new InputPayload
            {
                InputVector = _inputVector,
                IsFiring = _isFiring
            };
        }
    }
}
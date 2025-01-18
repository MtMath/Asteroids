using UnityEngine;

namespace NoTask.Asteroids.Input
{
    public class InputStrategy : MonoBehaviour, IInputStrategy
    {
        public bool Enabled { get; set; } = true;

        /// <summary>
        /// This method is called when the game is running on a mobile platform
        /// NOT TESTED YET, BUT I SUPPOSE IT WORKS
        /// </summary>
        /// <returns></returns>
        public InputPayload HandleTouchInput()
        {
            if (!Enabled) return InputPayload.Empty;
            
            var touchCount = UnityEngine.Input.touchCount;
            var splitScreen = Screen.width / 2;

            var touchPosition = UnityEngine.Input.GetTouch(0).position;
            
            if (touchCount > 0)
            {
                if (UnityEngine.Input.GetTouch(0).position.x < splitScreen)
                {
                    return new InputPayload
                    {
                        InputVector = touchPosition.normalized,
                        IsFiring = false
                    };
                }
                else
                {
                    return new InputPayload
                    {
                        InputVector = Vector2.zero,
                        IsFiring = true
                    };
                }
            }
            
            return InputPayload.Empty;
        }

        /// <summary>
        /// This method is called when the game is running on a desktop platform
        /// </summary>
        /// <returns></returns>
        public InputPayload HandleKeyboardInput()
        {
            // Mathf.Max(0, ...) is used to avoid negative values ( ignore the opposite direction )
            var horizontal = UnityEngine.Input.GetAxis("Horizontal");
            var vertical = Mathf.Max(0, UnityEngine.Input.GetAxis("Vertical"));
            
            return Enabled ? new InputPayload
            {
                InputVector = new Vector2(horizontal, vertical),
                IsFiring = UnityEngine.Input.GetButtonDown("Fire1") || UnityEngine.Input.GetKeyDown(KeyCode.Space)
            } : InputPayload.Empty;
        }
    }
}
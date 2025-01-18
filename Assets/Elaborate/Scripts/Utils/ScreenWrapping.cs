using Patterns;
using UnityEngine;

namespace Managers
{
    public class ScreenWrapping : Singleton<ScreenWrapping>
    {
        [Header("Screen Wrapping Settings")] 
        
        [Tooltip("Padding to add to the screen bounds.")]
        public Vector2 padding = Vector2.zero;
        
        [Tooltip("Allow the screen bounds to be recalculated every frame.")]
        public bool dynamicResolution = false;
        
        private Vector2? _screenBounds;
        public Vector2 ScreenBounds
        {
            get
            {
                if (!_screenBounds.HasValue || dynamicResolution)
                    _screenBounds = CalculateScreenBounds();
                
                return _screenBounds.Value;
            }
        }

        private void Awake()
        {
            _screenBounds = CalculateScreenBounds();
        }

        private static Vector2 CalculateScreenBounds()
        {
            var main = Camera.main;
            if (!main) return Vector2.zero;
            
            var halfHeight = main.orthographicSize;
            var halfWidth = halfHeight * main.aspect;
            return new Vector2(halfWidth, halfHeight);
        }
        public Vector2 GetWrappedPosition(Vector2 position)
        {
            var paddedX = ScreenBounds.x + padding.x;
            var paddedY = ScreenBounds.y + padding.y;

            if (position.x > paddedX)
                position.x = -paddedX;
            else if (position.x < -paddedX)
                position.x = paddedX;

            if (position.y > paddedY)
                position.y = -paddedY;
            else if (position.y < -paddedY)
                position.y = paddedY;

            return position;
        }
        public bool IsOutOfBounds(Vector2 position)
        {
            var paddedX = ScreenBounds.x + padding.x;
            var paddedY = ScreenBounds.y + padding.y;

            return position.x > paddedX || position.x < -paddedX || position.y > paddedY || position.y < -paddedY;
        }
    }
}
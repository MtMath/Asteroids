using Managers;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(ScreenWrapping))]
    public class ScreenWrappingEditor : UnityEditor.Editor
    {
        private void OnSceneGUI()
        {
            var screenWrapping = (ScreenWrapping)target;
            var screenBounds = screenWrapping.ScreenBounds;

            var paddedX = screenBounds.x + screenWrapping.padding.x;
            var paddedY = screenBounds.y + screenWrapping.padding.y;

            var topLeft = new Vector3(-paddedX, paddedY);
            var topRight = new Vector3(paddedX, paddedY);
            var bottomLeft = new Vector3(-paddedX, -paddedY);
            var bottomRight = new Vector3(paddedX, -paddedY);

            Handles.color = Color.yellow;
            Handles.DrawLine(topLeft, topRight);
            Handles.DrawLine(topRight, bottomRight);
            Handles.DrawLine(bottomRight, bottomLeft);
            Handles.DrawLine(bottomLeft, topLeft);

            Handles.Label(topLeft + Vector3.up, $"Screen Bounds + Padding: ({paddedX}, {paddedY})");
        }
    }
}
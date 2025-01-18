using Managers;
using UnityEngine;

namespace Scenes.PrototypeScenes.SceneWrapping
{
    public class WrappingTest : MonoBehaviour
    {
        [Header("Properties")]
        [SerializeField] private float speed = 5f;
        [SerializeField] private ScreenWrapping screenWrapping;
        [SerializeField] private bool wrapAround = true;
    
        private SpriteRenderer _spriteRenderer;
    
        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }
    
        private void Update()
        {
            Move();
        }
    
        private void Move()
        {
            var horizontal = UnityEngine.Input.GetAxis("Horizontal");
            var vertical = UnityEngine.Input.GetAxis("Vertical");

            var direction = new Vector3(horizontal, vertical, 0);
            transform.position += direction * (speed * Time.deltaTime);

            if (screenWrapping.IsOutOfBounds(transform.position))
            {
                Debug.Log("[Screen Wrapping] - Out of bounds!");
                _spriteRenderer.color = Color.red;
                if (wrapAround) transform.position = screenWrapping.GetWrappedPosition(transform.position);
            }
            else
            {
                var color = Color.Lerp(_spriteRenderer.color, Color.white, Time.deltaTime * speed);
                _spriteRenderer.color = color;
            }
        }
    }
}

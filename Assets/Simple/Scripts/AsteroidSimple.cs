using UnityEngine;
using Random = UnityEngine.Random;

public class AsteroidSimple : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;

    [SerializeField] private Sprite[] sprites;

    public float size = 1f;
    public float minSize = 0.35f;
    public float maxSize = 1.65f;
    public float movementSpeed = 50f;
    public float maxLifetime = 30f;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        _spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];
        transform.eulerAngles = new Vector3(0f, 0f, Random.value * 360f);

        transform.localScale = Vector3.one * size;
        _rigidbody2D.mass = size;
        
        Destroy(gameObject, maxLifetime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Projectile")) return;
        
        if (size * 0.5f >= minSize)
        {
            CreateSplit();
            CreateSplit();
        }

        GameManagerSimple.Instance.OnAsteroidDestroyed(this);
        Destroy(gameObject);
    }

    private void CreateSplit()
    {
        Vector2 position = transform.position;
        position += Random.insideUnitCircle * 0.5f;

        var half = Instantiate(this, position, transform.rotation);
        half.size = size * 0.5f;
        
        half.SetTrajectory(Random.insideUnitCircle.normalized);
    }
    
    public void SetTrajectory(Vector2 direction)
    {
        _rigidbody2D.AddForce(direction * movementSpeed);
    }
}

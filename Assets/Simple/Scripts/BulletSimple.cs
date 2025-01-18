using Managers;
using UnityEngine;

public class BulletSimple : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;

    public float speed = 500f;
    public float maxLifetime = 10f;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Shoot(Vector2 direction)
    {
        _rigidbody2D.AddForce(direction * speed);

        Destroy(gameObject, maxLifetime);
    }

    private void FixedUpdate()
    {
        _rigidbody2D.position = ScreenWrapping.Instance.GetWrappedPosition(_rigidbody2D.position);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}

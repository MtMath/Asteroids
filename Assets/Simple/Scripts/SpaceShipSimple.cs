using Managers;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class SpaceShipSimple : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float thrustSpeed = 1f;
    [SerializeField] private float rotationSpeed = 0.1f;

    [field: Header("Respawn Settings")]
    [field: SerializeField] public float RespawnDelay { get; set; } = 3f;
    [SerializeField] private float respawnInvulnerability = 3f;
    
    [Header("Projectile Settings")]
    [SerializeField] private Transform firePoint;
    [SerializeField] private BulletSimple bulletPrefab;
    
    private bool _thrusting;
    private float _turnDirection;
    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
#if ENABLE_LEGACY_INPUT_MANAGER
        _thrusting = Input.GetAxis("Vertical") > 0;
        _turnDirection = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) Shoot();
#endif
    }

    private void FixedUpdate()
    {
        if (_thrusting) _rigidbody2D.AddForce(transform.up * thrustSpeed);
        if (_turnDirection != 0f) _rigidbody2D.AddTorque(rotationSpeed * -_turnDirection);
        
        _rigidbody2D.position = ScreenWrapping.Instance.GetWrappedPosition(_rigidbody2D.position);
    }

    private void Shoot()
    {
        var bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.Shoot(firePoint.up);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Asteroid")) return;
        
        _rigidbody2D.velocity = Vector3.zero;
        _rigidbody2D.angularVelocity = 0f;

        GameManagerSimple.Instance.OnPlayerDeath(this);
    }
}
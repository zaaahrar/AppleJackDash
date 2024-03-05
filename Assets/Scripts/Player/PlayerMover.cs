using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _tapForce = 10f;
    [SerializeField] private float _rotationSpeed;

    private const float MaxRotationZ = 35;
    private const float MinRotationZ = -55;

    private Quaternion _maxRotation;
    private Quaternion _minRotation;

    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _maxRotation = Quaternion.Euler(0, 0, MaxRotationZ);
        _minRotation = Quaternion.Euler(0, 0, MinRotationZ);
    }

    private void Update() => transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation,
        _rotationSpeed * Time.deltaTime);

    public void FlyUp()
    {
        _rigidbody2D.velocity = new Vector2(_speed, 0);
        transform.rotation = _maxRotation;
        _rigidbody2D.AddForce(Vector2.up * _tapForce, ForceMode2D.Force);
    }
}

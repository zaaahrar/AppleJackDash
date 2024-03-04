using UnityEngine;
using UnityEngine.Pool;

public abstract class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Vector3 _direction;
    private ObjectPool<Bullet> _bulletPool;

    public ObjectPool<Bullet> BulletPool => _bulletPool;

    private void Update() => transform.Translate(_direction * _speed * Time.deltaTime);

    public void Initialize(Vector3 direction, ObjectPool<Bullet> bulletPool)
    {
         _direction = direction;
        _bulletPool = bulletPool;
    }
}

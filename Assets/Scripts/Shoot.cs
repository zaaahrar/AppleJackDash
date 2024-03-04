using UnityEngine;
using System.Collections;
using UnityEngine.Pool;

public abstract class Shoot : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private float _delayTime;
    [SerializeField] private bool _isShooting = false;
    [SerializeField] private Transform _bulletPoint;
    [SerializeField] private int _countBullets;

    private ObjectPool<Bullet> _bulletPool;
    private WaitForSeconds _delay;

    public Transform BulletPoint => _bulletPoint;
    public bool IsShooting => _isShooting;
    public Bullet BulletPrefab => _bulletPrefab;
    public ObjectPool<Bullet> BulletPool => _bulletPool;

    private void OnEnable()
    {
        _bulletPool = new ObjectPool<Bullet>(CreateBullet, GetBullet, ReturnBullet, defaultCapacity: _countBullets);
        _delay = new WaitForSeconds(_delayTime);
        StartCoroutine(DelayShooting());
    }

    public abstract void ShootBullet();

    protected IEnumerator DelayShooting()
    {
        yield return _delay;
        AllowShoot();
    }

    protected void ProhibitShoot() => _isShooting = false;

    protected void AllowShoot() => _isShooting = true;

    private void GetBullet(Bullet bullet) => bullet.gameObject.SetActive(true);

    private void ReturnBullet(Bullet bullet) => bullet.gameObject.SetActive(false);

    private Bullet CreateBullet()
    {
        var bullet = Instantiate(BulletPrefab);
        return bullet;
    }
}

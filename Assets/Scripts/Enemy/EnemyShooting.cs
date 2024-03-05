using UnityEngine;

public class EnemyShooting : Shoot
{
    private void Update() => ShootBullet();

    public override void ShootBullet()
    {
        if (IsShooting)
        {
            ProhibitShoot();
            Bullet bullet = BulletPool.Get();
            bullet.transform.position = BulletPoint.position;
            bullet.Initialize(Vector2.left, BulletPool);
            StartCoroutine(DelayShooting());
        }
    }
}

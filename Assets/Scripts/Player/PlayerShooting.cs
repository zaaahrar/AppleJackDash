using UnityEngine;

public class PlayerShooting : Shoot
{
    public override void ShootBullet()
    {
        if (IsShooting)
        {
            ProhibitShoot();
            Bullet bullet = BulletPool.Get();
            bullet.transform.position = BulletPoint.position;
            bullet.Initialize(transform.right, BulletPool);
            StartCoroutine(DelayShooting());
        }
    }
}

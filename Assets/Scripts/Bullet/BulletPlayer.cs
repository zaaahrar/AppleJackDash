using UnityEngine;

public class BulletPlayer : Bullet
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
        {
            enemy.Die();
            BulletPool.Release(this);
        }

        if (collision.TryGetComponent(out Border _))
            BulletPool.Release(this);
    }
}

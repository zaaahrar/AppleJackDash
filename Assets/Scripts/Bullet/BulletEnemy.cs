using UnityEngine;

public class BulletEnemy : Bullet
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            player.Die();
            BulletPool.Release(this);
        }

        if (collision.TryGetComponent(out Border _))
            BulletPool.Release(this);
    }
}

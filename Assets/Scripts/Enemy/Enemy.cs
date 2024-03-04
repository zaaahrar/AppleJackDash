using UnityEngine;
using UnityEngine.Pool;

public class Enemy : MonoBehaviour
{
    private ScoreCounter _scoreCounter;

    private ObjectPool<Enemy> _pool;

    public void Initialize(ObjectPool<Enemy> enemyPool, ScoreCounter scoreCounter)
    {
        _pool = enemyPool;
        _scoreCounter = scoreCounter;
    }

    public void Die()
    {
        _pool.Release(this);
        _scoreCounter.AddScore();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Border _))
            _pool.Release(this);
    }
}

using System.Collections;
using System;
using UnityEngine;
using UnityEngine.Pool;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private GameObject _container;
    [SerializeField] private int _countEnemy; 
    [SerializeField] private float _delayTime;
    [SerializeField] private float _maxSpawnPostionY;
    [SerializeField] private float _minSpawnPostionY;

    private bool _isSpawn = true;
    private ObjectPool<Enemy> _enemyPool;
    private WaitForSeconds _delay;

    private void Awake()
    {
        _delay = new WaitForSeconds(_delayTime);
        _enemyPool = new ObjectPool<Enemy>(CreateEnemy, GetEnemy, ReturnEnemy, defaultCapacity: _countEnemy);
    }

    private void Update()
    {
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        if (_isSpawn)
        {
            _isSpawn = false;
            float spawnPositionY = UnityEngine.Random.Range(_minSpawnPostionY, _maxSpawnPostionY);
            Vector3 spawnPoint = new Vector3(transform.position.x, spawnPositionY, transform.position.z);
            Enemy enemy = _enemyPool.Get();
            enemy.transform.position = spawnPoint;
            enemy.Initialize(_enemyPool, _scoreCounter);
            StartCoroutine(SpawnDelayed());
        }
    }

    private void GetEnemy(Enemy enemy) => enemy.gameObject.SetActive(true);

    private void ReturnEnemy(Enemy enemy) => enemy.gameObject.SetActive(false);

    private Enemy CreateEnemy()
    {
        var enemy = Instantiate(_enemyPrefab, _container.transform);
        return enemy;
    }

    private IEnumerator SpawnDelayed()
    {
        yield return _delay;
        _isSpawn = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : ObjectPool<Enemy>
{
    [SerializeField] private float _delay;
    [SerializeField] private float _upperBound;
    [SerializeField] private float _lowerBound;
    [SerializeField] private List<Enemy> _prefabs;

    private Coroutine _spawnEnemiesCoroutine;

    private void OnEnable()
    {
        _spawnEnemiesCoroutine = StartCoroutine(SpawnEnemies());
    }

    private void OnDisable()
    {
        if (_spawnEnemiesCoroutine != null)
            StopCoroutine(_spawnEnemiesCoroutine);
    }

    public override void Restart()
    {
        foreach (var item in Pool)
        {
            item.Restart();
            item.gameObject.SetActive(false);
        }
    }

    private IEnumerator SpawnEnemies()
    {
        var waitForDelay = new WaitForSeconds(_delay);

        while (enabled)
        {
            Spawn();
            yield return waitForDelay;
        }
    }

    private void Spawn()
    {
        float spawnPositionY = Random.Range(_upperBound, _lowerBound);
        Vector3 spawnPoint = new Vector3(transform.position.x, spawnPositionY, transform.position.z);

        var enemy = GetObject(_prefabs);
        enemy.transform.position = spawnPoint;
        enemy.gameObject.SetActive(true);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdShooter : ObjectPool<BirdBullet>
{
    [SerializeField] private BirdBullet _prefab;
    [SerializeField] private ScoreCounter _scoreCounter;

    public event Action EnemyKilled;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        var bullet = GetObject(_prefab);

        bullet.gameObject.SetActive(true);
        bullet.EnemyHit += EnemyHit;
        bullet.transform.position = transform.position;
    }

    private void EnemyHit()
    {
        EnemyKilled?.Invoke();
    }

    public override void Restart()
    {
        foreach (var item in Pool)
        {
            item.Restart();
            item.gameObject.SetActive(false);
        }
    }
}

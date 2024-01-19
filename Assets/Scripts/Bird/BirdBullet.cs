using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdBullet : MonoBehaviour
{
    public event Action EnemyHit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
        {
            EnemyHit?.Invoke();
        }

        Restart();
        gameObject.SetActive(false);
    }

    public void Restart()
    {
        EnemyHit = null;
    }
}

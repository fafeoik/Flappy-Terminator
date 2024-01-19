using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyShooter))]
public class Enemy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<EnemyBullet>(out EnemyBullet enemyBullet) == false)
        {
            Restart();
            gameObject.SetActive(false);
        }
    }

    public void Restart()
    {
        GetComponent<EnemyShooter>().Restart();
    }
}

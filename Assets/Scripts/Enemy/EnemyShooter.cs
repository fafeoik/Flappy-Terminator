using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : ObjectPool<EnemyBullet>
{
    [SerializeField] private float _spawnCooldown;
    [SerializeField] private EnemyBullet _prefab;

    private Coroutine _shootBulletsCoroutine;

    private void OnEnable()
    {
        _shootBulletsCoroutine = StartCoroutine(Shoot());
    }

    private void OnDisable()
    {
        if (_shootBulletsCoroutine != null)
            StopCoroutine(_shootBulletsCoroutine);
    }

    private IEnumerator Shoot()
    {
        WaitForSeconds waitForCooldown = new WaitForSeconds(_spawnCooldown);

        while (enabled)
        {
            var bullet = GetObject(_prefab);

            bullet.gameObject.SetActive(true);
            bullet.transform.position = transform.position;

            yield return waitForCooldown;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Coroutine _moveCoroutine;
    private Transform _transform;

    private void Start()
    {
        _transform = transform;
    }

    private void OnEnable()
    {
        _moveCoroutine = StartCoroutine(Move());
    }

    private void OnDisable()
    {
        if (_moveCoroutine != null)
            StopCoroutine(_moveCoroutine);
    }

    private IEnumerator Move()
    {
        while (enabled)
        {
            transform.Translate(Vector3.left * _speed * Time.deltaTime);

            yield return null;
        }
    }
}

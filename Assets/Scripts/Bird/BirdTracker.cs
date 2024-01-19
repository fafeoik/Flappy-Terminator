using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdTracker : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private float _horizontalOffset;

    private void Update()
    {
        Vector3 position = transform.position;
        position.x = _bird.transform.position.x + _horizontalOffset;
        transform.position = position;
    }
}

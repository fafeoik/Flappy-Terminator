using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private BirdShooter _birdShooter;

    private int _score;

    public event Action<int> ScoreChanged;

    private void OnEnable()
    {
        _birdShooter.EnemyKilled += AddScore;
    }

    private void OnDisable()
    {
        _birdShooter.EnemyKilled -= AddScore;
    }

    public void AddScore()
    {
        _score++;
        ScoreChanged?.Invoke(_score);
    }

    public void Reset()
    {
        _score = 0;
        ScoreChanged?.Invoke(_score);
    }
}

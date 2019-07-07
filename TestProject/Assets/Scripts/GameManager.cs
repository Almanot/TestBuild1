using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public delegate void EnemyDown();
public delegate void EnemyCreated();
public class GameManager : MonoBehaviour
{
    public GameObject MainPlayer;
    public event EnemyDown EnemyMinus;
    public event EnemyDown EnemyPlus;
    public Text RecordBoard;
    public static GameManager instance;
    public int PlayerScorePoints { get; private set; }
    public int CurrentEnemyCount = 0;
    public int SceneMaxEnemyCount;
    public int CurrentBonusCount = 0;
    public int SceneMaxBonusCount;

    private void Awake()
    {
        PlayerScorePoints = 0;
        instance = this;
        EnemyMinus += SubtractOneEnemy;
    }

    public void AddPointsToScore(int value)
    {
        PlayerScorePoints += value;
        UpdateScore();
    }

    void UpdateScore()
    {
        if(RecordBoard) RecordBoard.text = PlayerScorePoints.ToString();
    }

    void SubtractOneEnemy()
    {
        if (CurrentEnemyCount != 0) CurrentEnemyCount -= 1;
    }

    void AddedOneEnemy()
    {

    }
}

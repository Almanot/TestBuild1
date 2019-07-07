using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject EnemyPrefab;

	// Use this for initialization
	void Start ()
    {
        InvokeRepeating("CreateEnemy", 7, 7);
	}

    void CreateEnemy()
    {
        if(GameManager.instance.CurrentEnemyCount < GameManager.instance.SceneMaxEnemyCount)
        {
            Instantiate(EnemyPrefab, transform.position, transform.rotation);
            GameManager.instance.CurrentEnemyCount++;
        }
    }

}

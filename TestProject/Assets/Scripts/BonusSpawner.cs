using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusSpawner : MonoBehaviour
{
    public GameObject BonusPrefab;
    
	// Use this for initialization
	void Start ()
    {
        InvokeRepeating("SpawnBonus", 3, 1);
	}

    void SpawnBonus()
    {
        if(GameManager.instance.CurrentBonusCount < GameManager.instance.SceneMaxBonusCount)
        {
            Instantiate(BonusPrefab, RandomizePosition(), BonusPrefab.transform.rotation);
            GameManager.instance.CurrentBonusCount++;
        }
    }

    Vector3 RandomizePosition()
    {
        Vector3 vector = Random.insideUnitSphere * 2;
        vector += transform.position;
        vector.y = transform.position.y;
        return vector;
    }
}

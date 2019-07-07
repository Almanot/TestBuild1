using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionTarget : MonoBehaviour {

    public int PointsCost = 10;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            GameManager.instance.AddPointsToScore(PointsCost);
            GameManager.instance.CurrentBonusCount--;
            GetComponentInChildren<ParticleSystem>().Play();
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<MeshCollider>().enabled = false;
            Invoke("Destroy", 0.5f);
        }
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}

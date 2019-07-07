using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialEffects : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        GetComponent<Health>().objectTakeDamage += PlayEffect;
		
	}
	
	void PlayEffect(float value)
    {
        GetComponentInChildren<ParticleSystem>().Play();
    }
}

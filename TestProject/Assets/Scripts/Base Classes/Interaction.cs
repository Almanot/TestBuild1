using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour {

    public GameObject currentTarget;
    
    private void OnMouseDown()
    {
        Interact();
    }

    public virtual void Interact()
    {
        Debug.Log("Interaction with" + gameObject.name);
    }

    public virtual void Attack(float damageValue)
    {
        if (!currentTarget)
        {
            Debug.Log("Target is missing");
            return;
        }
        currentTarget.GetComponent<Interaction>().UnderAttack(gameObject, damageValue);
    }

    public virtual void UnderAttack(GameObject attacker, float damageValue)
    {
        if (GetComponent<Health>())
        {
            GetComponent<Health>().TakeDamage(damageValue);
        }
        else Debug.Log("Target " + gameObject.name + " dont have 'Health' component and cant be damaged");
    }
}

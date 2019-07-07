using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Creature : Health
{
    protected override void Die()
    {
        if (gameObject.GetComponent<Moving>())
        {
            gameObject.GetComponent<Moving>().enabled = false;
        }
        base.Die();
    }
}

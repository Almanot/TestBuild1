using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public delegate void ObjectTakeDamage(float healthPercentage);
public delegate void ObjectDie();

public class Health : MonoBehaviour
{
    public event ObjectDie objectDie;
    public event ObjectTakeDamage objectTakeDamage;
    public GameObject StatsIndikator;
    #region Standart health attributes

    private bool Alive { get; set; }

    [SerializeField]
    private float maximumHealth;
    public float MaximumHealth
    {
        get
        {
            return maximumHealth;
        }
        private set
        {
            maximumHealth = value;
        }
    }
    [SerializeField]
    private float currentHealth;
    public float CurrentHealth
    {
        get
        {
            return currentHealth;
        }
        private set
        {
            currentHealth = value;
        }
    }
    [SerializeField]
    private float defensePoints;
    public float DefensePoints
    {
        get
        {
            return defensePoints;
        }
        private set
        {
            defensePoints = value;
        }
    }

    #endregion

    #region Characteristics
    public float Strength { get; private set; }
    public float Agility { get; private set; }
    public float Endurance { get; private set; }
    public float Wisdom { get; private set; }
    public float intelligence { get; private set; }
    //public float another one { get; private set; }


    //float Weight { get; set; } //not realesed. For future;
    #endregion

    private void Start()
    {
        Alive = true;
        if (!StatsIndikator) Debug.Log("Object for display target info not detected");
        else
        {
            //objectTakeDamage += Temp;
        }
    }

    private void OnMouseEnter()
    {
        StatsIndikator.SetActive(true);
    }

    private void OnMouseExit()
    {
        StatsIndikator.SetActive(false);
    }

    public virtual void TakeDamage(float inputDamage)
    {
        float calculatedDamage = inputDamage - defensePoints; // Calculate damage and subtract defence points
        
        if (calculatedDamage > currentHealth && Alive)
        {
            Die();
        }
        else if (Alive)
        {
            Debug.Log("Character " + gameObject.name + " take damage " + calculatedDamage);
            currentHealth -= calculatedDamage;
            if(objectTakeDamage != null) objectTakeDamage(currentHealth / maximumHealth);
        }
    }

    protected virtual void Die()
    {
        Debug.Log("Character " + gameObject.name + " dead");
        Alive = false;
        if(objectDie != null) objectDie();
        GameManager.instance.CurrentEnemyCount--;
        DestroyObject();
    }

    void DestroyObject()
    {
        Destroy(gameObject);
    }
}

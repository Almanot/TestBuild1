using UnityEngine;
using UnityEngine.UI;

public class Informer : MonoBehaviour
{
    #region Properties
    public GameObject HealthBar;
    public GameObject EnergyBar;
    public GameObject Description;
    public bool ForPlayer;
    #endregion

    // Use this for initialization
    void Start ()
    {
        if (ForPlayer)
        {
            GameManager.instance.MainPlayer.GetComponent<Health>().objectTakeDamage += SetValue;
        }
        else
        {
            gameObject.GetComponentInParent<Health>().objectTakeDamage += SetValue;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetValue(float currentHealth)
    {
        if (HealthBar)
        {
            HealthBar.GetComponent<Image>().fillAmount = currentHealth;
        }
        else
        {
            Debug.LogWarning("Object " + gameObject.name + " dont have reference for health bar");
        }
    }
}

using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Interaction),typeof(NavMeshAgent),typeof(Animator))]
public class EnemyController : MonoBehaviour
{
    private NavMeshAgent agent;
    private GameObject MyTarget;
    private Interaction interact;
    Animator anim;
    
    private float attackDistance = 1.5f;
    public float MyDamage;
    public float attackInterval;
    float distance;

    float timer = 0;
    
    // Use this for initialization
    void Start ()
    {
        if (!(interact = GetComponent<Interaction>())) Debug.LogError("Object " + gameObject.name + " Cant get component interaction");
        if (!(agent = GetComponent<NavMeshAgent>())) Debug.LogError("Object " + gameObject.name + " Cant get component NavMeshAgent");
        if (!(MyTarget = GameManager.instance.MainPlayer)) Debug.LogError("Object " + gameObject.name + " Cant find player");
        anim = GetComponent<Animator>();
    }

    
	void Update ()
    {
        timer += Time.deltaTime;
        if (MyTarget)
        {
            distance = Vector3.Distance(MyTarget.transform.position, transform.position);
            Walk();
            if (distance <= agent.stoppingDistance)
            {
                anim.SetFloat("speedv", 0);
                walking = false;
                Attack(MyDamage);
            }
        }
	}

    void Attack(float damage)
    {
        if(timer >= attackInterval)
        {
            anim.SetTrigger("Attack1h1");
            timer = 0;
            interact.currentTarget = MyTarget;
            interact.Attack(damage);
        }
    }

    bool walking = false;
    void Walk()
    {
        agent.SetDestination(MyTarget.transform.position);
        if (!walking)
        {
            anim.SetFloat("speedv", 1);
            walking = true;
        }
    }
}

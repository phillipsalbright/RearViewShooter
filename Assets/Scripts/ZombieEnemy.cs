using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class ZombieEnemy : MonoBehaviour
{
    public NavMeshAgent nm;
    public Transform target;
    public float range;
    public float attackRange;
    //public float hitForce = 10f;

    /** Can change initial state in inspector */
    public enum AIState { idle, chasing, attacking, dead };
    public AIState aiState;

    public Animator anim;
    public EnemyTarget healthCounter;
    public GameObject model;
    
    // Start is called before the first frame update
    void Start()
    {
        nm.SetDestination(this.transform.position);
        range = 12f;
        attackRange = 2f;
        while (target == null)
        {
            if (GameObject.FindWithTag("Player") != null)
            {
                target = GameObject.FindWithTag("Player").transform;
            }
        }
        StartCoroutine(Follow());
    }

    void FixedUpdate()
    {
        if (healthCounter.health <= 0)
        {

            nm.SetDestination(this.transform.position);
            aiState = AIState.dead;
            StartCoroutine(Death());
        }
    }


    IEnumerator Follow()
    {
        float distance;
        while(true)
        {
            switch(aiState)
            {
                case AIState.idle:
                    if (Vector3.Distance(target.position, this.transform.position) < range)
                    {
                        aiState = AIState.chasing;
                        anim.SetBool("Chasing", true);
                    }
                    nm.SetDestination(this.transform.position);
                    break;
                case AIState.chasing:
                    distance = Vector3.Distance(target.position, this.transform.position);
                    if (distance > range)
                    {
                        aiState = AIState.idle;
                        anim.SetBool("Chasing", false);
                    }
                    if (distance < attackRange)
                    {
                        aiState = AIState.attacking;
                        anim.SetBool("Attacking", true);
                    }
                    nm.SetDestination(target.position);
                    break;
                case AIState.attacking:
                    nm.SetDestination(this.transform.position);
                    distance = Vector3.Distance(target.position, this.transform.position);
                    if (distance > attackRange)
                    {
                        aiState = AIState.chasing;
                        anim.SetBool("Attacking", false);
                    } else
                    {
                        target.GetComponent<PlayerHealth>().TakeDamage(5f);
                        /** maybe add force
                        Rigidbody r = target.GetComponent<Rigidbody>();
                        r.AddForce(-r.normal * hitForce);
                        */
                    }
                    break;
                case AIState.dead:
                    break;
            }
            yield return new WaitForSeconds(.4f);
        }
    }

    IEnumerator Death()
    {
        anim.SetBool("Dead", true);
        /** Figure out way to make dead body not collide */
        /** Might be unnecessary now */
        this.gameObject.GetComponent<Rigidbody>().detectCollisions = false;
        model.transform.SetParent(null);
        nm.GetComponentInParent<Transform>().position += new Vector3(100, 100, 100);
        yield return new WaitForSeconds(30f);
        Destroy(model);
        Destroy(this.gameObject);
    }
}

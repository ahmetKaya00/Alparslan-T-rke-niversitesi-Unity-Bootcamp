using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour
{
    
    [SerializeField] private Transform Player;
    private NavMeshAgent agent;
    public float followingDistance = 10f;
    public float attackRange = 1.5f;
    public GameObject zombi;

    private Animator animator;
    private bool isAttacking = false;
    private int saldiri;
    public GameObject EkranFlas;
    public AudioSource[] sound;
    public int vurmaSesi;


    private float attackCooldown = 1.5f;
    private float currentCooldown = 0;


    private void Start()
    {

        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        InvokeRepeating("RandomMovement", 0f, 2f);
    }
    private void Update()
    {
        if(Player != null)
        {
            float distanceToTarget = Vector3.Distance(transform.position, Player.position);

            if(distanceToTarget <= attackRange)
            {
                Attack();
            }
            else if(distanceToTarget <= followingDistance)
            {
                ChaseTarget();
            }
            else
            {
                StopChasing();
            }
        }
        if(currentCooldown > 0)
        {
            currentCooldown -= Time.deltaTime;
        }
        else
        {
            isAttacking = false;
        }
    }
    void RandomMovement()
    {
        if (!agent.hasPath)
        {
            Vector3 randomDirection = Random.insideUnitSphere * 10f;
            randomDirection += transform.position;
            NavMeshHit hit;
            NavMesh.SamplePosition(randomDirection, out hit, 10f, NavMesh.AllAreas);
            agent.SetDestination(hit.position);
        }
    }

    void ChaseTarget()
    {
        agent.SetDestination(Player.position);
        animator.SetBool("Walking", true);
        animator.SetBool("Attacking", false);
    }

    void StopChasing()
    {
        agent.ResetPath();
        animator.SetBool("Walking", false);
        animator.SetBool("Attacking", false);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Attack();
        }
    }

    void Attack()
    {
        animator.SetBool("Walking", false);
        animator.SetBool("Attacking", true);
        float distanceToTarget = Vector3.Distance(transform.position, Player.position);

        if (distanceToTarget < 2f &&!isAttacking && KalanCan.OyuncuCan > 0)
        {

            isAttacking = true;
            KalanCan.OyuncuCan -= 1;
            currentCooldown = attackCooldown;

            if(KalanCan.OyuncuCan > 0)
            {
                int randomSoundIndex = Random.Range(0, sound.Length);
                sound[randomSoundIndex].Play();
                StartCoroutine(ActiveAndDeactiveFlash());
            }
        }
    }
    IEnumerator ActiveAndDeactiveFlash()
    {
        EkranFlas.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        EkranFlas.SetActive(false);
    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class EnemyAI : MonoBehaviour
{

    [SerializeField] Transform playerTarget;
    NavMeshAgent nMA;
    [SerializeField] float ChaseRange = 5f;
    float distanceToTarget = Mathf.Infinity;
    bool isAggro = false;
    [SerializeField] float turnSpeed = 5f;
    Animator animator;
            



    // Start is called before the first frame update
    void Start()
    {
        nMA = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<EnemyHealth>().IsDead())
        {
            enabled = false;
            nMA.enabled = false;
            Destroy(gameObject, 5);
        }


        distanceToTarget = Vector3.Distance(playerTarget.position, transform.position);

        if (isAggro)
        {
            EngageTarget();

        }

        else if (distanceToTarget <= ChaseRange)
        {
            isAggro = true;
        }

    }

    private void EngageTarget()
    {
        FaceTarget();

        if (distanceToTarget >= nMA.stoppingDistance)
        {
            chasePlayer();
        }

        else if (distanceToTarget <= nMA.stoppingDistance)
        {
            AttackPlayer();
        }
    }

    private void chasePlayer()
    {
        animator.SetBool("isWalking", true);
        animator.SetBool("isAttacking", false);
        nMA.SetDestination(playerTarget.transform.position);
        
    }

    private void AttackPlayer()
    {
        animator.SetBool("isAttacking", true);
        
        print("Attacking");
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, ChaseRange);

    }

    void FaceTarget()
    {
        Vector3 Direction  = (playerTarget.position - transform.position).normalized;
        Quaternion lookrotaion = Quaternion.LookRotation(new Vector3(Direction.x, 0, Direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookrotaion, Time.deltaTime * turnSpeed);
    }
    
   public void OnDamageTaken()
    {
        isAggro = true;
    }



}

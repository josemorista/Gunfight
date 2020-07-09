using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
  // Start is called before the first frame update
  public float lookRadius = 10.0f;
  private bool hasAttacked = false, isAlive = true;
  private float timeToAttack = 0.5f, attackTime, timeToDisableColision = 0.8f, disableColisionTime;
  public Transform target;
  NavMeshAgent agent;
  Animator animator;

  void onDrawGizmosSelected()
  {
    Gizmos.color = Color.red;
    Gizmos.DrawWireSphere(transform.position, lookRadius);
  }
  void Start()
  {
    animator = GetComponentInChildren<Animator>();
    agent = GetComponent<NavMeshAgent>();
  }

  void Hit()
  {
    if (isAlive)
    {
      agent.ResetPath();
      isAlive = false;
      animator.SetTrigger("Die");
      Debug.Log("Bye life!");
      disableColisionTime = Time.time + timeToDisableColision;
    }
  }
  void FaceTarget()
  {
    Vector3 direction = (target.position - transform.position).normalized;
    Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
    transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
  }

  // Update is called once per frame
  void Update()
  {
    if (isAlive)
    {
      float distanceToTarget = Vector3.Distance(target.position, transform.position);
      if (distanceToTarget <= lookRadius)
      {
        agent.SetDestination(target.position);
        if (distanceToTarget <= agent.stoppingDistance)
        {
          FaceTarget();
          if (!hasAttacked)
          {
            hasAttacked = true;
            animator.SetTrigger("Attack");
            attackTime = Time.time + timeToAttack;
          }
          else if (Time.time >= attackTime)
          {
            target.SendMessage("Die", SendMessageOptions.DontRequireReceiver);
          }
        }
      }

      float speed = agent.velocity.magnitude / agent.speed;
      animator.SetFloat("MovementSpeed", speed, .2f, Time.deltaTime);
    }
    else
    {
      if (Time.time >= disableColisionTime)
      {
        GetComponent<Rigidbody>().detectCollisions = false;
      }
    }
  }
}

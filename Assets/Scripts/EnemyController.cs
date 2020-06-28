using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
  // Start is called before the first frame update
  public float lookRadius = 10.0f;
  private bool hasAttacked = false;
  public Transform target;
  NavMeshAgent agent;

  void onDrawGizmosSelected()
  {
    Gizmos.color = Color.red;
    Gizmos.DrawWireSphere(transform.position, lookRadius);
  }
  void Start()
  {
    agent = GetComponent<NavMeshAgent>();
  }

  void Hit()
  {
    Debug.Log("Bye life!");
    Destroy(gameObject, 0.2f);
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
          Debug.Log("Attack!");
        }
      }
    }


  }
}

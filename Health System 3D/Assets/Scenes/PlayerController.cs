using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private Animator animator;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Ground"))
                {
                    MoveTo(hit.point);
                }
            }
        }

        bool isMoving = navMeshAgent.velocity.magnitude > 0.1f;

        animator.SetBool("IsRunning", isMoving);
    }

    void MoveTo(Vector3 destination)
    {
        navMeshAgent.SetDestination(destination);
    }
}
using UnityEngine;
using UnityEngine.AI;

public class ClickToMove : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private Transform platform;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        // Ensure there is a NavMeshAgent component attached to the GameObject
        if (navMeshAgent == null)
        {
            Debug.LogError("NavMeshAgent component not found on GameObject.");
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse button clicked
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // Check if the hit point is on a valid NavMesh surface
                if (hit.collider.CompareTag("Ground"))
                {
                    MoveTo(hit.point);
                }
                else if (hit.collider.CompareTag("MovingPlatform"))
                {
                    StandOnMovingPlatform(hit.collider.transform);
                }
            }
        }
    }

    void MoveTo(Vector3 destination)
    {
        // Set destination for regular movement
        navMeshAgent.SetDestination(destination);

        // Release player from the moving platform if it was standing on it
        if (platform != null)
        {
            ReleaseFromMovingPlatform();
        }
    }

    void StandOnMovingPlatform(Transform movingPlatform)
    {
        // Set the player as a child of the moving platform
        platform = movingPlatform;
        transform.parent = platform;

        // Disable NavMeshAgent while standing on the platform
        navMeshAgent.enabled = false;
    }

    void ReleaseFromMovingPlatform()
    {
        // Release the player from being a child of the moving platform
        transform.parent = null;
        platform = null;

        // Enable NavMeshAgent after releasing from the platform
        navMeshAgent.enabled = true;
    }
}
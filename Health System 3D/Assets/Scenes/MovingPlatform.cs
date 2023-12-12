using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform Target1;
    public Transform Target2;
    public float speed = 2f;
    public float delayTime = 1f; // Adjust the delay time as needed

    private bool movingToA = true;
    private float delayTimer = 0f;

    void Update()
    {
        if (delayTimer > 0f)
        {
            // If delay timer is active, decrease it
            delayTimer -= Time.deltaTime;
        }
        else
        {
            // If not delaying, move the platform
            MovePlatform();
        }
    }

    void MovePlatform()
    {
        Vector3 targetPosition = movingToA ? Target1.position : Target2.position;

        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

        if (transform.position == targetPosition)
        {
            // Start delaying when reaching the target
            delayTimer = delayTime;

            // Change direction when the delay is over
            movingToA = !movingToA;
        }
    }
}
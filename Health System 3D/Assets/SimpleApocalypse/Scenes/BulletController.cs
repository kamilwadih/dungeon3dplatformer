using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 10f;

    void Update()
    {
        // Move the bullet forward
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    // Called when the Collider other enters the trigger.
    private void OnTriggerEnter(Collider other)
    {
        // Check if the collided object has the "Enemy" tag
        if (other.CompareTag("Enemy"))
        {
            // Handle the collision with the enemy (you can add your logic here)
            Debug.Log("Bullet hit an enemy!");

            // Destroy the enemy
            Destroy(other.gameObject);

            // Destroy the bullet
            Destroy(gameObject);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    public Transform gunTransform; // The transform where the bullet will be spawned
    public GameObject bulletPrefab; // The bullet prefab
    public float cooldownDuration = 1f; // Cooldown duration before the bullet can be spawned again
    public float delayBeforeShoot = 0.5f; // Delay before instantiating the bullet after the shooting animation is triggered

    private Animator animator;
    private float cooldownTimer;

    private void Start()
    {
        // Assuming the Animator component is attached to the same GameObject
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Update the cooldown timer
        cooldownTimer -= Time.deltaTime;

        // Check if the space button is pressed, the cooldown has elapsed, and the shooting animation is not already playing
        if (Input.GetKeyDown(KeyCode.Space) && cooldownTimer <= 0f && !animator.GetCurrentAnimatorStateInfo(0).IsName("ShootingAnimation"))
        {
            // Trigger the shooting animation by setting the 'Shoot' trigger
            animator.SetTrigger("Shoot");

            // Reset the cooldown timer
            cooldownTimer = cooldownDuration;

            // Start a coroutine to delay the instantiation of the bullet
            StartCoroutine(ShootWithDelay());
        }
    }

    IEnumerator ShootWithDelay()
    {
        // Wait for the specified delay before instantiating the bullet
        yield return new WaitForSeconds(delayBeforeShoot);

        // Instantiate a bullet at the gun's position and rotation
        InstantiateBullet();
    }

    void InstantiateBullet()
    {
        // Instantiate a bullet at the gun's position and rotation
        Instantiate(bulletPrefab, gunTransform.position, gunTransform.rotation);
    }
}
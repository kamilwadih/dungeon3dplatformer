using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    public Transform gunTransform;
    public GameObject bulletPrefab;
    public float cooldownDuration = 1f;
    public float delayBeforeShoot = 0.5f;

    private Animator animator;
    private float cooldownTimer;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        cooldownTimer -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && cooldownTimer <= 0f && !animator.GetCurrentAnimatorStateInfo(0).IsName("ShootingAnimation"))
        {
            animator.SetTrigger("Shoot");

            cooldownTimer = cooldownDuration;

            StartCoroutine(ShootWithDelay());
        }
    }

    IEnumerator ShootWithDelay()
    {
        yield return new WaitForSeconds(delayBeforeShoot);

        InstantiateBullet();
    }

    void InstantiateBullet()
    {
        Instantiate(bulletPrefab, gunTransform.position, gunTransform.rotation);
    }
}
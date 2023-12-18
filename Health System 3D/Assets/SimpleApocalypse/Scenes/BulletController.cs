using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 10f;

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boss"))
        {
            Debug.Log("Bullet hit the boss!");

            BossHealth bossHealth = other.gameObject.GetComponent<BossHealth>();
            if (bossHealth != null)
            {
                bossHealth.TakeHit();
            }

            Destroy(gameObject);
        }
        else if (other.CompareTag("Enemy"))
        {
            Debug.Log("Bullet hit an enemy!");

            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
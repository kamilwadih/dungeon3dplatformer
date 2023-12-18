using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int requiredHits = 10;
    private int currentHits = 0;

    public void TakeHit()
    {
        currentHits++;

        if (currentHits >= requiredHits)
        {
            DestroyBoss();
        }
    }

    void DestroyBoss()
    {
        Debug.Log("Boss destroyed!");
        Destroy(gameObject);
    }
}
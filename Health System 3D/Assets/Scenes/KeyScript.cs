using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    private bool isHidden = false;

    public bool IsHidden()
    {
        return isHidden;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            ToggleVisibility();
        }
    }

    void ToggleVisibility()
    {
        isHidden = !isHidden;
        gameObject.SetActive(!isHidden);

        if (isHidden)
        {
            Debug.Log("Key Collected");
        }
    }
}
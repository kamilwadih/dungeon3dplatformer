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
        // Check for right mouse button click
        if (Input.GetMouseButtonDown(1))
        {
            // Check if the mouse is over the key
            if (IsMouseOverKey())
            {
                ToggleVisibility();
            }
        }
    }

    void ToggleVisibility()
    {
        isHidden = !isHidden;

        if (isHidden)
        {
            gameObject.SetActive(false);
            Debug.Log("Key Collected");
        }
        else
        {
            gameObject.SetActive(true);
        }
    }

    bool IsMouseOverKey()
    {
        // Raycast to check if the mouse is over the key
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
        {
            return true;
        }

        return false;
    }
}
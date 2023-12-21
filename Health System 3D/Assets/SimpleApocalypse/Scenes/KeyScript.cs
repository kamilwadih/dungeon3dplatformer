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
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
        {
            return true;
        }

        return false;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] private GameObject keyObject;
    [SerializeField] private GameObject doorObject;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            ToggleDoorVisibility();
        }
    }

    private void ToggleDoorVisibility()
    {
        KeyScript keyScript = keyObject.GetComponent<KeyScript>();
        if (keyScript != null && keyScript.IsHidden())
        {
            doorObject.SetActive(!doorObject.activeSelf);

            if (doorObject.activeSelf)
            {

            }
            else
            {
                Debug.Log("Door is opened");
            }
        }
        else
        {
            Debug.Log("Collect the key first!");
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] private GameObject keyObject;
    [SerializeField] private GameObject doorObject;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1)) // Change KeyCode.Space to the desired button
        {
            ToggleDoorVisibility();
        }
    }

    private void ToggleDoorVisibility()
    {
        if (keyObject == null || doorObject == null)
        {
            Debug.LogError("Key or Door GameObjects are not assigned in the inspector.");
            return;
        }

        // Check if the key is hidden
        KeyScript keyScript = keyObject.GetComponent<KeyScript>();
        if (keyScript != null && keyScript.IsHidden())
        {
            // Toggle the door's visibility
            doorObject.SetActive(!doorObject.activeSelf);

            if (doorObject.activeSelf)
            {
                // The door is now visible, you can add additional logic here
                Debug.Log("Door is visible");
            }
            else
            {
                // The door is now hidden, you can add additional logic here
                Debug.Log("Door is hidden");
            }
        }
        else
        {
            Debug.Log("Collect the key first!");
        }
    }
}
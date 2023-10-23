using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject[] characters; // An array of game objects representing human characters
    public Camera mainCamera;

    public enum ShotType
    {
        BustUp,
        WholeBody,
        SideProfile
    }
    public void Update()
    {
        for (int i = 1; i <= 5; i++)
        {
            if (Input.GetKeyDown(i.ToString()))
            {
                int characterIndex = i - 1; // Convert key (1-5) to array index (0-4)
                MoveCameraToCharacter(characters[characterIndex], ShotType.BustUp); // Change the shot type if needed
            }
        }
    }
    public void MoveCameraToCharacter(GameObject character, ShotType shotType)
    {
        if (mainCamera == null)
        {
            Debug.LogError("Camera not assigned to the script.");
            return;
        }

        if (character == null)
        {
            Debug.LogError("Character GameObject is null.");
            return;
        }

        Vector3 cameraPosition = character.transform.position;
        Quaternion cameraRotation = Quaternion.LookRotation(-character.transform.forward); // Look at the negative Z direction

        switch (shotType)
        {
            case ShotType.BustUp:
                cameraPosition += character.transform.forward * 1.2f; // Adjust the distance as needed
                cameraPosition.y += 1.1f; // Adjust the distance as needed
               
                break;

            case ShotType.WholeBody:
                cameraPosition += character.transform.forward * 5f; // Adjust the distance as needed
                break;

            case ShotType.SideProfile:
                cameraPosition += character.transform.right * 2f; // Move to the side
                break;
        }

        mainCamera.transform.position = cameraPosition;
        mainCamera.transform.rotation = cameraRotation;
    }
}



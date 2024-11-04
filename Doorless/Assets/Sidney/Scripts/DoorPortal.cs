using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorPortal : MonoBehaviour
{
    public string doorID; // Unique identifier for matching doors
    public Transform teleportLocation; // The location to teleport the player to
    public float teleportCooldown = 1.0f; // Cooldown in seconds

    private bool canTeleport = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && canTeleport)
        {
            Debug.Log("Player entered the trigger.");

            DoorPortal[] doors = FindObjectsOfType<DoorPortal>();
            foreach (DoorPortal door in doors)
            {
                if (door != this && door.doorID == this.doorID)
                {
                    if (door.teleportLocation != null)
                    {
                        // Teleport the player to the specified teleport location
                        other.transform.position = door.teleportLocation.position;

                        // Log current rotation before change
                        Debug.Log("Current Player Rotation: " + other.transform.eulerAngles);
                        Debug.Log("Teleport Location Rotation: " + door.teleportLocation.eulerAngles);

                        // Rotate the player using the CameraHandle's method
                        CameraHandle cameraHandle = other.GetComponentInChildren<CameraHandle>();
                        if (cameraHandle != null)
                        {
                            cameraHandle.SetPlayerRotation(door.teleportLocation.eulerAngles.y);
                        }

                        // Start cooldown to prevent immediate re-teleporting
                        StartCoroutine(TeleportCooldown());

                        break;
                    }
                    else
                    {
                        Debug.Log("No teleport location assigned to matching door.");
                    }
                }
            }
        }
    }

    private IEnumerator TeleportCooldown()
    {
        canTeleport = false;
        yield return new WaitForSeconds(teleportCooldown);
        canTeleport = true;
    }
}

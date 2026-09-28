using System.Diagnostics;
using UnityEngine;

public class ControlSwitch : MonoBehaviour
{
    public Door finalDoor;
    public GameObject interactPrompt;

    private bool playerNearby = false;
    private bool activated = false;

    void Update()
    {
        if (playerNearby && !activated)
        {
            interactPrompt.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                activated = true;
                interactPrompt.SetActive(false);
                finalDoor.OpenDoor();
            }
        }
        else
        {
            interactPrompt.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<PlayerMovement>() != null)
        {
            playerNearby = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponentInParent<PlayerMovement>() != null)
        {
            playerNearby = false;
        }
    }
}
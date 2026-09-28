
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public Door door;
    private bool activated = false;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Something entered: " + other.name);

        if (!activated && other.CompareTag("Crate"))
        {
            Debug.Log("Crate detected!");

            activated = true;
            door.OpenDoor();
        }
    }
}
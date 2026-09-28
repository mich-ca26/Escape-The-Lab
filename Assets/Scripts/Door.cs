using UnityEngine;

public class Door : MonoBehaviour
{
    public Transform leftDoor;
    public Transform rightDoor;

    public float openDistance = 1.5f;
    public float openSpeed = 2f;

    private Vector3 leftOpenPosition;
    private Vector3 rightOpenPosition;
    private bool opening = false;

    private Collider doorCollider;

    void Start()
    {
        leftOpenPosition = leftDoor.localPosition + Vector3.left * openDistance;
        rightOpenPosition = rightDoor.localPosition + Vector3.right * openDistance;

        doorCollider = GetComponent<Collider>();
    }

    void Update()
    {
        if (opening)
        {
            leftDoor.localPosition = Vector3.MoveTowards(
                leftDoor.localPosition,
                leftOpenPosition,
                openSpeed * Time.deltaTime
            );

            rightDoor.localPosition = Vector3.MoveTowards(
                rightDoor.localPosition,
                rightOpenPosition,
                openSpeed * Time.deltaTime
            );
        }
    }

    public void OpenDoor()
    {
        opening = true;

        if (doorCollider != null)
        {
            doorCollider.enabled = false;
        }
    }
}
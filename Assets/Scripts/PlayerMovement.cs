using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float mouseSensitivity = 2f;
    public float jumpForce = 5.5f;

    private Rigidbody rb;
    private Transform cameraTransform;
    private Collider playerCollider;
    private Animator animator;

    private float verticalRotation = 0f;
    private bool jumpRequested = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cameraTransform = GetComponentInChildren<Camera>().transform;
        playerCollider = GetComponent<Collider>();
        animator = GetComponentInChildren<Animator>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // mouse look function
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        transform.Rotate(Vector3.up * mouseX);

        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -80f, 80f);

        cameraTransform.localRotation =
            Quaternion.Euler(verticalRotation, 0f, 0f);

        // jump function
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            jumpRequested = true;
            animator.SetBool("IsJumping", true);
        }

        if (IsGrounded() && !jumpRequested)
        {
            animator.SetBool("IsJumping", false);
        }
    }

    void FixedUpdate()
    {
        // WASD movement
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 movement = transform.right * x + transform.forward * z;

        animator.SetFloat("Speed", movement.magnitude);

        rb.MovePosition(
            rb.position + movement * moveSpeed * Time.fixedDeltaTime
        );

        // jump
        if (jumpRequested)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumpRequested = false;
        }
    }

    bool IsGrounded()
    {
        Bounds bounds = playerCollider.bounds;

        Vector3 rayOrigin = new Vector3(
            bounds.center.x,
            bounds.min.y + 0.05f,
            bounds.center.z
        );

        return Physics.Raycast(
            rayOrigin,
            Vector3.down,
            0.15f
        );
    }
}
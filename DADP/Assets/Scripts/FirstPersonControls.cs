using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class FirstPersonControls : MonoBehaviour
{
    public float moveSpeed;
    public float lookSpeed;
    public float gravity = -9.81f;
    public float jumpHeight = 1.0f;
    public Transform playerCamera;

    private Vector2 moveInput;
    private Vector2 lookInput;
    private float verticalLookRotation = 0f;
    private Vector3 velocity;
    private CharacterController characterController;

    public float sprintSpeedMultiplier = 10.0f; // Multiplier for sprinting speed
    public KeyCode sprintKey = KeyCode.LeftShift; // Key to trigger sprinting
    private bool isSprinting = false; // Boolean to track if the player is sprinting

<<<<<<< Updated upstream
=======
    [Header("SHOOTING SETTINGS")]
    [Space(5)]
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float projectileSpeed = 20f;
    public float pickUpRange = 3f;
    private bool holdingGun = false;

    [Header("PICKING UP SETTINGS")]
    [Space(5)]
    public Transform holdPosition;
    private GameObject heldObject;

>>>>>>> Stashed changes
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void OnEnable()
<<<<<<< Updated upstream
    { // Create a new instance of the input actions
        var playerInput = new Controls();

        // Enable the input actions
        playerInput.Player.Enable();

        // Subscribe to the movement input events
        playerInput.Player.Movement.performed += ctx => moveInput = ctx.ReadValue<Vector2>(); // Update moveInput when movement input is performed
        playerInput.Player.Movement.canceled += ctx => moveInput = Vector2.zero; // Reset moveInput when movement input is canceled

        // Subscribe to the look input events
        playerInput.Player.Look.performed += ctx => lookInput = ctx.ReadValue<Vector2>(); // Update lookInput when look input is performed
        playerInput.Player.Look.canceled += ctx => lookInput = Vector2.zero; // Reset lookInput when look input is canceled

        // Subscribe to the jump input event
        playerInput.Player.Jump.performed += ctx => Jump(); // Call the Jump method when jump input is performed
=======
    {
        var playerInput = new Controls();
        playerInput.Player.Enable();
        playerInput.Player.Movement.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        playerInput.Player.Movement.canceled += ctx => moveInput = Vector2.zero;
        playerInput.Player.Look.performed += ctx => lookInput = ctx.ReadValue<Vector2>();
        playerInput.Player.Look.canceled += ctx => lookInput = Vector2.zero;
        playerInput.Player.Jump.performed += ctx => Jump();
        playerInput.Player.Shoot.performed += ctx => Shoot();
        playerInput.Player.PickUp.performed += ctx => PickUpObject();
>>>>>>> Stashed changes
    }

    private void Update()
    {
        Move();
        LookAround();
        ApplyGravity();
    }

    public void Move()
    {
        isSprinting = UnityEngine.Input.GetKey(sprintKey);

        Vector3 move = new Vector3(moveInput.x, 0, moveInput.y);
        move = transform.TransformDirection(move);

        float currentSpeed = isSprinting ? moveSpeed * sprintSpeedMultiplier : moveSpeed;

        characterController.Move(move * currentSpeed * Time.deltaTime);
    }

    public void LookAround()
    {
        float LookX = lookInput.x * lookSpeed;
        float LookY = lookInput.y * lookSpeed;

        transform.Rotate(0, LookX, 0);

        verticalLookRotation -= LookY;
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -90f, 90f);

        playerCamera.localEulerAngles = new Vector3(verticalLookRotation, 0, 0);
    }

    public void ApplyGravity()
    {
        if (characterController.isGrounded && velocity.y < 0)
        {
            velocity.y = -0.5f;
        }

        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }

    public void Jump()
    {
        if (characterController.isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }
<<<<<<< Updated upstream
=======

    public void Shoot()
    {
        if (holdingGun == true)
        {
            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            rb.velocity = firePoint.forward * projectileSpeed;
            Destroy(projectile, 3f);
        }
    }

    public void PickUpObject()
    {
        if (heldObject != null)
        {
            heldObject.GetComponent<Rigidbody>().isKinematic = false;
            heldObject.transform.parent = null;
            holdingGun = false;
        }

        Ray ray = new Ray(playerCamera.position, playerCamera.forward);
        RaycastHit hit;
        Debug.DrawRay(playerCamera.position, playerCamera.forward * pickUpRange, Color.red, 2f);
        if (Physics.Raycast(ray, out hit, pickUpRange))
        {
            if (hit.collider.CompareTag("PickUp"))
            {
                heldObject = hit.collider.gameObject;
                heldObject.GetComponent<Rigidbody>().isKinematic = true;
                heldObject.transform.position = holdPosition.position;
                heldObject.transform.rotation = holdPosition.rotation;
                heldObject.transform.parent = holdPosition;
            }
            else if (hit.collider.CompareTag("Gun"))
            {
                heldObject = hit.collider.gameObject;
                heldObject.GetComponent<Rigidbody>().isKinematic = true;
                heldObject.transform.position = holdPosition.position;
                heldObject.transform.rotation = holdPosition.rotation;
                heldObject.transform.parent = holdPosition;
                holdingGun = true;
            }
        }
    }
>>>>>>> Stashed changes
}

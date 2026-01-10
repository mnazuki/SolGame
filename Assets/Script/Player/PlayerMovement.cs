using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float PlayerSpeed = 1.5f;
    public float PlayerRunning = 2f;
    public float PlayerJump = 10f;

    public Transform cameraTransform;

    private Rigidbody rb;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 move = new Vector3(x, 0f, z).normalized;
        rb.linearVelocity = new Vector3(move.x * PlayerSpeed, rb.linearVelocity.y, move.z * PlayerSpeed);

        PlayerSpeed = Mathf.Clamp(PlayerSpeed, 1.5f, 2.5f);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            PlayerSpeed *= PlayerRunning;
        }
        else
        {
            PlayerSpeed = 1.5f;
        }
    }
}
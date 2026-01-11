using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float PlayerSpeed = 1.5f;
    public float PlayerRunning = 2f;
    public float PlayerJump = 10f;
    [SerializeField]private float currentSpeed;
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
       if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = PlayerSpeed * PlayerRunning;
        }
        else
        {
            currentSpeed = PlayerSpeed;
        }
        
    }

    void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        rb.transform.rotation = Quaternion.Euler(0f, cameraTransform.eulerAngles.y, 0f);
        Vector3 move = (transform.forward * z) + (transform.right * x);
        move = move.normalized;
        
        rb.linearVelocity = new Vector3(move.x * currentSpeed, rb.linearVelocity.y, move.z * currentSpeed);
    }

}
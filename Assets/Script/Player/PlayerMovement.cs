using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    enum PlayerState { Idle, Walking, Running, Grounded }

    PlayerState state;

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
        UpdateState();  
        print(state);
    }

    void UpdateState()
    {
        switch (state)
        {
            case PlayerState.Idle:
                if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
                {
                    state = PlayerState.Walking;
                }
                break;
            case PlayerState.Walking:
                if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
                {
                    state = PlayerState.Idle;
                    currentSpeed = PlayerSpeed;
                }
                else if (Input.GetKey(KeyCode.LeftShift))
                {
                    state = PlayerState.Running;
                    currentSpeed = PlayerSpeed * PlayerRunning;
                }
                else
                {
                    currentSpeed = PlayerSpeed;
                }
                break;
            case PlayerState.Running:
                if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
                {
                    state = PlayerState.Idle;
                    currentSpeed = PlayerSpeed;
                }
                else if (!Input.GetKey(KeyCode.LeftShift))
                {
                    state = PlayerState.Walking;
                    currentSpeed = PlayerSpeed;
                }
                break;
            case PlayerState.Grounded:
                // Grounded logic can be added here
                break;
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
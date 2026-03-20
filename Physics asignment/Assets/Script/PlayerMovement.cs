using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Inspector values 
    public float moveSpeed = 60f;
    public float jumpForce = 100f;

    private Rigidbody rb;
    private Animator animator;

    // Input values ko store karne ke liye variables
    private float horizontalInput;
    private float verticalInput;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update har frame mein chalta hai, ismein sirf input aur animation check hoga
    void Update()
    {
        // Input values read karo
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        // Player ki move karne ki taqat check karte hain
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);

        // Animation Control
        if (movement.magnitude > 0.1f)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

        // Jump: Input check Update mein hoga
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Jump force FixedUpdate mein lagate hain
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    // FixedUpdate physics ke hisaab se chalta hai, ismein movement code daalo
    void FixedUpdate()
    {
        // Movement velocity set karna (X aur Z axis par movement ke liye)
        rb.linearVelocity = new Vector3(horizontalInput * moveSpeed, rb.linearVelocity.y, verticalInput * moveSpeed);
    }
}
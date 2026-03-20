using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Score aur UI control ke liye

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;
    public float jumpForce = 7f;

    [Header("UI Cheezein")]
    public Text scoreTextUI;         // Score likhne wali jagah
    public Text levelTextUI;         // Level number likhne wali jagah

    [Header("Screens")]
    public GameObject gameOverPanel;     // Game Over wali screen
    public GameObject winImage;          // Access Granted wali image (Green Box)
    public GameObject levelCompleteMenu; // Normal Level Complete buttons (Next/Restart)
    public GameObject finalWinScreen;    // Final Level Win Screen (You Won)

    private Rigidbody rb;
    private bool isGameStopped = false;
    private bool isGrounded = true;

    private int currentScore = 0; // Score ginnay ke liye

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        UpdateScoreUI(); // Shuru mein 0 dikhao
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        // Level Text set karne ka logic
        if (levelTextUI != null)
        {
            string sceneName = SceneManager.GetActiveScene().name;

            if (sceneName == "Level1") levelTextUI.text = "LEVEL: 01";
            else if (sceneName == "Level2") levelTextUI.text = "LEVEL: 02";
            else if (sceneName == "Level3") levelTextUI.text = "FINAL LEVEL";
        }
    }

    void Update()
    {
        if (isGameStopped) return;

        // Jump Logic
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

        // Agar Ball gir jaye
        if (transform.position.y < -10f)
        {
            GameOver();
        }
    }

    void FixedUpdate()
    {
        if (isGameStopped) return;
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
    }

    // Takkar (Solid cheezon se)
    void OnCollisionEnter(Collision collision)
    {
        isGrounded = true; // Zameen par wapis agaye

        // 🧱 Normal Firewall / Enemy (Game Over Screen dikhao)
        if (collision.gameObject.CompareTag("Enemy"))
        {
            GameOver();
        }

        // 🟡 Yellow Virus (Current Level Restart - No Screen)
        if (collision.gameObject.CompareTag("Restart"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        // 🔴 Moving Virus (Seedha Level 1 par bhejo)
        if (collision.gameObject.CompareTag("StartOver"))
        {
            SceneManager.LoadScene("Level1");
        }
    }

    // --- Trigger (Guzarne wali Cheezein) ---
    void OnTriggerEnter(Collider other)
    {
        // Agar Blue Virus (Score) mein se guzre
        if (other.gameObject.CompareTag("Score"))
        {
            currentScore += 50; // 50 Number barhao
            UpdateScoreUI();    // Screen par update karo
            Destroy(other.gameObject); // Virus ko gayab kar do
        }

        // Agar Finish Line par pohanch gaye
        if (other.gameObject.CompareTag("Finish"))
        {
            WinGame();
        }
    }

    void UpdateScoreUI()
    {
        if (scoreTextUI != null)
        {
            scoreTextUI.text = "DATA: " + currentScore;
        }
    }

    void GameOver()
    {
        isGameStopped = true;
        rb.isKinematic = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        // Screen Dikhao
        if (gameOverPanel != null) gameOverPanel.SetActive(true);

        // Faltu Text Chupao
        if (scoreTextUI != null) scoreTextUI.gameObject.SetActive(false);
        if (levelTextUI != null) levelTextUI.gameObject.SetActive(false);
    }

    void WinGame()
    {
        isGameStopped = true;
        rb.isKinematic = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        if (winImage != null) winImage.SetActive(true);
        if (scoreTextUI != null) scoreTextUI.gameObject.SetActive(false);
        if (levelTextUI != null) levelTextUI.gameObject.SetActive(false);
        Invoke("ShowMenu", 3f);
    }

    // Yeh function Level Complete hone par chalta hai
    void ShowMenu()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        // Access Granted wali image band karo
        if (winImage != null) winImage.SetActive(false);

        string currentScene = SceneManager.GetActiveScene().name;

        if (currentScene == "Level3")
        {
            // Level 3 hai to "You Won" screen dikhao
            if (finalWinScreen != null) finalWinScreen.SetActive(true);

            // --- NAYA CODE: 3 Second baad Main Menu par jao ---
            Invoke("LoadMainMenu", 3f);
        }
        else
        {
            // Agar Level 1 ya 2 hai to wahi purane buttons dikhao
            if (levelCompleteMenu != null) levelCompleteMenu.SetActive(true);
        }

        // Text UI ko chupana
        if (scoreTextUI != null) scoreTextUI.gameObject.SetActive(false);
        if (levelTextUI != null) levelTextUI.gameObject.SetActive(false);
    }

    // Yeh naya function hai jo Main Menu open karega
    void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
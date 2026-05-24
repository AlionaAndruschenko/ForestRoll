using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject pausePanel;
    private bool isPaused = false;
    private Rigidbody2D ballRb;
    private Vector2 savedVelocity;
    private float savedAngularVelocity;

    void Start()
    {

        ballRb = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused) Resume();
            else Pause();
        }
    }

    public void Pause()
    {
     
        if (ballRb != null)
        {
            savedVelocity = ballRb.linearVelocity;
            savedAngularVelocity = ballRb.angularVelocity;
            ballRb.linearVelocity = Vector2.zero;
            ballRb.angularVelocity = 0f;
        }

        pausePanel.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void Resume()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;

       
        if (ballRb != null)
        {
            ballRb.linearVelocity = savedVelocity;
            ballRb.angularVelocity = savedAngularVelocity;
        }
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
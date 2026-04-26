using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public TextMeshProUGUI attemptsText;
    public GameObject winPanel;
    public GameObject losePanel;
    public int maxAttempts = 3;
    private int attemptsLeft;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        attemptsLeft = maxAttempts;
        UpdateText();
        winPanel.SetActive(false);
        losePanel.SetActive(false);
    }

    public void UseAttempt()
    {
        attemptsLeft--;
        UpdateText();
    }

    public void CheckLose()
    {
        if (attemptsLeft <= 0)
        {
            losePanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    void UpdateText()
    {
        attemptsText.text = "Attempts: " + attemptsLeft;
    }
}
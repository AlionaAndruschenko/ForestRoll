using UnityEngine;

public class HoleTrigger : MonoBehaviour
{
    public GameObject winPanel;

    void Start()
    {
        winPanel.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            winPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
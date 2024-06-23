using UnityEngine;
using TMPro;

public class HHTimerButton : MonoBehaviour
{
    float timer = 0f;
    bool isTimerRunning = true; // Flag to control whether the timer is running or stopped

    public TextMeshProUGUI timerText;

    void Update()
    {
        if (isTimerRunning)
        {
            timer += Time.deltaTime;
            UpdateTimerDisplay();
        }
    }

    void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(timer / 60);
        int seconds = Mathf.FloorToInt(timer % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    // Method to pause the timer
    public void ToggleTimer()
    {
        isTimerRunning = false; // Toggle the timer
    }
}

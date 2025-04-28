using UnityEngine;
using UnityEngine.UI;

public class ClockScript : MonoBehaviour
{
    public Text timerText;

    private float timeElapsed = 0f;

    void Update()
    {
        timeElapsed += Time.deltaTime;  // Увеличиваем время с каждой кадр

        DisplayTime(timeElapsed);  // Обновляем отображение времени
    }

    void DisplayTime(float timeToDisplay)
    {
        float hours = Mathf.FloorToInt(timeToDisplay / 3600);  // Получаем количество часов
        float minutes = Mathf.FloorToInt((timeToDisplay % 3600) / 60);  // Получаем количество минут
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);  // Получаем количество секунд

        timerText.text = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);  // Отображаем в формате HH:MM:SS
    }
}

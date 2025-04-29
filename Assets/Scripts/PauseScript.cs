using UnityEngine;

public class PauseScript : MonoBehaviour
{
    [SerializeField] private GameObject content; // Перетяни сюда объект "Content" из Canvas в инспекторе

    void Start()
    {
        if (content != null)
        {
            content.SetActive(false); // Убедимся, что при старте пауза скрыта
        }
        else
        {
            Debug.LogError("Content is not assigned in the inspector.");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            TogglePause();
        }
    }

    public void OnButtonClick()
    {
        ResumeGame();
    }

    public void OnIntervalSliderChanged(float value)
    {
        // Инвертируем значение слайдера, чтобы слайдер вправо уменьшал скорость, а влево увеличивал
        MoveScript.difficulty = 1.0f - value; 
    }

    private void TogglePause()
    {
        if (content == null) return;

        if (content.activeInHierarchy)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    private void PauseGame()
    {
        content.SetActive(true);
        Time.timeScale = 0.0f;
    }

    private void ResumeGame()
    {
        content.SetActive(false);
        Time.timeScale = 1.0f;
    }
}

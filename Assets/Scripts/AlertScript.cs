using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlertScript : MonoBehaviour
{
    private static Text title;
    private static Text message;
    private static Text button;
    private static GameObject content;  // content должен быть объектом GameObject, а не Text

    public static void Show(string titleText, string messageText, string actionButtonText = "Close")
    {
        // Устанавливаем текст на экране
        title.text = titleText;
        message.text = messageText;
        button.text = actionButtonText;
        
        // Показываем content
        content.SetActive(true);
        
        // Останавливаем время игры
        Time.timeScale = 0.0f;
    }

    void Start()
    {
        // Находим все необходимые компоненты
        Transform c = transform.Find("content");
        title = c.Find("Title").GetComponent<Text>();
        message = c.Find("Message").GetComponent<Text>();
        button = c.Find("Button/Text").GetComponent<Text>();
        content = c.gameObject;  // content - это объект, а не Text

        // Убираем alert при старте игры (по умолчанию скрываем его)
        content.SetActive(false);
    }

    // Обработчик закрытия окна при нажатии Escape или на кнопку
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnActionButtonClick();
        }
    }

    public void OnActionButtonClick()
    {
        content.SetActive(false);
        Time.timeScale = 1.0f;
    }
}

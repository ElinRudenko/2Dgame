using UnityEngine;
using UnityEngine.UI; // Подключение UI библиотеки

public class HealthScript : MonoBehaviour
{
    private Image indicator;

    void Start()
    {
        // Находим компонент Image в дочернем объекте с именем "Indicator"
        indicator = transform.Find("Indicator").GetComponent<Image>();
        
        // Убедимся, что у индикатора выбран метод Fill (например, Horizontal)
        if (indicator != null)
        {
            indicator.fillMethod = Image.FillMethod.Horizontal; // Можно использовать Horizontal или Radial360
        }
    }

    void Update()
    {
        if (indicator != null)
        {
            // Нормируем здоровье на максимальное значение (например, 5), чтобы оно было в диапазоне от 0 до 1
            float healthPercentage = Mathf.Clamp01(BirdScript.health / 5f); // Максимальное здоровье = 5

            // Обновляем fillAmount в зависимости от здоровья
            indicator.fillAmount = healthPercentage;

            // Обновляем цвет индикатора в зависимости от здоровья
            indicator.color = GetHealthColor(healthPercentage);
        }
    }

    // Метод для получения цвета в зависимости от процента здоровья
    private Color GetHealthColor(float healthPercentage)
    {
        if (healthPercentage > 0.5f)  // Зеленый цвет для здоровья больше 50%
        {
            return Color.Lerp(Color.yellow, Color.green, (healthPercentage - 0.5f) * 2); // Линейно интерполируем между желтым и зеленым
        }
        else if (healthPercentage > 0.2f)  // Желтый цвет для здоровья от 20% до 50%
        {
            return Color.Lerp(Color.red, Color.yellow, (healthPercentage - 0.2f) * 5); // Линейно интерполируем между красным и желтым
        }
        else  // Красный цвет для здоровья меньше 20%
        {
            return Color.red;
        }
    }
}

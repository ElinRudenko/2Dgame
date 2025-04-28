using UnityEngine;
using UnityEngine.UI; // Для работы с UI

public class GameUIStats : MonoBehaviour
{
    public Text pipeCountText; // Ссылка на Text для отображения количества труб
    public Text coinCountText; // Ссылка на Text для отображения количества монет
    public Text lumsCountText; // Ссылка на Text для отображения количества Lums

    private int lumsCount = 0;
    private int pipeCount = 0;
    private int coinCount = 0;

    // Метод для увеличения счетчика труб
    public void IncrementPipeCount()
    {
        pipeCount += 12; // При каждом спавне увеличиваем на 12
        UpdateUI();
    }

    // Метод для увеличения счетчика монет
    public void IncrementCoinCount()
    {
        coinCount++;
        UpdateUI();
    }
    public void IncrementLumsCount()
    {
        lumsCount++;
        UpdateUI();
    }

    // Метод для обновления UI
    private void UpdateUI()
    {
        pipeCountText.text = "Pipes: " + pipeCount.ToString();
        coinCountText.text = "Coins: " + coinCount.ToString();
         lumsCountText.text = "Lums: " + lumsCount.ToString(); // Обновляем счетчик Lums
    }
}

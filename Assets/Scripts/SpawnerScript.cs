using System.Collections;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{

    [SerializeField] private GameUIStats gameUIStats; // Ссылка на GameUIStats для обновления UI

    [SerializeField] private GameObject pipePrefab;
    [SerializeField] private GameObject coinsPrefab;

    [SerializeField] private GameObject lumsPrefab; // Префаб для Lums

    private float lumsPeriod = 2.5f; // Период спавна для Lums
    private float lumsTimeout;

    private float period = 9.5f;
    private float timeout;
    private float coinstperiod = 3.4f;
    private float coinstimeout;
    private float coinsMax = 3.0f;

    void Start()
    {
        timeout = 0f;
        coinstimeout = period * 0.5f;
        lumsTimeout = lumsPeriod; // Инициализация таймера для Lums
    }

    void Update()
    {
        timeout -= Time.deltaTime;
        if (timeout < 0)
        {
            timeout = period;
            SpawnPipe(); // Спавн труб
        }

        coinstimeout -= Time.deltaTime;
        if (coinstimeout < 0)
        {
            coinstimeout = coinstperiod;
            SpawnCoins(); // Спавн монет
        }

        lumsTimeout -= Time.deltaTime; // Таймер для Lums
        if (lumsTimeout < 0)
        {
            lumsTimeout = lumsPeriod;
            SpawnLums(); // Спавн Lums
        }
    }


    private void SpawnPipe()
    {
        if (pipePrefab != null)
        {
            GameObject pipe = Instantiate(pipePrefab);
            pipe.transform.position = this.transform.position;

            // Увеличиваем счетчик труб в UI
            if (gameUIStats != null)
            {
                gameUIStats.IncrementPipeCount();
            }
        }
    }

private void SpawnLums()
{
    if (lumsPrefab != null)
    {
        Camera mainCamera = Camera.main;

        // Генерируем случайную позицию для Lums справа
        Vector3 spawnPosition = mainCamera.ViewportToWorldPoint(new Vector3(1.5f, Random.Range(0f, 1f), mainCamera.nearClipPlane));
        spawnPosition.z = 0; // Устанавливаем Z координату для 2D объекта

        // Проверяем, не перекрывается ли позиция с трубами или монетами
        if (IsValidSpawnPosition(spawnPosition))
        {
            GameObject lums = Instantiate(lumsPrefab, spawnPosition, Quaternion.identity);

            // Увеличиваем счетчик Lums в UI
            if (gameUIStats != null)
            {
                gameUIStats.IncrementLumsCount();
            }
        }
        else
        {
            // Если позиция не валидна, пробуем немного сместить и снова проверяем
            spawnPosition.x += 1f; // Сдвигаем позицию на 1 единицу вправо
            if (IsValidSpawnPosition(spawnPosition))
            {
                GameObject lums = Instantiate(lumsPrefab, spawnPosition, Quaternion.identity);

                // Увеличиваем счетчик Lums в UI
                if (gameUIStats != null)
                {
                    gameUIStats.IncrementLumsCount();
                }
            }
            else
            {
                // Если и после смещения невалидно, пробуем снова с новым случайным числом
                SpawnLums();
            }
        }
    }
}

private void SpawnCoins()
{
    if (coinsPrefab != null)
    {
        Camera mainCamera = Camera.main;

        // Генерируем случайную позицию для монеты справа
        Vector3 spawnPosition = mainCamera.ViewportToWorldPoint(new Vector3(1.5f, Random.Range(0f, 1f), mainCamera.nearClipPlane));
        spawnPosition.z = 0; // Устанавливаем Z координату для 2D объекта

        // Проверяем, не перекрывается ли позиция с трубами или люмусами
        if (IsValidSpawnPosition(spawnPosition))
        {
            GameObject coins = Instantiate(coinsPrefab, spawnPosition, Quaternion.identity);

            // Увеличиваем счетчик монет в UI
            if (gameUIStats != null)
            {
                gameUIStats.IncrementCoinCount();
            }
        }
        else
        {
            // Если позиция не валидна, пробуем немного сместить и снова проверяем
            spawnPosition.x += 1f; // Сдвигаем позицию на 1 единицу вправо
            if (IsValidSpawnPosition(spawnPosition))
            {
                GameObject coins = Instantiate(coinsPrefab, spawnPosition, Quaternion.identity);

                // Увеличиваем счетчик монет в UI
                if (gameUIStats != null)
                {
                    gameUIStats.IncrementCoinCount();
                }
            }
            else
            {
                // Если и после смещения невалидно, пробуем снова с новым случайным числом
                SpawnCoins();
            }
        }
    }
}

private bool IsValidSpawnPosition(Vector3 spawnPosition)
{
    // Проверяем на пересечение с трубами
    Collider2D[] pipes = Physics2D.OverlapCircleAll(spawnPosition, 0.5f); // 0.5f - радиус проверки
    foreach (Collider2D pipe in pipes)
    {
        if (pipe.CompareTag("Pipe"))
        {
            return false; // Если столкнулись с трубой, то позиция невалидна
        }
    }

    // Проверяем на пересечение с монетами
    Collider2D[] coins = Physics2D.OverlapCircleAll(spawnPosition, 0.5f); // 0.5f - радиус проверки
    foreach (Collider2D coin in coins)
    {
        if (coin.CompareTag("Coins"))
        {
            return false; // Если столкнулись с монетой, то позиция невалидна
        }
    }

    // Проверяем на пересечение с Lums
    Collider2D[] lums = Physics2D.OverlapCircleAll(spawnPosition, 0.5f); // 0.5f - радиус проверки
    foreach (Collider2D lum in lums)
    {
        if (lum.CompareTag("Lums"))
        {
            return false; // Если столкнулись с люмусом, то позиция невалидна
        }
    }

    return true; // Если ни с чем не столкнулись, позиция валидна
}



}

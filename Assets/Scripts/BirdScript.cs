using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.UI; // для работы с UI

public class BirdScript : MonoBehaviour
{
    private Rigidbody2D rb;
    public static float health;
    private float healthTimeout = 10.0f;

    private float maxTiltAngle = 8f;
    private float tiltSpeed = 3f;

    private int tries;


    [SerializeField] private Text triestext;

    //public int health = 5; // теперь от 0 до 5
    //public Text healthText; // ссылка на UI-текст (перетащи из инспектора)

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        health = 5f;
        tries = 3;
        triestext.text = tries.ToString();
        //UpdateHealthUI();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(250f * Time.timeScale * Vector2.up);
        }

        float verticalVelocity = rb.velocity.y;
        float targetAngle = Mathf.Clamp(verticalVelocity * maxTiltAngle, -maxTiltAngle, maxTiltAngle);
        float smoothedAngle = Mathf.LerpAngle(transform.eulerAngles.z, targetAngle, Time.deltaTime * tiltSpeed);
        transform.eulerAngles = new Vector3(0, 0, smoothedAngle);

        health -= Time.deltaTime / healthTimeout;
        if(health <=0)
        {
            Loose();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coins"))
        {
            Destroy(other.gameObject);
            health = Mathf.Clamp(health + 1f, 0f, 5f); // Увеличиваем здоровье на 1, ограничиваем от 0 до 5
            Debug.Log("Health: " + health); // Для отладки
        }

        if (other.CompareTag("Lums")) // Здесь проверяем тег Lums
        {
            Destroy(other.gameObject); // Уничтожаем объект Lums при столкновении
            health = Mathf.Clamp(health + 1f, 0f, 5f); // Увеличиваем здоровье на 1, ограничиваем от 0 до 5
            Debug.Log("Health: " + health); // Для отладки
        }

        if (other.CompareTag("Pipe"))
        {
            
            Loose();

        }
    }

    private void Loose()
    {
        tries -= 1;
        if (tries > 0)
        {
            health = 1.0f;
            AlertScript.Show("Collision", "You hit on obstacle and lose a life", "Continue", DeatroyerScript.ClearField);
            triestext.text = tries.ToString();  // Обновляем UI с количеством оставшихся жизней

            // Понижаем здоровье при столкновении с трубой
            health = Mathf.Clamp(health - 1f, 0f, 5f); // Уменьшаем здоровье на 1, ограничиваем от 0 до 5
        }
        else
        {
            AlertScript.Show("Collision", "Game Over", "Restart", () => RestartGame());
        }
    }

    // Метод для перезапуска игры с небольшой задержкой
    private void RestartGame()
    {
        // Убираем все объекты и сбрасываем параметры игры перед перезагрузкой
        DeatroyerScript.ClearField();  // Очистить все объекты

        // Убедитесь, что UI и параметры сброшены перед перезагрузкой
        tries = 3;
        health = 5f;
        triestext.text = tries.ToString();  // Сбрасываем текст на UI

        // Ожидаем, чтобы дать пользователю время увидеть "Game Over"
        Invoke("LoadScene", 1f);  // Задержка 1 секунда перед перезапуском
    }

    private void LoadScene()
    {
        // Используем имя сцены для перезагрузки
        SceneManager.LoadScene("FlappyBird");  // Замените на имя вашей сцены
    }





}


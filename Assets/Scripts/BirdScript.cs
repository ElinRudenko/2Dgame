using System.Collections;
using UnityEngine;
using UnityEngine.UI; // для работы с UI

public class BirdScript : MonoBehaviour
{
    private Rigidbody2D rb;
    public static float health;
    private float healthTimeout = 10.0f;

    private float maxTiltAngle = 8f;
    private float tiltSpeed = 3f;

    //public int health = 5; // теперь от 0 до 5
    //public Text healthText; // ссылка на UI-текст (перетащи из инспектора)

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        health = 5f;
        //UpdateHealthUI();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * 250f);
        }

        float verticalVelocity = rb.velocity.y;
        float targetAngle = Mathf.Clamp(verticalVelocity * maxTiltAngle, -maxTiltAngle, maxTiltAngle);
        float smoothedAngle = Mathf.LerpAngle(transform.eulerAngles.z, targetAngle, Time.deltaTime * tiltSpeed);
        transform.eulerAngles = new Vector3(0, 0, smoothedAngle);

        health -= Time.deltaTime / healthTimeout;
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
            AlertScript.Show("Collision", "You hit on obstacle and lose a life");
            // Понижаем здоровье при столкновении с трубой
            health = Mathf.Clamp(health - 1f, 0f, 5f); // Уменьшаем здоровье на 1, ограничиваем от 0 до 5
        }
    }




/*
    void UpdateHealthUI()
    {
        if (healthText != null)
        {
            healthText.text = "Health: " + health;
        }
    }
    */
}

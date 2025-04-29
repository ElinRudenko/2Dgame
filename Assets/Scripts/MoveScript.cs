using UnityEngine;

public class MoveScript : MonoBehaviour
{
    public static float difficulty = 0.5f;
    public static float speed;

    void Update()
    {
        // Теперь скорость зависит от инвертированного значения difficulty
        speed = 2f + 2.5f * difficulty;  // Чем ниже значение difficulty, тем выше скорость

        transform.Translate(speed * Time.deltaTime * Vector3.left);
    }
}

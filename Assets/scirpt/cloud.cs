using UnityEngine;

public class CloudMoveScript : MonoBehaviour
{
    public float baseSpeed = 5f; 
    private float speed;

    public float deadZone = -15f; 

    void OnEnable()
    {
        LogicScript.OnScoreChanged += UpdateSpeed;
        speed = baseSpeed;
    }

    void OnDisable()
    {
        LogicScript.OnScoreChanged -= UpdateSpeed;
    }

    void UpdateSpeed(int score)
    {
        speed = baseSpeed + 0.1f * score; // เพิ่มความเร็วตามคะแนน
    }

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x < deadZone)
        {
            Destroy(gameObject); // ลบเมฆเมื่อพ้นจอ
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            LogicScript logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
            if (!logic.isGameOver)
            {
                logic.gameOver();
            }
        }
    }
}

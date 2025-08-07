using UnityEngine;

public class PipeMoveScript : MonoBehaviour
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
        speed = baseSpeed + 0.1f * score;
    }

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }
    }
}

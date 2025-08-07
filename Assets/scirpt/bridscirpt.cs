using UnityEngine;

public class BirdScrip : MonoBehaviour
{
    public Rigidbody2D myrigidbody;
    public float flapStrength = 5f;
    public LogicScript logic;
    public bool birdIsAlive = true;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    void Update()
    {
        // กระโดดเมื่อกด Space หรือคลิกซ้าย
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && birdIsAlive)
        {
            myrigidbody.velocity = Vector2.up * 5;
        }

        // ถ้าหลุดขอบบนหรือล่างของหน้าจอ ให้จบเกม
        if (transform.position.y > 5.5f  || transform.position.y < -5.5f )
        {
            logic.gameOver();
            birdIsAlive = false;
        } 
    }

    private void OnCollisionEnter2D(Collision2D collision)
{
    if (!birdIsAlive) return;  // ถ้านกตายแล้วไม่ทำอะไรเพิ่ม

    if (collision.gameObject.CompareTag("Ground") || 
        collision.gameObject.CompareTag("Ceiling") || 
        collision.gameObject.CompareTag("Cloud") ||
        collision.gameObject.CompareTag("Obstacle"))
    {
        logic.gameOver();
        birdIsAlive = false;
    }
}
}
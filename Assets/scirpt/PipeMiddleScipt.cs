using UnityEngine;

public class PipeMiddleScipt : MonoBehaviour
{
    public LogicScript logic;

    // e first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
{
    if (logic.isGameOver) return;  // ถ้าเกมจบแล้วไม่เพิ่มคะแนน

    if (collision.CompareTag("Player"))
    {
        logic.addScore(1);
    }
}
}

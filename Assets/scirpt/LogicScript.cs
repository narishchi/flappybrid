using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playrScore;
    public Text scoreText;
    public GameObject gameOverScreen;
    public bool isGameOver = false;

    // ประกาศ delegate และ event สำหรับแจ้งคะแนนที่เปลี่ยนแปลง
    public delegate void ScoreChanged(int newScore);
    public static event ScoreChanged OnScoreChanged;

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        if (isGameOver) return;  // ถ้าเกมจบแล้ว ไม่เพิ่มคะแนน

        playrScore += scoreToAdd;
        scoreText.text = playrScore.ToString();
        OnScoreChanged?.Invoke(playrScore);
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        isGameOver = true;  // บอกว่าจบเกมแล้ว
        gameOverScreen.SetActive(true);
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;

    [SerializeField]
    private Text gameOverText;

    [SerializeField]
    private Text victoryText;

    private int score;
    
    public void AddScore(int amount)
    {
        score += amount;
        scoreText.text = "Score\n" + score;
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over\n\nTouch Or Space For Restart";
    }

    public void Victory()
    {
        victoryText.text = "Victory\n\nTouch Or Space For Restart";
    }

    public void Play(bool start)
    {
        victoryText.text = "Touch Or Space For Play";

        if(start)
        {
            victoryText.text = "";
        }
    }

    public void Restart()
    {
        // Keyboard Control
        if (Input.GetKeyDown("space"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        // Touch Control
        /*if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }*/
    }
}

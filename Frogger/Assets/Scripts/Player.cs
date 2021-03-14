using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField]
    TMP_Text gameOverText;
    [SerializeField]
    TMP_Text livesText;
    [SerializeField]
    TMP_Text scoreText;
    Transform myTransform;
    int lives = 3;
    int score = 0;
    void Awake()
    {
        myTransform = transform;
        gameOverText.gameObject.SetActive(false);
        UpdateScore();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            myTransform.Translate(new Vector3(0,1,0));
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            myTransform.Translate(new Vector3(-1, 0, 0));
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            myTransform.Translate(new Vector3(1, 0, 0));
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            myTransform.Translate(new Vector3(0,-1, 0));
        }
    }

    public void ArrivedSafe()
    {
        score += 100;
        UpdateScore();
        ResetPosition();
    }

    public void Death()
    {
        ResetPosition();
        lives--;
        livesText.text = "Lives: " + lives;
        if (lives == 0)
            GameOver();
    }

    void ResetPosition()
    {
        myTransform.position = new Vector3(0, -4.5f, 0);
    }

    void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
    }

    void UpdateScore()
    {
        scoreText.text = score.ToString("0000");
    }
}

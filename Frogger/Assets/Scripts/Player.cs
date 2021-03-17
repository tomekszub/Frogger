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
    bool isOverWater = false;
    Collider2D thisCollider;

    void Awake()
    {
        myTransform = transform;
        thisCollider = GetComponent<Collider2D>();
        gameOverText.gameObject.SetActive(false);
        UpdateScore();
    }

    // Update is called once per frame
    void Update()
    {
        MovementInput();
        if (Input.GetKeyDown(KeyCode.Z))
            PlayerDirectlyOverWater();
    }

    void MovementInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            myTransform.Translate(new Vector3(0, 1, 0));
            CheckIfShouldBeDrowning();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            myTransform.Translate(new Vector3(-1, 0, 0));
            CheckIfShouldBeDrowning();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            myTransform.Translate(new Vector3(1, 0, 0));
            CheckIfShouldBeDrowning();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            myTransform.Translate(new Vector3(0, -1, 0));
            CheckIfShouldBeDrowning();
        }
    }

    public void CheckIfShouldBeDrowning()
    {
        if(isOverWater && PlayerDirectlyOverWater())
        {
            Death();
        }
    }

    bool PlayerDirectlyOverWater()
    {
        Collider2D[] arr = new Collider2D[2];
        int t = thisCollider.OverlapCollider(new ContactFilter2D().NoFilter(), arr);
        Debug.Log("");
        Debug.Log(": " + t);
        Debug.Log("" + arr[0]);
        Debug.Log("" + arr[1]);
        return t == 1;
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

    public void AppearedOverWater()
    {
        isOverWater = true;
        CheckIfShouldBeDrowning();
    }

    public void NoLongerOverWater()
    {
        isOverWater = false;
    }
}

using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public TextMeshProUGUI scoreText;
    private int score = 0;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.Log("ScoreManager destoyed: " + name);
            Destroy(gameObject);
        }
    }

    void Start()
    {
        scoreText.text = "Pisteet: 0";
    }

    public void AddScore(int points)
    {
        score += points;
        scoreText.text = "Pisteet: " + score;
    }
}

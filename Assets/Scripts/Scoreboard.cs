using TMPro;
using UnityEngine;

public class Scoreboard : MonoBehaviour
{
    [SerializeField] TMP_Text scoreboardText;
    int score = 0;

    void Start()
    {
        UpdateScore(0);
    }

    public void UpdateScore(int value)
    {
        score += value;
        scoreboardText.text = score.ToString();
        // Debug.Log($"Pontuação atual: {score}");
    }
}

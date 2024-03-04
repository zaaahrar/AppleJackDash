using UnityEngine;

[RequireComponent(typeof(DisplayScore))]
public class ScoreCounter : MonoBehaviour
{
    private DisplayScore _displayScore;
    private int _score;

    public int Score => _score;

    private void Awake()
    {
        _displayScore = GetComponent<DisplayScore>();
        _displayScore.UpdateScoreText(_score);
    }

    public void AddScore() 
    {
        _score++;
        _displayScore.UpdateScoreText(_score);
    } 

    public void ResetScore()
    {
        _score = 0;
    }
}

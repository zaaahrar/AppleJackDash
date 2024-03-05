using UnityEngine;

[RequireComponent(typeof(ScoreView))]
public class ScoreCounter : MonoBehaviour
{
    private ScoreView _scoreView;
    private int _score;

    public int Score => _score;

    private void Awake()
    {
        _scoreView = GetComponent<ScoreView>();
        _scoreView.UpdateScoreText(_score);
    }

    public void AddScore() 
    {
        _score++;
        _scoreView.UpdateScoreText(_score);
    } 

    public void ResetScore() => _score = 0;
}

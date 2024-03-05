using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreCounterText;

    public void UpdateScoreText(int score) => _scoreCounterText.text = $"Score: {score}";
}

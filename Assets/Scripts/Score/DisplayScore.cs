using TMPro;
using UnityEngine;

public class DisplayScore : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreCounterText;

    public void UpdateScoreText(int score) => _scoreCounterText.text = $"Score: {score}";
}

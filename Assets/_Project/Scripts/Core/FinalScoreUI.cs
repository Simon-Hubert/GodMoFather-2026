using TMPro;
using UnityEngine;

public class FinalScoreUI : MonoBehaviour
{
    [SerializeField] private ScoreUI _scoreUI;
    private TextMeshProUGUI _scoreTextMesh;

    private void Awake()
    {
        _scoreTextMesh = GetComponent<TextMeshProUGUI>();
    }

    public void SetScore()
    {
        _scoreTextMesh.text = "Score : " + _scoreUI.TotalScore;
    }
}

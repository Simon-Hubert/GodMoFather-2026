using System;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    private int _score;

    private void OnEnable() {
        Object.OnScored += Score;
    }
    
    private void OnDisable() {
        Object.OnScored -= Score;
    }

    private void Score(int toAdd) {
        _score += toAdd;
        _text.text = _score.ToString();
    }
}

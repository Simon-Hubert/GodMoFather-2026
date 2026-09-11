using TMPro;
using UnityEngine;

public class TimerUI : MonoBehaviour
{

    [SerializeField] private Timer _timer;

    private TextMeshProUGUI _timerTextMesh;

    private void Awake()
    {
        _timerTextMesh = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        _timerTextMesh.text = _timer.Minutes.ToString() +" : " + _timer.Seconds.ToString();
    }

}

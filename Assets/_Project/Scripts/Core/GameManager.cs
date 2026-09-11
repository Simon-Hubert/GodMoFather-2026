using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private ScratchingController _scratchController;
    [SerializeField] private HookControllerHorizontal _horizontalController;
    [SerializeField] private HookControllerVertical _verticalController;
    [SerializeField] private ObjectSpawner _spawner;
    [SerializeField] private VFXHandler _vfxHandler;

    [SerializeField] private GameObject _finalScorePanel;
    [SerializeField] private FinalScoreUI _scoreUI;

    [SerializeField] private GameObject _baseScorePanel;

    private void Start()
    {
        Timer.Instance.OnCountDownOver += EndGame;
    }

    private void EndGame()
    {
        _scratchController.enabled = false;
        _horizontalController.enabled = false;
        _verticalController.enabled = false;
        _spawner.enabled = false;
        _vfxHandler.enabled = false;

        _baseScorePanel.SetActive(false);

        _finalScorePanel.SetActive(true);
        _scoreUI.SetScore();
    }

}

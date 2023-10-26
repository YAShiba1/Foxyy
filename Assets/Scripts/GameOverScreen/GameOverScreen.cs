using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private GameObject _win;
    [SerializeField] private GameObject _lose;
    [SerializeField] private Timer _timer;
    [SerializeField] private GameManager _game;
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _player.GoalReached += OnGoalReached;
        _timer.TimeIsOver += OnTimeIsOver;
    }

    private void OnDisable()
    {
        _player.GoalReached -= OnGoalReached;
        _timer.TimeIsOver -= OnTimeIsOver;
    }

    void Start()
    {
        _panel.SetActive(false);
        _win.SetActive(false);
        _lose.SetActive(false);
    }

    public void OnTimeIsOver()
    {
        _game.Pause();
        _panel.SetActive(true);
        _lose.SetActive(true);
    }

    public void OnGoalReached()
    {
        _game.Pause();
        _panel.SetActive(true);
        _win.SetActive(true);
    }
}

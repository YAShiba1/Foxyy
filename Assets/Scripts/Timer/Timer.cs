using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    [SerializeField] private TMP_Text _timer;
    [SerializeField] private TMP_Text _elapsedTime;

    private bool _timeIsOverEventFired = false;
    private float _maxTimeValue = 60f;
    private float _currentTime;

    public event UnityAction TimeIsOver;

    private void Start()
    {
        _currentTime = _maxTimeValue;
    }

    private void Update()
    {
        Countdown();
        CountingElapsedTime();
    }

    private void Countdown()
    {
        if (_currentTime > 0)
        {
            _currentTime -= Time.deltaTime;
            _timer.text = _currentTime.ToString("F0");
        }

        if (_timeIsOverEventFired == false && _currentTime <= 0)
        {
            TimeIsOver?.Invoke();
            _timeIsOverEventFired = true;
        }
    }

    private void CountingElapsedTime()
    {
        float elapsedTime = _maxTimeValue - _currentTime;

        _elapsedTime.text = elapsedTime.ToString("F0");
    }
}

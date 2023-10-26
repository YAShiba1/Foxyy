using UnityEngine;
using UnityEngine.UI;

public class GemsBoard : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Image[] _gemsImages;

    private float _defaultAlphaValue;
    private int _currentGemImageIndex = 0;

    private void Start()
    {
        _defaultAlphaValue = _gemsImages[_currentGemImageIndex].color.a;

        DecreaseAlphaChannelValue();
    }

    private void OnEnable()
    {
        _player.GemPicked += OnGemPicked;
    }

    private void OnDisable()
    {
        _player.GemPicked -= OnGemPicked;
    }

    private void OnGemPicked()
    {
        SetAlphaChannelToDefault(_currentGemImageIndex);
        _currentGemImageIndex++;
    }

    private void DecreaseAlphaChannelValue()
    {
        float targetValue = _defaultAlphaValue / 2;

        Color color = _gemsImages[_currentGemImageIndex].color;
        color.a = targetValue;

        for (int i = 0; i < _gemsImages.Length; i++)
        {
            _gemsImages[i].color = color;
        }
    }

    private void SetAlphaChannelToDefault(int curentIndex)
    {
        Color color = _gemsImages[curentIndex].color;
        color.a = _defaultAlphaValue;

        _gemsImages[curentIndex].color = color;
    }
}

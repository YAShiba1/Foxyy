using System.Collections;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textComponent;
    [SerializeField] private float _textSpeed;
    [SerializeField] private string[] _lines;

    private Coroutine _typeLineJob;
    private int _index;

    private void Update()
    {
        ShowNextLine();
    }

    private void Start()
    {
        _textComponent.text = string.Empty;
        StartDialogue();
    }

    public void ShowNextLine()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_textComponent.text == _lines[_index])
            {
                NextLine();
            }
            else
            {
                StopTypeLineCoroutine();
                _textComponent.text = _lines[_index];
            }
        }
    }

    private void StartDialogue()
    {
        _index = 0;

        StopTypeLineCoroutine();
        _typeLineJob = StartCoroutine(TypeLine());
    }

    private IEnumerator TypeLine()
    {
        var waitForSeconds = new WaitForSeconds(_textSpeed);

        foreach (char character in _lines[_index].ToCharArray()) 
        {
            _textComponent.text += character;

            yield return waitForSeconds;
        }
    }

    private void StopTypeLineCoroutine()
    {
        if (_typeLineJob != null)
        {
            StopCoroutine(_typeLineJob);
        }
    }

    private void NextLine()
    {
        if(_index < _lines.Length - 1)
        {
            _index++;
            _textComponent.text = string.Empty;

            StopTypeLineCoroutine();
            _typeLineJob = StartCoroutine(TypeLine());
        }
    }
}

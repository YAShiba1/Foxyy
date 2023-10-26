using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("--AudioSource--")]
    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private AudioSource _SFXSource;

    [Header("--AudioClip--")]
    [SerializeField] private AudioClip _background;
    [SerializeField] private AudioClip _jump;
    [SerializeField] private AudioClip _run;
    [SerializeField] private AudioClip _landing;

    private void Start()
    {
        _musicSource.clip = _background;
        _musicSource.Play();
    }

    public void PlayJump()
    {
        PlaySFX(_jump);
    }

    public void PlayRun()
    {
        PlaySFX(_run);
    }

    public void PlayLanding()
    {
        PlaySFX(_landing);
    }

    private void PlaySFX(AudioClip audioClip)
    {
        _SFXSource.PlayOneShot(audioClip);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [field: SerializeField] public AudioSource EffectsSource;

    [SerializeField] private AudioClip _pickupClip;
    [SerializeField] private float _pickupClipVolume;
    [SerializeField] private AudioClip _moveClip;
    [SerializeField] private float _moveClipVolume;
    [SerializeField] private AudioClip _clickClip;
    [SerializeField] private float _clickClipVolume;
    [SerializeField] private AudioClip _errorClip;
    [SerializeField] private float _errorClipVolume;

    public static SoundManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this) Destroy(this);
        else Instance = this;
    }


    public void PlaySoundEffect()
    {
        EffectsSource.PlayOneShot(_pickupClip, _pickupClipVolume);
    }

    public void PlayMoveEffect()
    {
        EffectsSource.PlayOneShot(_moveClip, _moveClipVolume);
    }

    public void PlayClick()
    {
        EffectsSource.PlayOneShot(_clickClip, _clickClipVolume);
    }

    public void PlayError()
    {
        EffectsSource.PlayOneShot(_errorClip, _errorClipVolume);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Behaviour_EndLevel : MonoBehaviour, IBehaviour
{
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private Transform _cameraTransform;
    [SerializeField] private Transform _cameraTarget;
    [SerializeField] private float _cameraMoveSpeed;

    [SerializeField] private float _endLevelDelay;
    [SerializeField] private Image _endBackgroundImage;
    [SerializeField] private GameObject _mainCanvas;
    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private AudioClip _musicClip;
    private bool _endLevel;
    private bool _showEndingBackground;
    private float _backgroundTransparency;


    public void Behaviour()
    {
        _playerController.enabled = false;
        StartCoroutine(EndLevel(_endLevelDelay));
    }

    private void Update()
    {
        if (_endLevel)
        {
            _cameraTransform.position = Vector3.Lerp(_cameraTransform.position, _cameraTarget.position, Time.deltaTime * _cameraMoveSpeed);
        }
        if(_showEndingBackground)
        {
            _backgroundTransparency += Time.deltaTime * 0.2f;
            _endBackgroundImage.color = new Color(1, 1, 1, _backgroundTransparency);
        }
    }

    private IEnumerator EndLevel(float delay)
    {
        _mainCanvas.SetActive(false);
        yield return new WaitForSeconds(1f);
        _endLevel = true;
        _musicSource.Stop();
        _musicSource.volume = 0.5f;
        _musicSource.PlayOneShot(_musicClip);
        yield return new WaitForSeconds(delay);
        _endBackgroundImage.gameObject.SetActive(true);
        _showEndingBackground = true;
        yield return new WaitForSeconds(7.3f);
        SceneManager.LoadScene("MainMenu");
    }
}

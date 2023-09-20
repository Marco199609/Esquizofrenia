using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenController : MonoBehaviour
{
    [SerializeField] private AudioClip _splashClip;
    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioSource _menuMusicSource;

    [SerializeField] private GameObject _canvas;
    [SerializeField] private GameObject _creditsCanvas;
    [SerializeField] private GameObject _introBackground;
    [SerializeField] private float _moveSpeed;

    private bool _loadGame;
    [SerializeField] private float _loadLevelDelay = 4;

    public void LoadLevel()
    {
        _loadGame = true;
        _canvas.SetActive(false);
        StartCoroutine(LevelChange(_loadLevelDelay));
    }

    private IEnumerator LevelChange(float delay)
    {
        yield return new WaitForSeconds(delay);
        _loadGame = false;
        
        _source.PlayOneShot(_splashClip);
        yield return new WaitForSeconds(_splashClip.length);
        SceneManager.LoadScene("Level1");
    }


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

     if(_loadGame)
        {
            _introBackground.transform.position += Vector3.forward * Time.deltaTime * _moveSpeed;
            _menuMusicSource.volume -= Time.deltaTime / 8;
        }
    }

    public void ActivateCreditScreen()
    {
        _canvas.SetActive(false);
        _creditsCanvas.SetActive(true);
    }
    public void ActivateMainScreen()
    {
        _creditsCanvas.SetActive(false);
        _canvas.SetActive(true);
    }
}

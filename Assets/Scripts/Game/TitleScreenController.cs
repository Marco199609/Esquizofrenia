using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenController : MonoBehaviour
{
    [SerializeField] private AudioClip _clickClip;
    [SerializeField] private AudioSource _source;
    public void LoadLevel()
    {
        _source.PlayOneShot(_clickClip);
        SceneManager.LoadScene("Level1");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Behaviour_EndLevel : MonoBehaviour
{
    [SerializeField] private float _delay;
    private void Start()
    {
        StartCoroutine(EndLevel(_delay));
    }

    private IEnumerator EndLevel(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("MainMenu");
    }
}

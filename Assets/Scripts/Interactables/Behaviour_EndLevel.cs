using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Behaviour_EndLevel : MonoBehaviour, IBehaviour
{
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private Transform _cameraTransform;
    [SerializeField] private Transform _cameraTarget;
    [SerializeField] private float _cameraMoveSpeed;

    [SerializeField] private float _endLevelDelay;
    [SerializeField] private bool _endLevel;


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
    }

    private IEnumerator EndLevel(float delay)
    {
        yield return new WaitForSeconds(1f);
        _endLevel = true;

        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("MainMenu");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _delayReload;
    [SerializeField] private PauseController _pauseController;

    void Start()
    {
        _player.DeathEvent.AddListener(ReloadLevel);
    }

    private void ReloadLevel()
    {
        StartCoroutine(ReloadLevelCoroutine());
    }

    private IEnumerator ReloadLevelCoroutine()
    {
        yield return new WaitForSeconds(_delayReload);
        _pauseController.StartFade();
    }
}

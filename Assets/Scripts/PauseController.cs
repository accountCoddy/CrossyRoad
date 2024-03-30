using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PauseController : MonoBehaviour
{
    [SerializeField] private TMP_Text _recordText;
    [SerializeField] private TMP_Text _recordTitle;
    [SerializeField] private SaveSystem _saveSystem;
    [SerializeField] private ScoreManager _scoreManager;

    private Fade _fade;
    private Animator _animator;
    
    void Start()
    {
        _animator = GetComponent<Animator>();
        _fade = GetComponent<Fade>();

        _fade.EndFade.AddListener(ShowContent);

        _recordTitle.gameObject.SetActive(false);
    }

    public void StartFade()
    {
        _fade.StartFade();
    }

    private void ShowContent()
    {
        _animator.SetTrigger("Show");

        int score = _saveSystem.LoadInt(GlobalConsts.ScoreKey);

        if(score > _scoreManager.LastRecord)
        {
            _recordTitle.gameObject.SetActive(true);
        }
        else
        {
            _saveSystem.Save(_scoreManager.LastRecord, GlobalConsts.ScoreKey);
        }

        _recordText.text = score.ToString();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}

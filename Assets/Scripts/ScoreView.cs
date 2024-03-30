using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private ScoreManager _scoreManager;
    private TMP_Text _scoreText;

    private void Start()
    {
        _scoreText = GetComponent<TMP_Text>();
        _scoreManager.UpdateScoreEvent.AddListener(SetScore);
    }

    private void SetScore(int score)
    {
        _scoreText.text = score.ToString();
        print("dad");
    }
}

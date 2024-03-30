using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    public UnityEvent<int> UpdateScoreEvent = new();

    [SerializeField] private Player _player;
    [SerializeField] private int _score;
    [SerializeField] private SaveSystem _saveSystem;

    private int _lastPosition;
    private int _lastRecord;

    public int LastRecord => _lastRecord;

    void Start()
    {
        _lastRecord = _saveSystem.LoadInt(GlobalConsts.ScoreKey);
        UpdateScoreEvent?.Invoke(_score);

        _player.JumpEvent.AddListener(CalculateScore);
        _lastPosition = (int)_player.transform.position.z;
    }

    private void CalculateScore()
    {
        if(_lastPosition < (int)_player.transform.position.z)
        {
            _lastPosition = (int)_player.transform.position.z;
            _score++;
            UpdateScoreEvent?.Invoke(_score);
            _saveSystem.Save(_score, GlobalConsts.ScoreKey);
        }
    }

    private void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.P))
        {
            _saveSystem.Save(0, GlobalConsts.ScoreKey);
        }
#endif

    }

}

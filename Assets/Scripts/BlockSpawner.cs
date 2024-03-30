using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    [SerializeField] private List<BlockData> _blocks;
    [SerializeField] private int _maxBlockCount;
    [SerializeField] private Transform _blocksHolder;
    [SerializeField] private Player _player;

    private int _currentBlockIndex;

    private float _currentPositionZ = 1;

    void Start()
    {
        _player.JumpEvent.AddListener(OnPlayerJump);

        for (int i = 0; i < 10; i++)
        {
            SpawnBlock();
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SpawnBlock();
        }
    }

    private void SpawnBlock()
    {
        

        BlockData currentBlockData = _blocks[_currentBlockIndex];
        int randomCount = Random.Range(currentBlockData.minBlocks, currentBlockData.maxBlocks + 1);

        for (int i = 0; i < randomCount; i++)
        {
            GameObject newBlock = Instantiate(currentBlockData.block, Vector3.forward * _currentPositionZ, Quaternion.identity);
            newBlock.transform.SetParent(_blocksHolder);
            _currentPositionZ++;

            if (_blocksHolder.childCount >= _maxBlockCount)
            {

                print(_blocksHolder.childCount + "  " + _maxBlockCount);
                Destroy(_blocksHolder.GetChild(0).gameObject);
            }
        }

        _currentBlockIndex++;

        if (_currentBlockIndex >= _blocks.Count)
            _currentBlockIndex = 0;
    }

    public void OnPlayerJump()
    {
        if (_player.transform.position.z >= Mathf.CeilToInt(_currentPositionZ / 2))
            SpawnBlock();
    }
}

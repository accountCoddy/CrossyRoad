using UnityEngine;

[CreateAssetMenu(fileName = "BlockData", menuName = "Block Data")]
public class BlockData : ScriptableObject
{
    public GameObject block;
    public int minBlocks;
    public int maxBlocks;
}

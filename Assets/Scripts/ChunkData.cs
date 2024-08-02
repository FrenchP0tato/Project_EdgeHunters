

using UnityEngine;


[CreateAssetMenu(fileName ="ChunkData",menuName ="Data/ChunkData")]


public class ChunkData : ScriptableObject
{
    public GameObject prefab;
    public float spawnRate = 1.0f;
    public Biome biome;
    
}

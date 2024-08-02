
using UnityEngine;




[CreateAssetMenu(fileName = "SetData", menuName = "Data/SetData")]


public class SetData : ScriptableObject
{
    public GameObject prefab;
    public float spawnRate = 1.0f;
    public Biome biome;
}
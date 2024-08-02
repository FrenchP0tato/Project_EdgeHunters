using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum Biome
{
    europe,
    americas,
    asia,
    africa,

}




public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform chunksContainer;
    [SerializeField] private List<ChunkData> chunks;

    [SerializeField] private Transform setsContainer;
    [SerializeField] private List<SetData> sets;


    private int lastChunkID=-1;
    private int lastObjectSetID = -1;
   

    private void OnTriggerExit(Collider other)
    {
        if ( other.CompareTag("Chunk"))
        {
            Transform lastChunkEnd = other.gameObject.transform.Find("chunkEnd");
            Instantiate(PickRandomChunk(), lastChunkEnd.position, Quaternion.identity, chunksContainer);
            Instantiate(PickRandomSet(), lastChunkEnd.position, Quaternion.identity, setsContainer);
        }
          
    }

   private GameObject PickRandomSet()
    {
        float totalSetSpawnRate = 0f;
        foreach (var set in sets) totalSetSpawnRate += set.spawnRate;

        float randomValue = Random.Range(0, totalSetSpawnRate);
        float cumulative = 0f;

        
        for (int i = 0; i < sets.Count; i++)
        {
            cumulative += sets[i].spawnRate;
            Biome setbiome = sets[i].biome;
            if (randomValue <= cumulative)
            {
                if (setbiome != GameController.instance.currentBiome) return PickRandomSet();
                if (i == lastObjectSetID) return PickRandomSet(); //fonction récursive
                lastObjectSetID = i;
                return sets[i].prefab;
            }
        }
        return sets[0].prefab;
    }
    



    private GameObject PickRandomChunk()
    {
        float totalChunkSpawnRate = 0f;
        foreach (var chunk in chunks) totalChunkSpawnRate += chunk.spawnRate;

        float randomValue=Random.Range(0, totalChunkSpawnRate);
        float cumulative = 0f;

        for (int i = 0; i < chunks.Count; i++)
        {
            cumulative += chunks[i].spawnRate;
            Biome biome =chunks[i].biome;

            if (randomValue <= cumulative)
            {
                if (biome!=GameController.instance.currentBiome) return PickRandomChunk();
                if (i==lastChunkID) return PickRandomChunk();

                lastChunkID = i;
                
                return chunks[i].prefab;
            }
        }
        return chunks[0].prefab;
    }
}

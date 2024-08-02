using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] CollectableData data;
    public AudioClip impactsound;

        private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            data.process();
            AudioSource.PlayClipAtPoint(impactsound, transform.position);
            Destroy(gameObject);
        }
        
    }

}

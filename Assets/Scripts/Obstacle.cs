using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] int damage;
    public AudioClip impactSound;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var gc = GameController.instance;
            if (gc.hasIFrames==false)
            {
                gc.SetHearts(-damage);
            }
            AudioSource.PlayClipAtPoint(impactSound,transform.position);
            Destroy(gameObject);
        }
    }
}

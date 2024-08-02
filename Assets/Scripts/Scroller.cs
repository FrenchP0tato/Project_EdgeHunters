
using UnityEngine;

public class Scroller : MonoBehaviour
{
    [SerializeField] private Transform chunksContainer;
    [SerializeField] private Transform setsContainer;

    public void Move(Vector3 velocity)
    {
        foreach (Transform child in chunksContainer)
        {
            child.position += velocity;
        }

        foreach (Transform child in setsContainer)
        {
            child.position += velocity;
        }

    }

}

using UnityEngine;


using TMPro;

public class Score : MonoBehaviour
{

    [SerializeField] private TMP_Text text;

    public void TravelDistance(float dist)
    {
        text.text = dist.ToString("F0") + "m";
    }

}

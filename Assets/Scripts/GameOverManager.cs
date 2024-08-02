
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    
        [SerializeField] private TMP_Text distanceTFD;
        [SerializeField] private TMP_Text moneyTFD;
        
        [SerializeField] private TMP_Text levelTFD;

        private void Start()
        {
            int level = GameController.instance.currentLevel;
            float dist = GameController.instance.totalTraveledDistance;
            float money = GameController.instance.money;

            distanceTFD.text = "You Travelled " + dist.ToString("F0") + " m";
            levelTFD.text = "Reached Level" + level;
            moneyTFD.text = "And collected " + money.ToString() + " Coins";
           

            GameController.instance.Reset();
        }

    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
    
}

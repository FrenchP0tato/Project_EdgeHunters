using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUDManager : MonoBehaviour
{

    [SerializeField] private TMP_Text distanceTFD;
    [SerializeField] private TMP_Text moneyTFD;
    [SerializeField] private TMP_Text foodTFD;
    [SerializeField] private TMP_Text heartsTFD;
    [SerializeField] private TMP_Text levelTFD;
    [SerializeField] private TMP_Text healCooldownTFD;
  


    private void Update()
    {
        float food = GameController.instance.currentFood;
        int level = GameController.instance.currentLevel;
        float dist = GameController.instance.totalTraveledDistance;
        float money = GameController.instance.money;
        int hearts = GameController.instance.currentHearts;
        int Maxhearts = GameController.instance.maxHearts;
        float healCoolDown = GameController.instance.foodTimer;
        int costToHeal=GameController.instance.foodQtyToHeal;

        distanceTFD.text = dist.ToString("F0") + "miles ";
        moneyTFD.text = money.ToString() + " Coins";
        foodTFD.text = food.ToString() + " Food";
        heartsTFD.text = hearts.ToString() +" lives";
        levelTFD.text = "Level " + level;

        if (hearts == Maxhearts) healCooldownTFD.text = "At max life";
        else if (GameController.instance.canEat) healCooldownTFD.text = "Press E to heal (" + costToHeal.ToString() + " food)";
        else if (food >= costToHeal) healCooldownTFD.text = "Healing on cooldown ( " + healCoolDown.ToString("F0") + ")";
        else healCooldownTFD.text = "Find " + (costToHeal - food) + " more food to heal";

    }

    public void ShowLevelComplete(int value)
    {
        Debug.Log("UI receives order to Show Level Complete");
        //to complete later! 
        
    }


}

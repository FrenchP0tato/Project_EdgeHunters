
using UnityEngine;

public enum CollectableType
{
    coin,
    food,
    bonus,
}

[CreateAssetMenu(fileName = "CollectableData", menuName ="Data/CollectableData")]



public class CollectableData : ScriptableObject
{
    public CollectableType type;
    public int amount = 1;

    public void process()
    { 
        switch(type)
        {
            case CollectableType.coin:
                AddCoins();
                break;
                case CollectableType.food:
                AddFood();
                break;
        }
    
    }

    private void AddCoins()
    { var gc = GameController.instance;
        gc.setMoney(amount);
    }

    private void AddFood()
    {
        var gc = GameController.instance;
        gc.setFood(amount);

    }

}

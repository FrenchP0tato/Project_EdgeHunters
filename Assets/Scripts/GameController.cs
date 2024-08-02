
using JetBrains.Annotations;
using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance {get; private set;}

    //Variables à ajuster pour gameplay. Idealement, les bouger hors du GC pour pouvoir les changer dans l'editeur (Prio2)
    public int StartingFood { get; private set; } = 0;
    public int maxHearts { get; private set; } = 3;
    public int DistanceBetweenBiomes { get; private set; } = 100;

    public int foodQtyToHeal= 5; 
    private float foodCooldown = 5f; 
    private float iFramesDuration = 1f;

    //Variables de fonctionement
    public float totalTraveledDistance { get; private set; } = 0f;
    public float inBiomeTraveledDistance { get; private set; } = 0f;
    public int currentLevel { get; private set; } = 1;
    public float foodTimer { get; private set; } = 0f; //actual calculated variable reaching cooldown time
    public float distanceBetweenLevels { get; private set; } = 0f;
    public int money { get; private set; } = 0; 
    public int currentFood { get; private set; } = 0;
    public bool canEat = false;

    public bool hasIFrames = false;

    private float IframesTimer= 0f;

    public int currentHearts { get; private set; } = 0;
    public Biome currentBiome { get; private set; } = Biome.europe;


    private void Awake() // lance une scene: appelé une seule fois. Ensuite peut activer/Desactiver des objets et appeler le start quand on l'active
    {
        if (instance != null & instance != this)
        {
            Destroy (this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad (gameObject);
        SetHearts(maxHearts);
        distanceBetweenLevels = DistanceBetweenBiomes * 4; // a remplacer par nb de biomes dans enum de biomedata?
    }

    public void Update()
    {
        if (foodTimer > 0f)
        {
            foodTimer -= Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.E))
            { eat(); }

        if (currentFood >= foodQtyToHeal && currentHearts < maxHearts && foodTimer <= 0f)
        {
            canEat = true;
        }
        else canEat = false;

        if (hasIFrames) 
        {
            IframesTimer -= Time.deltaTime;
            if (IframesTimer <= 0f)
            { hasIFrames = false; }
        }

    }

    public void setFood(int value)
    { 
        currentFood += value;
        
    }

    public void eat()
    {
        if (canEat) 
        { 
            setFood(-foodQtyToHeal);
            SetHearts(1);
            foodTimer = foodCooldown;
        }
        else return;
    }

    public void setDistance(float value)

    {
        totalTraveledDistance += value;
        inBiomeTraveledDistance += value;
        
        if (inBiomeTraveledDistance >= DistanceBetweenBiomes) // prio 1: manual, prio 2: file
        {
            currentBiome = nextbiome(currentBiome);
            inBiomeTraveledDistance = 0;
        }
    }
    public void levelUp()
    {
        currentLevel++;
    }

    public Biome nextbiome(Biome currentBiome)
    {
        switch (currentBiome)
        {
            case Biome.europe: return Biome.americas;
            case Biome.americas: return Biome.asia;
            case Biome.asia: return Biome.africa;
            case Biome.africa: 
                {
                    levelUp();
                    return Biome.europe; 
                }
            default: return Biome.europe;
        }
    }


    public void SetHearts(int value)
    {
        currentHearts += value;
        if (value <0)
        {
            hasIFrames = true;
            IframesTimer = iFramesDuration;
        }
        if (currentHearts > maxHearts) currentHearts = maxHearts;
        if (currentHearts <= 0) SceneManager.LoadScene("GameOver");
    }

    public void setMoney(int value) => money += value;


    public void Reset()
    {
        currentFood = StartingFood; currentHearts = maxHearts; totalTraveledDistance = 0f; currentLevel = 1; money = 0; currentBiome=Biome.europe; canEat = false;
    }
}

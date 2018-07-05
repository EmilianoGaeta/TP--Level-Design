using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Modifiers : MonoBehaviour
{
    public float floorchance;
    public float spikechance;
    public float cameraspeed;
    public float initialtime;
    public float platformBlockchance;
    public int platfomrsize;
    public int platformSpacezice;
    public int initialspace;
    public int finalspace;
    public int levellenght;
    public int maxfloorgapsize;

    public static float floorGapChance;
    public static int platfomrSize;
    public static int platformSpaceSize;
    public static int initialSpace;
    public static int finalSpace;
    public static float spikeChance;
    public static float platformBlockChance;
    public static float cameraSpeed;
    public static int levelLenght;
    public static float initialTime;
    public static int maxFloorGapSize;

    private static Modifiers instance;
    public static Modifiers Instance
    {
        get
        {
            return instance;
        }
    }


    private void Awake()
    {
        if (instance == null) { instance = this; }
        else Destroy(gameObject);
        floorGapChance = floorchance;
        platfomrSize = platfomrsize;
        platformSpaceSize = platformSpacezice;
        initialSpace = initialspace;
        finalSpace = finalspace;
        spikeChance = spikechance;
        platformBlockChance = platformBlockchance;
        cameraSpeed = cameraspeed;
        levelLenght = levellenght;
        initialTime = initialtime;
        maxFloorGapSize = maxfloorgapsize;
    }
}


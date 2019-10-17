using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public static LevelManager Instance;
    public GameObject WallPrefab;
    public GameObject FreePrefab;
    public GameObject PlayerPrefab;

    public Pathfinder pathfinder;
    public ClockManager clock;

    private Grid grid;
    public Grid Grid { get { return grid; } }

    public void Awake()
    {
        Instance = this;
    }

    public void InitLevel()
    {
        //TO CHANGE
        string[,] array = new string[,]{    { "W", "W", "W", "W", "W", "W", "W", "W", "W", "W", "W", "W", "W", "W", "W", "W", "W", "W", "W", "W"},
                                            { "W", "F", "F", "F", "F", "W", "F", "F", "F", "W", "F", "F", "F", "F", "F", "F", "F", "F", "F", "W"},
                                            { "W", "F", "W", "W", "F", "W", "F", "W", "F", "W", "F", "W", "W", "F", "W", "F", "W", "W", "F", "W"},
                                            { "W", "F", "F", "W", "F", "W", "W", "W", "F", "W", "F", "W", "F", "F", "W", "F", "F", "W", "F", "W"},
                                            { "W", "W", "F", "W", "W", "W", "W", "F", "F", "F", "F", "W", "W", "W", "W", "W", "F", "F", "F", "W"},
                                            { "W", "F", "F", "F", "W", "F", "W", "W", "F", "W", "F", "F", "F", "W", "F", "W", "W", "W", "F", "W"},
                                            { "W", "F", "W", "F", "W", "F", "F", "W", "F", "F", "F", "W", "F", "F", "F", "F", "W", "F", "F", "W"},
                                            { "W", "F", "W", "W", "W", "F", "W", "W", "F", "W", "W", "W", "W", "W", "W", "F", "F", "F", "W", "W"},
                                            { "W", "F", "F", "F", "F", "F", "W", "F", "F", "F", "F", "F", "F", "F", "W", "W", "W", "F", "F", "W"},
                                            { "W", "W", "W", "F", "W", "W", "W", "F", "W", "W", "W", "W", "W", "F", "F", "F", "W", "W", "F", "W"},
                                            { "W", "F", "F", "F", "W", "F", "F", "F", "F", "F", "F", "F", "W", "F", "W", "W", "W", "F", "F", "W"},
                                            { "W", "W", "F", "W", "W", "F", "W", "W", "F", "W", "F", "W", "W", "F", "W", "F", "W", "W", "F", "W"},
                                            { "W", "F", "F", "F", "F", "F", "F", "W", "W", "W", "F", "W", "F", "F", "F", "F", "F", "F", "F", "W"},
                                            { "W", "F", "W", "W", "W", "W", "F", "F", "F", "W", "F", "W", "F", "W", "W", "W", "W", "W", "F", "W"},
                                            { "W", "F", "F", "F", "F", "W", "W", "W", "F", "F", "F", "W", "F", "W", "F", "F", "F", "W", "F", "W"},
                                            { "W", "F", "W", "W", "F", "W", "F", "P", "F", "W", "F", "F", "F", "W", "F", "W", "F", "W", "F", "W"},
                                            { "W", "F", "F", "W", "W", "W", "F", "W", "W", "W", "F", "W", "W", "W", "F", "W", "F", "F", "F", "W"},
                                            { "W", "W", "F", "W", "F", "F", "F", "F", "F", "W", "F", "F", "F", "F", "F", "W", "W", "W", "W", "W"},
                                            { "W", "F", "F", "F", "F", "W", "W", "W", "F", "F", "F", "W", "F", "W", "F", "F", "F", "F", "F", "W"},
                                            { "W", "W", "W", "W", "W", "W", "W", "W", "W", "W", "W", "W", "W", "W", "W", "W", "W", "W", "W", "W"}
                                            };
        grid = gameObject.AddComponent<Grid>();
        grid.BuildGridLevel(array);
    }
}

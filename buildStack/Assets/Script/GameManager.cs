using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static event Action OnCubeSpawned = delegate { };


    private CubeRespawn[] spawners;
    private int spawnerIndex;
    private CubeRespawn CurrentSpawn;

    private void Awake()
    {
        spawners = FindObjectsOfType<CubeRespawn>();
    }
    private void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            
            if(touch.phase == TouchPhase.Began)
            {
                if(MovingController.CurrentCube != null)
                    MovingController.CurrentCube.Stop();
                spawnerIndex = spawnerIndex == 0 ? 1 : 0;
                CurrentSpawn = spawners[spawnerIndex];

                CurrentSpawn.SpawnCube();
                OnCubeSpawned();
            }
        }
    }
}

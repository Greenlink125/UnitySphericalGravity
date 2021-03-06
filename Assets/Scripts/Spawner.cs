﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour 
{
    public GameObject[] spawnPrefabs;
    public GameObject[] activeGlobes;
    public int initialSpawnCount;

    private void Awake()
    {
        for(int i = 0; i < initialSpawnCount; i++)
        {
            SpawnPrefab();
        }
    }

    public void SpawnPrefab()
    {
        //Pick Random Planet & Object//
        int prefabIND = Random.Range(0, spawnPrefabs.Length);
        int globeIND = Random.Range(0, activeGlobes.Length); 
        
        //Starting Point (Planet Center)//
        Vector3 spawnPoint = activeGlobes[globeIND].transform.position;

        //Random Outward Direction//
        Vector3 randomDir = Random.onUnitSphere;

        //Modify Point to edge of planet// 
        spawnPoint += (randomDir * activeGlobes[globeIND].transform.localScale.y); 

        //Outward Rotation for Object//
        Vector3 spawnRotation = (spawnPoint - activeGlobes[globeIND].transform.position).normalized;

        //Spawn And Rotate into Place// 
        GameObject addSpawn = Instantiate(spawnPrefabs[prefabIND], spawnPoint, new Quaternion(0,0,0,0));
        addSpawn.transform.rotation = Quaternion.FromToRotation(addSpawn.transform.up, spawnRotation) * addSpawn.transform.rotation;

        //Parent to Globe//
        addSpawn.transform.parent = activeGlobes[globeIND].transform;
    }
}

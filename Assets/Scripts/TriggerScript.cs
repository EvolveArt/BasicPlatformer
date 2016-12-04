using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TriggerScript : MonoBehaviour {

    //Private
    private bool active = false;
    private bool isAnySpawnPointLeft;
    private PlatformSpawner ps;
    private GameObject platformToDestroy;
    private bool AllPlatformsSpawned;

    private GameObject GM;

    void Awake()
    {
        GM = GameObject.FindGameObjectWithTag("GM");
        ps = GM.GetComponent<PlatformSpawner>();
    }

    void Update()
    {
        if (ps.spawnPointsNotUsed.Count == 0)
            isAnySpawnPointLeft = false;
        else
            isAnySpawnPointLeft = true;

        if (ps.spawnPointsUsed.Count == 0)
            AllPlatformsSpawned = true;
        else
            AllPlatformsSpawned = false;

        ps.CurrentPlatforms = GameObject.FindGameObjectsWithTag("Platform");
        //ps.CurrentPlatforms = GameObject.FindGameObjectsWithTag("Falling Platform");
    }

    void OnTriggerEnter2D()
    {
            Debug.Log("Script working");
            //if (active)
            //    ps.anim.SetBool("active", true);
            //else
            //    ps.anim.SetBool("active", false);

            ManagePlatforms();
            active = !active;
            //Find game objects with the platform layer and put them in an array
    }


    void ManagePlatforms()
    {
        
        int spawnOrDestroy = Random.Range(0,2);  // 1--> Spawn 0--> Destroy
        Debug.Log(spawnOrDestroy);


        if (spawnOrDestroy == 1 || AllPlatformsSpawned)
            InstantiateRandomPlatformAtRandomSpawnPoint();
        else if(!isAnySpawnPointLeft || spawnOrDestroy == 0)
            RemovePlatformAtRandomSpawnPointUsed();

    }

    void InstantiateRandomPlatformAtRandomSpawnPoint()
    {
        Debug.Log("CREATE");
        //platformToSpawn: (Prefab)
        //    Take a random type of platform in the Platforms List<>
        int platformToSpawnIndex = Random.Range(0, ps.Platforms.Count);
        Transform platformToSpawn = ps.Platforms[platformToSpawnIndex];

        //spawnPointWhereInstantiate: (GameObject)
        //    Take a random spawnPoint in the spawnPointsNotUsed List<>
        int spawnPointsUsedIndex = Random.Range(0, ps.spawnPointsNotUsed.Count);
        Transform spawnPointWhereInstantiate = ps.spawnPointsNotUsed[spawnPointsUsedIndex];

        //Instantiate platformToSpawn at spawnPointWhereInstantiate position
        Instantiate(platformToSpawn, spawnPointWhereInstantiate.position, Quaternion.identity);

        //Remove the spawnPointWhereInstantiate from the spawnPointsNotUsed List
        ps.spawnPointsNotUsed.Remove(spawnPointWhereInstantiate);
        //Add the spawnPointWhereInstantiate to the spawnPointsUsed List
        ps.spawnPointsUsed.Add(spawnPointWhereInstantiate);

    }

    void RemovePlatformAtRandomSpawnPointUsed()
    {
        Debug.Log("REMOVE");
        //TODO :

        //spawnPointWhereRemove:
        //    Get the position of a random spawn point in the spawnPointsUsed List
        int randomSpawnPointUsedIndex = Random.Range(0, ps.spawnPointsUsed.Count);
        Transform spawnPointWhereRemove = ps.spawnPointsUsed[randomSpawnPointUsedIndex];
        Vector3 spawnPointWhereRemovePos = spawnPointWhereRemove.position;

        foreach (GameObject platform in ps.CurrentPlatforms)
        {
            if (platform.transform.position == spawnPointWhereRemovePos)
                platformToDestroy = platform;
        }

        Destroy(platformToDestroy);


        //Remove the spawnPoint from the spawnPointsUsed List
        ps.spawnPointsUsed.Remove(spawnPointWhereRemove);
        //Add the spawnPoint to the spawnPointsNotUsed List
        ps.spawnPointsNotUsed.Add(spawnPointWhereRemove);

    }
}

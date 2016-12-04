using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlatformSpawner : MonoBehaviour {

    [SerializeField]
    public List<Transform> Platforms;

    [SerializeField]
    public List<Transform> spawnPointsNotUsed;

    [SerializeField]
    public List<Transform> spawnPointsUsed;

    [SerializeField]
    public GameObject[] CurrentPlatforms;

    public  Animator anim;


    // Do everything if staying on the trigger
    
}

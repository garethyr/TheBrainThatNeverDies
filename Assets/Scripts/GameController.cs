using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
    public Transform WomanTransform;
    public Transform AlienTransform;

    public Transform FemaleSpawnPoint;

    public float AlienChance;
    public int MaxFemales;
    public float SpawnCooldown;

    private Transform[] females;


	// Use this for initialization
	void Start () {
        females = new Transform[MaxFemales];
	}
	
	// Update is called once per frame
	void Update () {
        if (SpawnCooldown > 0) {
            SpawnCooldown--;
        } else {
            doSpawn();
        }
	}

    void doSpawn() {
        


        if (Random.value < AlienChance) {

        }
    }
}

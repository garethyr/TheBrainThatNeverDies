using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {
    public Woman WomanTransform;
    public Alien AlienTransform;

    public Transform FemaleSpawnPoint;
    public Transform FemaleDespawnPoint;

    public float AlienChance;
    public int MaxFemales;
    public float SpawnCooldown;

    private float spawnCooled;

    private List<Female> females = new List<Female>();


    // Use this for initialization
    void Start () {
        spawnCooled = SpawnCooldown;
	}
	
	// Update is called once per frame
	void Update () {
        doSpawning();
        doDespawning();
	}

    void doSpawning() {
        if (spawnCooled > 0 && females.Count < MaxFemales) {
            spawnCooled--;
        } else {
            if (females.Count < MaxFemales) {
                spawnFemale();
            }
            spawnCooled = SpawnCooldown - Random.Range(0, SpawnCooldown) + Random.Range(0, SpawnCooldown);
        }
    }

    void doDespawning() {
        foreach (Female female in females) {
            if (female.transform.position.x < FemaleDespawnPoint.position.x) {
                despawnFemale(female);
                break;
            }
        }
    }

    void spawnFemale() {
        Female newFemale;
        if (Random.value < AlienChance) {
            newFemale = Instantiate<Alien>((Alien)AlienTransform);
        } else {
            newFemale = Instantiate<Woman>((Woman)WomanTransform);
        }
        newFemale.transform.position = FemaleSpawnPoint.position;
        females.Add(newFemale);
    }

    void despawnFemale(Female female) {
        females.Remove(female);
        Destroy(female.gameObject);
    }
}

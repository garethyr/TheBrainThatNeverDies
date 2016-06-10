using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
    public Woman WomanTransform;
    public Alien AlienTransform;

    public Transform FemaleSpawnPoint;

    public float AlienChance;
    public int MaxFemales;
    public float SpawnCooldown;

    private Female[] females;


    // Use this for initialization
    void Start () {
        females = new Female[MaxFemales];
	}
	
	// Update is called once per frame
	void Update () {
        if (SpawnCooldown > 0 && females.Length < MaxFemales) {
            SpawnCooldown--;
        } else {
            doSpawn();
        }
	}

    void doSpawn() {
        if (Random.value < AlienChance) {
            Alien newAlien = Instantiate<Alien>((Alien)AlienTransform);
            newAlien.transform.position = FemaleSpawnPoint.position;
        } else {
            Woman newWoman = Instantiate<Woman>((Woman)WomanTransform);
            newWoman.transform.position = FemaleSpawnPoint.position;
        }
    }
}

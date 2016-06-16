using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {
    public Player player;
    public Chase mutant;

    public Woman WomanTransform;
    public Alien AlienTransform;

    public Text Lives;
    public Text WomanPercent;
    public Text AlienPercent;

    public Transform FemaleSpawnPoint;
    public Transform FemaleDespawnPoint;

    public float AlienChance;
    public int MaxFemales;
    public float SpawnCooldown;

    private float spawnCooled;

    private List<Female> females = new List<Female>();

    public int MaxWomanCount;
    public int MaxAlienCount;
    public int MaxLifeCount;

    private int womanCount = 0;
    private int alienCount = 0;

    private int playerLivesLeft;

    private string keyToPress = "space";


    // Use this for initialization
    void Start() {
        spawnCooled = SpawnCooldown;
    }

    // Update is called once per frame
    void Update() {
        if (player.CollidingWithMutant && Time.time > player.CurrentDeathTime) {
            playerLivesLeft--;
        }
        if (playerLivesLeft <= 0 || alienCount >= MaxAlienCount) {
            LoseGame();
            return;
        }
        if (womanCount >= MaxWomanCount) {
            WinGame();
            return;
        }

        //Lives.text = "Lives: " + playerLivesLeft;
        //WomanPercent.text = "Woman Percent: " + (100 * womanCount / MaxWomanCount);
        //AlienPercent.text = "Bad Alien Percent: " + (100 * alienCount / MaxAlienCount);

        doSpawning();
        doDespawning();

        handleInput();
	}

    void LoseGame() {

    }

    void WinGame() {

    }

    void handleInput() {
        if (Input.GetKeyDown(keyToPress)) {
            if (player.CollidingWithMutant) {
                player.CollidingWithMutant = false;
                if (!mutant.IsDown) {
                    mutant.transform.position = new Vector3(mutant.transform.position.x - (mutant.fallSpeed * 2 + player.GetComponent<SpriteRenderer>().sprite.border.x), mutant.transform.position.y, mutant.transform.position.z);
                    mutant.transform.position = new Vector3(mutant.transform.position.x, mutant.transform.position.y - .6f, mutant.transform.position.z);
                    mutant.IsDown = true;
                }
            }
            if (player.WomanCollision != null) {
                womanCount++;
                captureFemale(player.WomanCollision);

            }
            if (player.AlienCollision) {
                alienCount++;
                captureFemale(player.AlienCollision);
            }
        }
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

    void captureFemale(Female female) {
        //TODO Play animation for capturing here
        print("Capturing female " + female);
        despawnFemale(female);
    }

    void despawnFemale(Female female) {
        if (females.Contains(female)) {
            females.Remove(female);
        }
        Destroy(female.gameObject);
    }
}

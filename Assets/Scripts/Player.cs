using UnityEngine;

public class Player : MonoBehaviour {
    public float DeathTime;

    private bool collidingWithMutant = false;
    private Female womanCollision;
    private Female alienCollision;

    private float currentDeathTime;

    public bool CollidingWithMutant {
        get { return collidingWithMutant; }
        set { collidingWithMutant = value; }
    }
    public Female WomanCollision {
        get { return womanCollision; }
        set { womanCollision = value; }
    }

    public Female AlienCollision {
        get { return alienCollision; }
        set { alienCollision = value; }
    }


    public float CurrentDeathTime {
        get { return currentDeathTime; }
        set { currentDeathTime = value; }
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Mutant")) {
            CurrentDeathTime = Time.time + DeathTime;
            collidingWithMutant = true;
        } else if (other.gameObject.CompareTag("Womyn")) {
            womanCollision = other.gameObject.GetComponent<Female>();
        } else if (other.gameObject.CompareTag("Alien")) {
            alienCollision = other.gameObject.GetComponent<Female>();
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.CompareTag("Womyn")) {
            womanCollision = null;
        } else if (other.gameObject.CompareTag("Alien")) {
            alienCollision = null;
        }
    }
}

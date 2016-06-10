using UnityEngine;

public class Player : MonoBehaviour {

    float timeToPressButton;
    bool needToPressButton = false;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (needToPressButton && Time.time > timeToPressButton) {
            print("ded");
        }
	}

    void OnTriggerEnter2D(Collider2D other) {
        print("hit");
        if (other.gameObject.CompareTag("Mutant")) {
            needToPressButton = true;
            timeToPressButton = Time.time + 3;
        }
    }
}

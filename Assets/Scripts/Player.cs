using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other) {
        print("hit");
        if (other.gameObject.CompareTag("Mutant")) {
            StartCoroutine(Dodge());
        }
    }

    IEnumerator Dodge() {
        yield return new WaitForSeconds(3f);
        print("dead");
    }
}

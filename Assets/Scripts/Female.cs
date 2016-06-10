using UnityEngine;
using System.Collections;

public class Female : MonoBehaviour {
    public float MoveSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	protected virtual void Update () {
        float newXPos = transform.position.x - MoveSpeed;
        transform.position = new Vector3(newXPos, transform.position.y, transform.position.z);
	}
}

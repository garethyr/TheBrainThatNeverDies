using UnityEngine;
using System.Collections;

public class Chase : MonoBehaviour {

    public float chaseSpeed;
    public Transform playerPosition;

    Rigidbody2D rigidBody;

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 move = playerPosition.position;
        move.y = transform.position.y;
        transform.position = Vector2.Lerp(transform.position, move, chaseSpeed * Time.deltaTime);
	}
}

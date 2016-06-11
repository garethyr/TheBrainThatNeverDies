using UnityEngine;

public class Chase : MonoBehaviour {

    public float minChaseSpeed;
    public float maxChaseSpeed;
    public float fallSpeed;

    public float changeSpeedMinTime;
    public float changeSpeedMaxTime;
    public float changeSpeedChance;
    public Transform playerPosition;

    private float speed;
    private float changeSpeedInterval;

    Rigidbody2D rigidBody;

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody2D>();

        changeSpeed();
	}
	
	// Update is called once per frame
	void Update () {
        if (changeSpeedInterval < changeSpeedMinTime) {
            changeSpeedInterval++;
        } else {
            if (changeSpeedInterval >= changeSpeedMaxTime || Random.value <= changeSpeedChance) {
                changeSpeed();
            }
        }

        Vector2 move = playerPosition.position;
        move.y = transform.position.y;
        transform.position = Vector2.Lerp(transform.position, move, speed * Time.deltaTime);
	}

    public void changeSpeed() {
        speed = Random.Range(minChaseSpeed, maxChaseSpeed);
        changeSpeedInterval = 0;
    }
}

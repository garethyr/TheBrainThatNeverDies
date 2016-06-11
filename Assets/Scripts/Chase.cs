using UnityEngine;

public class Chase : MonoBehaviour {

    public float minChaseSpeed;
    public float maxChaseSpeed;
    public float fallSpeed;

    public float changeSpeedMinTime;
    public float changeSpeedMaxTime;
    public float changeSpeedChance;
    public Transform playerPosition;

    public Transform getUpPosition;

    private float speed;
    private float changeSpeedInterval;
    private bool isDown;
    private Vector2 target;

    public bool IsDown {
        get { return isDown; }
        set { isDown = value; }
    }

    Rigidbody2D rigidBody;

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody2D>();

        changeSpeed();
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 move = Vector2.zero;
        if (isDown) {
            if (transform.position.x >= getUpPosition.position.x + .5) {
                speed = fallSpeed;
                move = getUpPosition.position;
                transform.rotation = Quaternion.Euler(0, 0, 90);
            } else {
                isDown = false;
                transform.position = new Vector3(transform.position.x, transform.position.y + .6f, transform.position.z);
                changeSpeed();
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        } else {
            move = playerPosition.position;
            if (changeSpeedInterval < changeSpeedMinTime) {
                changeSpeedInterval++;
            } else {
                if (changeSpeedInterval >= changeSpeedMaxTime || Random.value <= changeSpeedChance) {
                    changeSpeed();
                }
            }
        }

         
        move.y = transform.position.y;
        transform.position = Vector2.Lerp(transform.position, move, speed * Time.deltaTime);
	}

    public void changeSpeed() {
        speed = Random.Range(minChaseSpeed, maxChaseSpeed);
        changeSpeedInterval = 0;
    }
}

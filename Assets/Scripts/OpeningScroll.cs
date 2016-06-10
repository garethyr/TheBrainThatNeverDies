using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OpeningScroll : MonoBehaviour {

    RectTransform position;
    Vector2 start, end;
    float duration = 20f;
    Text words;
    string[] openingWords;
    bool crawling = false;
    public Text textToDisappear;

	// Use this for initialization
	void Start () {
        position = GetComponent<RectTransform>();
        start = position.anchoredPosition;
        end = new Vector2(start.x, Screen.height + 50);
        words = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKeyDown) {
            crawling = true;
            textToDisappear.enabled = false;
        }
        print(crawling);
        if (!crawling)
            return;
        position.Translate(Vector3.up * Time.deltaTime * 200);
        if (position.position.y > 550) {
            position.transform.position = start;
        }
    }
}

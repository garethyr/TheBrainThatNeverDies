using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OpeningScroll : MonoBehaviour {

    RectTransform position;
    Vector2 start, end;
    float duration = 20f;
    Text words;
    string[] openingWords;

	// Use this for initialization
	void Start () {
        position = GetComponent<RectTransform>();
        start = position.anchoredPosition;
        end = new Vector2(start.x, Screen.height + 50);
        words = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        float elapsedTime = 0;

        while (elapsedTime < duration) {
            print(elapsedTime);
            float t = elapsedTime / duration; //0 means the animation just started, 1 means it finished
            position.anchoredPosition = Vector2.Lerp(start, end, t);
            elapsedTime += Time.deltaTime;
        }
    }
}

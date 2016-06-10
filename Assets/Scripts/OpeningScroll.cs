using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OpeningScroll : MonoBehaviour {

    RectTransform position;
    Vector2 start, end;
    float duration = 20f;
    Text words;
    public string[] openingWords;
    int index = 0;
    bool crawling = false;
    public Text textToDisappear;

	// Use this for initialization
	void Start () {
        position = GetComponent<RectTransform>();
        start = position.anchoredPosition;
        print(start);
        end = new Vector2(start.x, Screen.height + 50);
        words = GetComponent<Text>();
        words.text = openingWords[index++];
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKeyDown) {
            crawling = true;
            textToDisappear.enabled = false;
        }
        if (!crawling)
            return;
        position.Translate(Vector3.up * Time.deltaTime * 100);
        if (position.position.y > 850) {
            if (index == openingWords.Length) {
                SceneManager.LoadScene("Main Scene");
            }
            else {
                position.anchoredPosition = start;
                words.text = openingWords[index++];
            }            
        }
    }
}

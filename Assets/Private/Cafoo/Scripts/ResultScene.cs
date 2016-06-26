using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ResultScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Text PlusText = GameObject.Find("PlusBpText").GetComponent<Text>();
        Text MinusText = GameObject.Find("MinusBpText").GetComponent<Text>();

        PlusText.text = BarySenGameManager.Instance.PlusBP.ToString();
        MinusText.text = BarySenGameManager.Instance.MinusBP.ToString();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}

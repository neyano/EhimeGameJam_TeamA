using UnityEngine;
using System.Collections;

public class StaffRollScene : MonoBehaviour {

    float scrollSpeedY = 0.1f;
    float scrollLimit = 5.0f;

    float mTime;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void PressCloseButton()
    {
        BarySenGameManager.Instance.CurrentStatus = BarySenGameStatus.TITLE;
        BarySenGameManager.Instance.GoToTitleFromCredit();
    }
}

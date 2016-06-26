using UnityEngine;
using System.Collections;

public class TestScript : MonoBehaviour
{
	void OnGUI ()
	{
		if (GUILayout.Button ("change status to TITLE")) {
			BarySenGameManager.Instance.CurrentStatus = BarySenGameStatus.TITLE;
		}
		if (GUILayout.Button ("change status to GAME")) {
			BarySenGameManager.Instance.CurrentStatus = BarySenGameStatus.GAME;
		}
		if (GUILayout.Button ("change status to RESULT")) {
            BarySenGameManager.Instance.PlusBP = 10000;
            BarySenGameManager.Instance.MinusBP = -1000;

            BarySenGameManager.Instance.CurrentStatus = BarySenGameStatus.RESULT;
		}
		if (GUILayout.Button ("change status to CREDIT")) {
			BarySenGameManager.Instance.CurrentStatus = BarySenGameStatus.CREDIT;
		}
	}
}

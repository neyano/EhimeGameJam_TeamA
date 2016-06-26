using UnityEngine;
using System.Collections;

public class ResultCloseButton : MonoBehaviour
{
	public void PressCloseButton ()
	{
		BarySenGameManager.Instance.CurrentStatus = BarySenGameStatus.TITLE;
		BarySenGameManager.Instance.GoToTitleFromResult ();
	}
}

using UnityEngine;
using System.Collections;

public class GameStartButton : MonoBehaviour
{
	public void PressGameStartButton ()
	{
        StartCoroutine(PressStartCoroutine());
		
	}

    IEnumerator PressStartCoroutine()
    {
        yield return new WaitForSeconds(0.5f);

        BarySenGameManager.Instance.CurrentStatus = BarySenGameStatus.GAME;
        BarySenGameManager.Instance.GoToGameFromTitle();
   }
}

using UnityEngine;
using System.Collections;

public class PressButton : MonoBehaviour
{
	public Texture2D selectedTexture { set; get; }

	public void Press ()
	{
		BarySenGameManager.Instance.Select (selectedTexture);
	}
}

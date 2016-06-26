using UnityEngine;
using System;
using System.Collections;
using System.IO;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DontShowScrollText : MonoBehaviour {
    public float speed = 10;
    public int spriteCount = 2;
    public float start = 100;
    public float end = 0;
    void Update()
    {
        // ↑へ移動
        transform.position += Vector3.up * speed * Time.deltaTime;
        //transform.position += Vector3.up * speed;


        Vector3 localpos = this.GetComponent<RectTransform>().localPosition;
        if (localpos.y > end)
        {
            Vector3 pos = new Vector3(0, start,0);
            this.GetComponent<RectTransform>().localPosition = pos;
        }

        //Debug.Log(this.GetComponent<RectTransform>().localPosition);
    }

}

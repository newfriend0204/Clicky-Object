using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial_heart : MonoBehaviour {
    public Image thisheart;
    public float detectlife;
    // Start is called before the first frame update
    void Start() {
        thisheart = GetComponent<Image>();
        //target = GameObject.Find("Tutorial 1").GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update() {
        //if (target.life <= detectlife - 1)
        //    thisheart.fillAmount = 0;
        //if (target.life > detectlife - 1) {
        //    thisheart.fillAmount = 1 - (detectlife - target.life);
        //}
    }
}

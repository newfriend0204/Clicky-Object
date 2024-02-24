using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heart : MonoBehaviour
{
    public Image thisheart;
    private GameManager gameManager;
    public float detectlife;
    // Start is called before the first frame update
    void Start()
    {
        thisheart = GetComponent<Image>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.life <= detectlife - 1)
            thisheart.fillAmount = 0;
        if (gameManager.life > detectlife - 1) {
            thisheart.fillAmount = 1 - (detectlife - gameManager.life);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial_Button : MonoBehaviour
{
    private Button button;
    private GameObject HTPG;
    bool turn = false;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(show);
        HTPG = GameObject.Find("pic_manager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void show() {
        if (turn == false)
            HTPG.GetComponent<Tutorial>().show();
        if (turn == true)
            HTPG.GetComponent<Tutorial>().hide();
    }
}

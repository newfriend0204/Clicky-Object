using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public List<Image> pictures;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void show() {
        gameObject.SetActive(true);
    }
    public void hide() {
        gameObject.SetActive(false);
    }
}

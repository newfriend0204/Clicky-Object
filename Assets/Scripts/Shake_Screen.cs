using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake_Screen : MonoBehaviour
{
    int shake = 40;
    // Start is called before the first frame update
    void Start()
    {
    }

    public void ShakeStart() {
        shake = 40;
        InvokeRepeating("Shake", 0.01f, 0.01f);
    }

    public void Shake() {
        shake--;
        float random_x = Random.Range(-0.05f, 0.05f);
        float random_y = Random.Range(5.08f, 4.97f);
        transform.position = new Vector3(random_x, random_y, -10);
        if (shake < 0) {
            transform.position = new Vector3(0, 5.04f, -10);
            CancelInvoke("Shake");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

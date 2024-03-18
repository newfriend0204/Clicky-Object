using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Tutorial_badprop : MonoBehaviour
{
    private Rigidbody targetRb;
    public GameObject gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Tutorial 1");
        targetRb = GetComponent<Rigidbody>();
        transform.position = new Vector3(0, -1, 0);
        targetRb.AddForce(Vector3.up * 125, ForceMode.Impulse);
        targetRb.AddTorque(5, 5, 5, ForceMode.Impulse);
    }

    private void OnMouseDown() {
        if (Time.timeScale == 0.02f) {
            //gameManager.GetComponent<Tutorial_target>.
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.transform.tag == "sensor")
            Destroy(gameObject);
    }

}

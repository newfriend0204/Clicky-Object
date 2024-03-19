using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Tutorial_badprop : MonoBehaviour
{
    private Rigidbody targetRb;
    public ParticleSystem explosionParticle;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI stageText;
    public TextMeshProUGUI stageupText;
    public GameObject heart3;
    public GameObject heart4;
    public GameObject heart5;
    public GameObject FocusPlane;
    public GameObject Show_Change;
    public GameObject Show_Bad;
    public GameObject FocusScreen;
    private AudioSource playerAudio;
    public AudioClip bomb;
    // Start is called before the first frame update
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
    }

    public void Next_4() {
        Invoke("Next_5", 1.0f);
    }

    public void Next_5() {
        targetRb = GetComponent<Rigidbody>();
        transform.position = new Vector3(0, -1, 0);
        targetRb.AddForce(Vector3.up * 1250, ForceMode.Impulse);
        targetRb.AddTorque(50, 50, 50, ForceMode.Impulse);
    }

    private void OnMouseDown() {
        if (Time.timeScale == 0.02f) { 
            heart4.gameObject.SetActive(false);
            scoreText.text = "Score: 421";
            stageText.text = "Stage: 7";
            playerAudio.PlayOneShot(bomb, 1.0f);
            heart5.gameObject.SetActive(true);
            heart4.gameObject.SetActive(false);
            heart3.gameObject.SetActive(false);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            Time.timeScale = 1.0f;
            FocusScreen.gameObject.SetActive(false);
            transform.position = new Vector3(-24.6f, 7.7f, -4.5f);
            stageupText.gameObject.SetActive(true);
            Invoke("Next_6", 1.5f);
        }
    }

    void Update() {
    }

    void Next_6() {
        FocusPlane.gameObject.SetActive(true);
        Show_Bad.gameObject.SetActive(true);
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.transform.tag == "sensor")
            Destroy(gameObject);
    }

}

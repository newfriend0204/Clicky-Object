using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Tutorial_target : MonoBehaviour {  
    private Rigidbody targetRb;
    private GameManager gameManager;
    public GameObject FocusScreen;
    public GameObject FocusPlane;
    private AudioSource playerAudio;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI stageText;
    public int pointValue;
    public float life = 3.0f;
    public AudioClip getScore;
    public GameObject heart4;
    public ParticleSystem explosionParticle;
    // Start is called before the first frame update
    void Start() {
        playerAudio = GetComponent<AudioSource>();
        targetRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        //targetRb.AddForce(Vector3.up * 125, ForceMode.Impulse);
        //targetRb.AddTorque(5, 5, 5, ForceMode.Impulse);
        //transform.position = new Vector3(0, -1, 0);
        Invoke("ShowInformation", 1.0f);
        //Invoke("Stop", 1.0f);
    }

    void ShowInformation() {
        FocusPlane.gameObject.SetActive(true);
    }

    void Stop() {
        Time.timeScale = 0.02f;
        FocusScreen.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update() {
        Application.targetFrameRate = 60;
    }

    private void OnMouseDown() {
        if (Time.timeScale == 0.02f) {
            heart4.gameObject.SetActive(true);
            scoreText.text = "Score: 456";
            playerAudio.PlayOneShot(getScore, 1.0f);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            transform.position = new Vector3(-9.43f, 5.93f, -5.0796f);
            Time.timeScale = 1.0f;
            FocusScreen.gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.transform.tag != "sensor" && collision.transform.tag != "wall")
            targetRb.AddForce(Vector3.up * 20, ForceMode.Impulse);
        if (collision.transform.tag == "sensor") {
            Destroy(gameObject);
            if (!gameObject.CompareTag("Bad") && !gameObject.CompareTag("bad_lot") && !gameObject.CompareTag("sample")) {
                gameManager.life -= 1.0f;
            }
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;
public class Tutorial_target : MonoBehaviour {  
    private Rigidbody targetRb;
    private GameManager gameManager;
    public GameObject FocusScreen;
    GameObject shake_screen;
    public GameObject FocusPlane;
    public GameObject Show_Inform;
    public GameObject Show_Change;
    public GameObject Bad_Prop;
    private AudioSource playerAudio;
    public TextMeshProUGUI scoreText;
    public int pointValue;
    public float life = 3.0f;
    public AudioClip getScore;
    public GameObject heart4;
    public ParticleSystem explosionParticle;
    public GameObject fade;
    // Start is called before the first frame update

    void Fade_out_start() {
        Color color = fade.GetComponent<Image>().color;
        color.a -= 0.03f;
        fade.GetComponent<Image>().color = color;
        if (color.a <= 0) {
            fade.gameObject.SetActive(false);
            color.a = 0f;
            fade.GetComponent<Image>().color = color;
            CancelInvoke("Fade_out_start");
        }
    }

    void Start() {
        fade.gameObject.SetActive(true);
        InvokeRepeating("Fade_out_start", 0.01f, 0.01f);
        shake_screen = GameObject.Find("Main Camera");
        playerAudio = GetComponent<AudioSource>();
        targetRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        FocusPlane.gameObject.SetActive(true);
        Show_Inform.gameObject.SetActive(true);
    }   

    public void Next_1() {
        FocusPlane.gameObject.SetActive(false);
        Show_Inform.gameObject.SetActive(false);
        Invoke("Next_2", 1.0f);
    }

    void Next_2() {
        transform.position = new Vector3(0, -1, 0);
        targetRb.AddForce(Vector3.up * 1250, ForceMode.Impulse);
        targetRb.AddTorque(50, 50, 50, ForceMode.Impulse);
        Invoke("Stop", 1.0f);
    }

    void Next_3() {
        FocusPlane.gameObject.SetActive(true);
        Show_Change.gameObject.SetActive(true);
    }

    public void Next_4() {
        FocusPlane.gameObject.SetActive(false);
        Show_Change.gameObject.SetActive(false);
        Invoke("Next_5", 1.0f);
    }

    void Next_5() {
        Invoke("Stop", 1.0f);
    }

    void Stop() {
        Time.timeScale = 0.02f;
        FocusScreen.gameObject.SetActive(true);
    }

    void Fade_in_tutorial() {
        Color color = fade.GetComponent<Image>().color;
        color.a += 0.03f;
        if (color.a >= 1.0f) {
            CancelInvoke("Fade_in_tutorial");
            SceneManager.LoadScene("Scene");
        }
        fade.GetComponent<Image>().color = color;
    }

    public void Quit() {
        InvokeRepeating("Fade_in_tutorial", 0.01f, 0.01f);
    }

    // Update is called once per frame
    void Update() {
        Application.targetFrameRate = 60;
        if (Application.platform == RuntimePlatform.Android) {
            if (Input.GetKey(KeyCode.Escape))
                InvokeRepeating("Fade_in_tutorial", 0.01f, 0.01f);
        }
        if (Input.GetKeyDown(KeyCode.T))
            InvokeRepeating("Fade_in_tutorial", 0.01f, 0.01f);
    }

    private void OnMouseDown() {
        if (Time.timeScale == 0.02f) {
            heart4.gameObject.SetActive(true);
            scoreText.text = "Score: 456";
            playerAudio.PlayOneShot(getScore, 1.0f);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            transform.position = new Vector3(-20.1f, 5.93f, -5.0796f);
            Time.timeScale = 1.0f;
            FocusScreen.gameObject.SetActive(false);
            Invoke("Next_3", 1.5f);
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
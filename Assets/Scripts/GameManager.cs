using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //PlayerPrefs.SetInt("저장할변수이름", 변수값);
    //PlayerPrefs.Save();
    public List<GameObject> targets;
    public List<GameObject> samples;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI gameOverScore;
    public Button restartButton;
    public GameObject titleScreen;
    public GameObject isGamingScreen;
    private AudioSource playerAudio;
    public AudioClip getScore;
    public AudioClip bomb;
    public AudioClip skull;
    public bool isGameActive = false;
    private int score;
    private float spawnRate = 1.0f;
    public float life = 5.00f;
    // Start is called before the first frame update
    IEnumerator SpawnTarget() {
        while (isGameActive) {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }
    IEnumerator waitStart() {
        while (!isGameActive) {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, samples.Count);
            Instantiate(samples[index]);
        }
    }
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        spawnRate = 1.9f;
        StartCoroutine(waitStart());
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.touchCount > 0) {
        //    Touch touch = Input.GetTouch(0);
        //    if (touch.phase == TouchPhase.Began)
        //        Debug.Log("Began : " + touch.position);
        //    if (touch.phase == TouchPhase.Moved)
        //        Debug.Log("Moved : " + touch.position);
        //    if (touch.phase == TouchPhase.Ended)
        //        Debug.Log("Ended : " + touch.position);
        //}
 
        if (life <= 0)
            GameOver();
        if (life > 5)
            life = 5;
    }

    public void UpdateScore(int scoreToAdd) {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void GameOver() {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        gameOverScore.gameObject.SetActive(true);
        scoreText.gameObject.SetActive(false);
        gameOverScore.text = "Score:" + score;
        isGameActive = false;
    }

    public void StartGame(float difficulty) {
        spawnRate = 1;
        isGameActive = true;
        score = 0;
        spawnRate /= difficulty;
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
        titleScreen.gameObject.SetActive(false);
        isGamingScreen.gameObject.SetActive(true);
    }

    public void music() {
        playerAudio.PlayOneShot(getScore, 1.0f);
    }
    public void bombmusic() {
        playerAudio.PlayOneShot(bomb, 1.0f);
    }
    public void skullmusic() {
        playerAudio.PlayOneShot(skull, 1.0f);
    }
}

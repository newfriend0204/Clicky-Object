using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
//using static UnityEditor.Timeline.TimelinePlaybackControls;

public class Tuorial_gameManager : MonoBehaviour {
    public List<GameObject> targets;
    public List<GameObject> samples;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverScore;
    public TextMeshProUGUI gameOverStage;
    public TextMeshProUGUI stageText;
    public TextMeshProUGUI stageupText;
    public GameObject titleScreen;
    public GameObject isGamingScreen;
    public GameObject pauseScreen;
    public GameObject GameOverScreen;
    private AudioSource playerAudio;
    public AudioClip getScore;
    public AudioClip bomb;
    public AudioClip skull;
    public AudioClip stageup;
    public bool isGameActive = false;
    public bool GameOverValue = false;
    private int score;
    public float nowdifficulty;
    public float spawnRate = 1.0f;
    public float life = 3f;
    public int stage = 6;
    public int nextstageneed = 0;
    void Start() {
        playerAudio = GetComponent<AudioSource>();
        stageupText.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update() {
        if (Application.platform == RuntimePlatform.Android && isGameActive == true) {
            if (Input.GetKey(KeyCode.Escape))
                GamePause();
        }
        if (Input.GetKeyDown(KeyCode.T))
            GamePause();
        if (life <= 0)
            GameOver();
        if (life > 5)
            life = 5;
        if (nextstageneed >= 30 || stage == 1 && nextstageneed >= 10 || stage == 2 && nextstageneed >= 13 || stage == 3 && nextstageneed >= 15 || stage == 4 && nextstageneed >= 17 || stage == 5 && nextstageneed >= 20 || stage == 6 && nextstageneed == 23 || stage == 7 && nextstageneed >= 25 || stage == 8 && nextstageneed >= 27) {
            nextstageneed = 0;
            stage++;
            playerAudio.PlayOneShot(stageup, 0.65f);
            stageupText.gameObject.SetActive(true);
            InvokeRepeating("StageUp", 0.01f, 0.1f);
        }
        stageText.text = "Stage: " + stage;
    }
    public void StageUp() {
        Color color = stageupText.GetComponent<TextMeshProUGUI>().color;
        color.a -= 0.1f;
        stageupText.GetComponent<TextMeshProUGUI>().color = color;
        if (color.a <= 0) {
            stageupText.gameObject.SetActive(false);
            color.a = 1.0f;
            stageupText.GetComponent<TextMeshProUGUI>().color = color;
            CancelInvoke("StageUp");
        }
    }

    public void GamePause() {
        pauseScreen.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void GameContinue() {
        pauseScreen.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void UpdateScore(int scoreToAdd) {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void GameOver() {
        isGameActive = false;
        GameOverValue = true;
        Time.timeScale = 1;
        life = 0;
        GameOverScreen.gameObject.SetActive(true);
        pauseScreen.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(false);
        stageText.gameObject.SetActive(false);
        gameOverScore.text = "Score: " + score;
        gameOverStage.text = "Stage: " + stage;
    }
    public void music() {
        playerAudio.PlayOneShot(getScore, 1.0f);
    }
    public void bombmusic() {
        playerAudio.PlayOneShot(bomb, 1.0f);
    }
}

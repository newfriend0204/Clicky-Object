using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
//using static UnityEditor.Timeline.TimelinePlaybackControls;

public class GameManager : MonoBehaviour {
    //PlayerPrefs.SetInt("저장할변수이름", 변수값);
    //PlayerPrefs.Save();
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
    public Image fade;
    private AudioSource playerAudio;
    public AudioClip getScore;
    public AudioClip bomb;
    public AudioClip skull;
    public AudioClip stageup;
    public bool isGameActive = false;
    public bool GameOverValue = false;
    private int score;
    public float nowdifficulty;
    public float select_difficulty;
    public float spawnRate = 1.0f;
    public float life = 5.00f;
    public int stage = 1;
    public int nextstageneed = 0;
    // Start is called before the first frame update
    IEnumerator SpawnTarget() {
        while (isGameActive) {
            yield return new WaitForSeconds(spawnRate / (nowdifficulty + (float)(stage * 0.07)));
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }
    IEnumerator waitStart() {
        while (!isGameActive && !GameOverValue) {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, samples.Count);
            Instantiate(samples[index]);
        }
    }

    void Fade_out_gamestart() {
        Color color = fade.GetComponent<Image>().color;
        color.a -= 0.03f;
        fade.GetComponent<Image>().color = color;
        if (color.a <= 0) {
            fade.gameObject.SetActive(false);
            color.a = 0f;
            fade.GetComponent<Image>().color = color;
            CancelInvoke("Fade_out_gamestart");
        }
    }

    void Start() {
        Color color = fade.GetComponent<Image>().color;
        color.a = 1;
        fade.GetComponent<Image>().color = color;
        fade.gameObject.SetActive(true);
        InvokeRepeating("Fade_out_gamestart", 0.01f, 0.01f);
        playerAudio = GetComponent<AudioSource>();
        spawnRate = 1.0f;
        StartCoroutine(waitStart());
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

    public void StartGame(float difficulty) {
        select_difficulty = difficulty;
        fade.gameObject.SetActive(true);
        InvokeRepeating("Fade_in_start", 0.01f, 0.01f);
    }

    public void Play() {
        spawnRate = 1;
        isGameActive = true;
        score = 0;
        nowdifficulty = select_difficulty;
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
        titleScreen.gameObject.SetActive(false);
        isGamingScreen.gameObject.SetActive(true);
    }

    public void Fade_in_start() {
        Color color = fade.GetComponent<Image>().color;
        color.a += 0.03f;
        if (color.a >= 1.0f) {
            CancelInvoke("Fade_in_start");
            Play();
            InvokeRepeating("Fade_out_start", 0.01f, 0.01f);
        }
        fade.GetComponent<Image>().color = color;
    }

    public void Fade_out_start() {
        Color color = fade.GetComponent<Image>().color;
        color.a -= 0.03f;
        fade.GetComponent<Image>().color = color;
        if (color.a <= 0) {
            fade.gameObject.SetActive(false);
            color.a = 0f;
            fade.GetComponent<Image>().color = color;
            CancelInvoke("Fade_out_start");
            fade.gameObject.SetActive(false);
        }
    }

    public void Fade_in_restart() {
        Color color = fade.GetComponent<Image>().color;
        color.a += 0.03f;
        if (color.a >= 1.0f) {
            CancelInvoke("Fade_in_restart");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        fade.GetComponent<Image>().color = color;
    }

    public void Fade_in_tutorial() {
        Color color = fade.GetComponent<Image>().color;
        color.a += 0.03f;
        if (color.a >= 1.0f) {
            CancelInvoke("Fade_in_tutorial");
            SceneManager.LoadScene("Tutorial");
        }
        fade.GetComponent<Image>().color = color;
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
    public void RestartGame() {
        fade.gameObject.SetActive(true);
        InvokeRepeating("Fade_in_restart", 0.01f, 0.01f);
    }
    public void ShowTutorial() {
        fade.gameObject.SetActive(true);
        InvokeRepeating("Fade_in_tutorial", 0.01f, 0.01f);
    }
}

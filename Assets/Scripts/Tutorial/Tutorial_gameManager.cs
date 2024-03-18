using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using System;
//using static UnityEditor.Timeline.TimelinePlaybackControls;

public class Tuorial_gameManager : MonoBehaviour {
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI stageText;
    public TextMeshProUGUI stageupText;
    public GameObject isGamingScreen;
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
        //Instantiate(targets[0]);
    }

    // Update is called once per frame
    void Update() {
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

    public void UpdateScore(int scoreToAdd) {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }
    public void music() {
        playerAudio.PlayOneShot(getScore, 1.0f);
    }
    public void bombmusic() {
        playerAudio.PlayOneShot(bomb, 1.0f);
    }
}

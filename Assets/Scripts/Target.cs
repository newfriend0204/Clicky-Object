using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Target : MonoBehaviour {
    private Rigidbody targetRb;
    private GameManager gameManager;
    GameObject shake_screen;
    private float minSpeed = 100;
    private float maxSpeed = 150;
    private float maxTorque = 10;
    private float xRange = 1.85f;
    private float ySpawnPos = -1;

    public int pointValue;
    public ParticleSystem explosionParticle;
    // Start is called before the first frame update
    void Start() {
        shake_screen = GameObject.Find("Main Camera");
        targetRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPos();
    }

    // Update is called once per frame
    void Update() {
        Application.targetFrameRate = 60;
    }

    private void OnMouseDown() {
        if (gameManager.isGameActive && Time.timeScale == 1) {
            gameManager.nextstageneed++;
            gameManager.UpdateScore(pointValue);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            if (!gameObject.CompareTag("Bad") && !gameObject.CompareTag("bad_lot"))
                gameManager.music();
            if (gameObject.CompareTag("Bad")) {
                gameManager.skullmusic();
                gameManager.life -= 0.35f;
            }
            else if (gameObject.CompareTag("good5") && !(gameManager.life >= 5))
                gameManager.life += 0.05f;
            else if (gameObject.CompareTag("good10") && !(gameManager.life >= 5))
                gameManager.life += 0.10f;
            else if (gameObject.CompareTag("good15") && !(gameManager.life >= 5))
                gameManager.life += 0.12f;
            else if (gameObject.CompareTag("good7") && !(gameManager.life >= 5))
                gameManager.life += 0.07f;
            else if (gameObject.CompareTag("good12") && !(gameManager.life >= 5))
                gameManager.life += 0.14f;
            else if (gameObject.CompareTag("bad_lot")) {
                shake_screen.GetComponent<Shake_Screen>().ShakeStart();
                gameManager.bombmusic();
                gameManager.life -= 0.75f;
            }
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.transform.tag != "sensor" && collision.transform.tag != "wall")
            targetRb.AddForce(Vector3.up * 20, ForceMode.Impulse);
        if (collision.transform.tag == "sensor") {
            Destroy(gameObject);
            if (!gameObject.CompareTag("Bad") && !gameObject.CompareTag("bad_lot") && !gameObject.CompareTag("sample")) {
                gameManager.life -= 1.0f;
                shake_screen.GetComponent<Shake_Screen>().ShakeStart();
                gameManager.skullmusic();
            }
        }
    }

    Vector3 RandomForce() {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }
    float RandomTorque() { 
        return Random.Range(-maxTorque, maxTorque);
    }
    Vector3 RandomSpawnPos() {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos, Random.Range(-4f, 1.3f));
    }
}
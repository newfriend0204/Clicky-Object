using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShutDownApp : MonoBehaviour {
    int ClickCount = 0;
    void Update() {

        if (Input.GetKeyDown(KeyCode.Escape)) {
            ClickCount++;
            if (!IsInvoking("DoubleClick"))
                Invoke("DoubleClick", 1.0f);

        } else if (ClickCount == 2) {
            CancelInvoke("DoubleClick");
            Application.Quit();
        }

    }

    void DoubleClick() {
        ClickCount = 0;
    }
}
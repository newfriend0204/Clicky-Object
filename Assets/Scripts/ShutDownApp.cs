using System.Collections;
using UnityEngine;

public class ShutDownApp : MonoBehaviour {
    int ClickCount = 0;
    void Update() {

        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.T)) {
            ClickCount++;
            ShowAndroidToastMessage("게임을 종료하려면 뒤로 가기를 한번 더 눌러주세요.");
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
    public void ShowAndroidToastMessage(string message) {
        AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity2d.player.UnityPlayer");
        AndroidJavaObject unityActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

        if (unityActivity != null) {
            AndroidJavaClass toastClass = new AndroidJavaClass("android.widget.Toast");
            unityActivity.Call("runOnUiThread", new AndroidJavaRunnable(() => {
                AndroidJavaObject toastObject = toastClass.CallStatic<AndroidJavaObject>("makeText", unityActivity, message, 0);
                toastObject.Call("show");
            }));
        }
    }
}
using UnityEngine;
using System.IO;

public class CheckRemoveAd : MonoBehaviour {
    private string removeAdFilePath;
    GameManager gameManager;
    void Start() {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        removeAdFilePath = Path.Combine(Application.persistentDataPath, "remove_ad.txt");
        CheckAdRemoval();
    }

    void CheckAdRemoval() {
        if (File.Exists(removeAdFilePath)) {
            Debug.Log("���� ���ŵ�");
            gameManager.ad = 1;
        } else {
            Debug.Log("���� ���� �ȵ�");
        }
    }
    public static void MarkAdAsRemoved() {
        string filePath = Path.Combine(Application.persistentDataPath, "remove_ad.txt");
        File.WriteAllText(filePath, "purchased");
        Debug.Log("���� ���� ��ǰ ���� ������ ���Ͽ� �����");
    }
}
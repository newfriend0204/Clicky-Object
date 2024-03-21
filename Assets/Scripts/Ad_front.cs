using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using GoogleMobileAds;
using GoogleMobileAds.Api;

public class AdmobScreenAd : MonoBehaviour {
    string adUnitId;

    private InterstitialAd interstitialAd;
    private GameManager gameManager;


    public void Start() {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        MobileAds.Initialize((InitializationStatus initStatus) => {
            //초기화 완료
        });

#if UNITY_ANDROID
        adUnitId = "ca-app-pub-1315384883841951/6246059129";
#elif UNITY_IOS
            adUnitId = "ca-app-pub-3940256099942544/1712485313";
#else
            adUnitId = "unexpected_platform";
#endif

        LoadInterstitialAd();
    }

    public void LoadInterstitialAd() //광고 로드
    {
        if (interstitialAd != null) {
            interstitialAd.Destroy();
            interstitialAd = null;
        }

        Debug.Log("Loading the interstitial ad.");

        var adRequest = new AdRequest.Builder()
                .AddKeyword("unity-admob-sample")
                .Build();

        InterstitialAd.Load(adUnitId, adRequest,
            (InterstitialAd ad, LoadAdError error) => {
                if (error != null || ad == null) {
                    Debug.LogError("interstitial ad failed to load an ad " +
                                   "with error : " + error);
                    return;
                }

                Debug.Log("Interstitial ad loaded with response : "
                          + ad.GetResponseInfo());

                interstitialAd = ad;
            });
        RegisterEventHandlers(interstitialAd); //이벤트 등록
    }

    private void RegisterEventHandlers(InterstitialAd ad) //광고 이벤트
    {
        ad.OnAdPaid += (AdValue adValue) => {

            //보상 주기

            Debug.Log(string.Format("Interstitial ad paid {0} {1}.",
                adValue.Value,
                adValue.CurrencyCode));
        };
        ad.OnAdImpressionRecorded += () => {
            Debug.Log("Interstitial ad recorded an impression.");
        };
        ad.OnAdClicked += () => {
            Debug.Log("Interstitial ad was clicked.");
        };
        ad.OnAdFullScreenContentOpened += () => {
            Debug.Log("Interstitial ad full screen content opened.");
        };
        ad.OnAdFullScreenContentClosed += () => {
            Debug.Log("Interstitial ad full screen content closed.");
        };
        ad.OnAdFullScreenContentFailed += (AdError error) => {
            Debug.LogError("Interstitial ad failed to open full screen content " +
                           "with error : " + error);
        };
    }
    System.Random rand = new System.Random();
    private void Update() {
        if (gameManager.life <= 0) {
            ShowFrontAd();
            Destroy(gameObject);
        }
    }
    public void ShowFrontAd() {
        int random = rand.Next(1, 11);
        if (gameManager.ad == 1)
            random = 100;
        if (random <= 4) {
            if (interstitialAd != null && interstitialAd.CanShowAd()) {
                Debug.Log("Showing interstitial ad.");
                interstitialAd.Show();
            } else {
                LoadInterstitialAd();

                Debug.LogError("Interstitial ad is not ready yet.");
            }
        }
    }
}
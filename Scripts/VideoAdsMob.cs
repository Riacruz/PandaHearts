using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class VideoAdsMob : MonoBehaviour
{
    private InterstitialAd interstitial;
    public bool verVideo;

    void Start()
    {
        verVideo = false;
        RequestInterstitial();
    }

    private void RequestInterstitial()
    {
#if UNITY_ANDROID
    string adUnitId = "ca-app-pub-9593360452062088/6450111714";
#elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-3940256099942544/4411468910";
#else
        string adUnitId = "unexpected_platform";
#endif

    // Initialize an InterstitialAd.
    this.interstitial = new InterstitialAd(adUnitId);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder()
            .AddTestDevice("D871D88F9FBC771E5628764E872AE6B2") //Recuerda quitar en la version FINAL
            .TagForChildDirectedTreatment(true)
            .Build();
        // Load the interstitial with the request.
        this.interstitial.LoadAd(request);
    }

    public void GameOver()
    {
        if (this.interstitial.IsLoaded())
        {
            this.interstitial.Show();
            //print("VIDEO SHOW");
        }
    }

    private void Update()
    {
        if(PlayerPrefs.GetInt ("vecesPulsado")>=3)
        {
            verVideo = true;
            //print("3 veces muerto");
            
        }
    }

}

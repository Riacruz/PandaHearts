using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class BannerAdsMob : MonoBehaviour
{
#if UNITY_ANDROID
    // Use this for initialization
    private BannerView bannerView;
    void Awake()
    {

        string appUnitId = "ca-app-pub-9593360452062088~2794131251";
        MobileAds.Initialize(appUnitId);

    }
    private void AdsTest()
    {
        string adTest = "ca-app-pub-3940256099942544/6300978111";

        bannerView = new BannerView(adTest, AdSize.Banner, AdPosition.Bottom);
        AdRequest request = new AdRequest.Builder()
            .TagForChildDirectedTreatment(true)
            .Build();
        //AdRequest request = new AdRequest.Builder().Build();
        bannerView.LoadAd(request);
    }

    private void AdsReal()
    {
        string adUnitId = "ca-app-pub-9593360452062088/7233259082"; //banner id

        bannerView = new BannerView(adUnitId, AdSize.SmartBanner, AdPosition.Bottom);
        AdRequest request = new AdRequest.Builder()
            .AddTestDevice("D871D88F9FBC771E5628764E872AE6B2") //Recuerda quitar en la version FINAL
            .TagForChildDirectedTreatment(true)
            .Build();
        //AdRequest request = new AdRequest.Builder().Build();
        bannerView.LoadAd(request);
    }

    void Start()
    {


        //AdsTest();
        AdsReal();

    }

    void OnDisable()
    {

        bannerView.Destroy();
    }
#endif

}
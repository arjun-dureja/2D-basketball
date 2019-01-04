using UnityEngine;
using System.Collections;
using com.amazon.mas.cpt.ads;

public class AdTest : MonoBehaviour
{

    public string androidKey;

    public string iosKey;

    private IAmazonMobileAds mobileAds;

    private static AdTest instance2;

    public static AdTest Instance

    {
        get { return instance2; }
    }
    void Awake()
    {

        DontDestroyOnLoad(transform.gameObject);
        // If no Player ever existed, we are it.
        if (instance2 == null)
            instance2 = this;
        // If one already exist, it's because it came from another level.
        else if (instance2 != this)
        {
            Destroy(gameObject);
            return;
        }


        //CloseFloatingAd ();
        //DisplayInterstitial ();
    }


    // Use this for initialization
    void Start()
    {
        SetAppKey();
        DisplayInterstitial();
        DisplayFloatingAd();
        createBanner();

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void SetAppKey()
    {

        // Create a reference to the mobile ads instance

        mobileAds = AmazonMobileAdsImpl.Instance;



        // Create new key

        ApplicationKey key = new ApplicationKey();

        //zum Testen
        //key.StringValue = androidKey;

        // Set key based on OS

#if UNITY_ANDROID

        key.StringValue = androidKey;

#elif UNITY_IPHONE

        key.StringValue = iosKey;

#endif



        // Pass in the key

        mobileAds.SetApplicationKey(key);

    }

    public void EnableTesting()
    {

        //Create should enable instance

        ShouldEnable enable = new ShouldEnable();

        enable.BooleanValue = true;

        mobileAds.EnableTesting(enable);

        mobileAds.EnableLogging(enable);

    }



    Ad AdObject;
    /*
    public Ad CreateFloatingBannerAd(Placement input){

        IAmazonMobileAds mobileAds = AmazonMobileAdsImpl.Instance;
        Placement placement = new Placement ();
        placement.Dock = Dock.BOTTOM;

        placement.HorizontalAlign = HorizontalAlign.CENTER;

        placement.AdFit = AdFit.FIT_AD_SIZE;

        Ad response = mobileAds.CreateFloatingBannerAd (placement);

        string adType = response.AdType.ToString ();
        long identifier = response.Identifier;

    }*/


    public void CloseFloatingAd()
    {

        if (AdTest.Instance.AdObject != null)
        {
            IAmazonMobileAds mobileAds = AmazonMobileAdsImpl.Instance;
            mobileAds.CloseFloatingBannerAd(AdObject);
            CreateFloatingBannerAd();

        }
    }

    LoadingStarted LoadInterstitialAd()
    {
        IAmazonMobileAds mobileAds = AmazonMobileAdsImpl.Instance;
        LoadingStarted response = mobileAds.LoadInterstitialAd();
        bool loadingStarted = response.BooleanValue;
        return response;
    }

    public void createBanner()
    {
        CreateFloatingBannerAd();
    }


    Ad CreateFloatingBannerAd()
    {

        // Configure placement for the ad

        Placement placement = new Placement();

        //placement.Dock = Dock.TOP;
        placement.Dock = Dock.BOTTOM;

        placement.HorizontalAlign = HorizontalAlign.CENTER;

        placement.AdFit = AdFit.FIT_AD_SIZE;

        AdObject = mobileAds.CreateFloatingBannerAd(placement);
        return AdObject;
    }

    public void DisplayFloatingAd()
    {

        // Configure placement for the ad

        Placement placement = new Placement();

        //placement.Dock = Dock.TOP;
        placement.Dock = Dock.BOTTOM;

        placement.HorizontalAlign = HorizontalAlign.CENTER;

        placement.AdFit = AdFit.FIT_AD_SIZE;



        // This method returns an Ad object, which you must save and keep track of

        AdObject = mobileAds.CreateFloatingBannerAd(placement);



        // This method returns a LoadingStarted object

        LoadingStarted newResponse = mobileAds.LoadAndShowFloatingBannerAd(AdObject);

    }

    Ad AdInterstitial;
    AdShown AdSObject;

    public void createIad()
    {
        CreateInterstitialAd();
    }

    Ad CreateInterstitialAd()
    {

        Debug.Log("CreateInterstitialAd()+++++++");
        IAmazonMobileAds mobileAds = AmazonMobileAdsImpl.Instance;

        AdInterstitial = mobileAds.CreateInterstitialAd();

        string adType = AdInterstitial.AdType.ToString();
        long identifier = AdInterstitial.Identifier;
        /*
        LoadingStarted LSObject = mobileAds.LoadInterstitialAd();
        bool loadingStarted = LSObject.BooleanValue;
        */
        return AdInterstitial;
    }



    public void DisplayInterstitial()
    {

        CreateInterstitialAd();

        IAmazonMobileAds mobileAds = AmazonMobileAdsImpl.Instance;

        LoadingStarted LSObject = mobileAds.LoadInterstitialAd();
        bool loadingStarted = LSObject.BooleanValue;


        AdSObject = mobileAds.ShowInterstitialAd();
        //bool adSwohn = AdSObject.BooleanValue;


    }


}

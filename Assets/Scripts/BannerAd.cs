using UnityEngine;
using UnityEngine.Advertisements;
using System.Collections;

public class BannerAd : MonoBehaviour
{
    [SerializeField] BannerPosition _bannerPosition = BannerPosition.TOP_CENTER;
    [SerializeField] string _androidAdUnitId = "Banner_Android";
    [SerializeField] string _iOSAdUnitId = "Banner_iOS";
    string _adUnitId = null;

    bool isBannerLoaded = false;

    void Awake()
    {
#if UNITY_IOS
        _adUnitId = _iOSAdUnitId;
#elif UNITY_ANDROID
        _adUnitId = _androidAdUnitId;
#endif
    }

    void Start()
    {
        Advertisement.Banner.SetPosition(_bannerPosition);
        StartCoroutine(DisplayBannerWithDelay());
    }

    private IEnumerator DisplayBannerWithDelay()
    {
        yield return new WaitForSeconds(1f);
        LoadBanner();
    }


    public void LoadBanner()
    {
        BannerLoadOptions options = new BannerLoadOptions
        {
            loadCallback = OnBannerLoaded,
            errorCallback = OnBannerError
        };
        Advertisement.Banner.Load(_adUnitId, options);
    }

    void OnBannerLoaded()
    {
        Debug.Log("Banner loaded");
        isBannerLoaded = true;
        Debug.Log("isBannerLoaded: " + isBannerLoaded);
        ShowBannerAd();
    }

    void OnBannerError(string message)
    {
        Debug.Log($"Banner Error: {message}");
    }

    void ShowBannerAd()
    {
        Debug.Log("Attempting to show banner ad");

        if (isBannerLoaded)
        {
            Debug.Log("Banner is loaded, showing now...");
            Advertisement.Banner.Show(_adUnitId);
        }
        else
        {
            Debug.LogWarning("Trying to show banner ad before it's loaded. Call LoadBanner() first.");
        }
    }
}

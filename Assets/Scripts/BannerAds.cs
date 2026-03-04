using System.Collections;
using GoogleMobileAds.Api;
using UnityEngine;

public class BannerAds : MonoBehaviour
{
    private BannerView bannerView;
    private string bannerId = "ca-app-pub-3940256099942544/6300978111";
    //"ca-app-pub-8939167864595138/3757204458"
    public static BannerAds Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    void Start()
    {
        RequestBanner();
        StartCoroutine(CloseAd());
    }

    void Update()
    {

    }
    public void RequestBanner()
    {
        bannerView = new BannerView(bannerId, AdSize.Banner, AdPosition.Bottom);
        AdRequest request = new AdRequest();
        bannerView.LoadAd(request);

    }
    public void HideBanner()
    {
        bannerView.Destroy();
    }

    private IEnumerator CloseAd()
    {
        yield return new WaitForSeconds(4);
        HideBanner();
    }
}

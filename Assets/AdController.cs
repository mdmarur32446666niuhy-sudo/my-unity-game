using UnityEngine;
using GoogleMobileAds.Api;

public class AdController : MonoBehaviour
{
    // গুগলের অফিশিয়াল টেস্ট ব্যানার অ্যাড আইডি (পরে এখানে আপনার আসল আইডি বসাবেন)
    public string bannerUnitId = "ca-app-pub-3940256099942544/6300978111";
    private BannerView bannerView;

    void Start()
    {
        // ১. মোবাইল অ্যাডস SDK ইনিশিয়ালাইজ করা
        MobileAds.Initialize(initStatus => {
            Debug.Log("AdMob Initialized Successfully!");
            
            // SDK চালু হওয়ার পর ব্যানার অ্যাড লোড করার ফাংশন কল করা
            RequestBannerAd();
        });
    }

    // ব্যানার অ্যাড রিকোয়েস্ট ও শো করার ফাংশন
    public void RequestBannerAd()
    {
        // যদি আগে থেকেই কোনো ব্যানার চালু থাকে, তবে সেটি রিমুভ করে দেওয়া
        if (bannerView != null)
        {
            bannerView.Destroy();
        }

        // স্ক্রিনের নিচে ব্যানার অ্যাড তৈরি করা (Banner size, AdPosition.Bottom)
        bannerView = new BannerView(bannerUnitId, AdSize.Banner, AdPosition.Bottom);

        // অ্যাড লোড করার জন্য রিকোয়েস্ট পাঠানো
        AdRequest request = new AdRequest();
        bannerView.LoadAd(request);
    }
}
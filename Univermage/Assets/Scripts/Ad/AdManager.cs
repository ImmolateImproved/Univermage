using System;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour
{
    private string storeId = "3242528";
    private string placementId = "rewardedVideo";

    private void Awake()
    {
        Advertisement.Initialize(storeId, true);
        Advertisement.AddListener(new AdListener());
    }

    public void ShowAdd()
    {
        if (Advertisement.IsReady(placementId))
        {
            var adState = Advertisement.GetPlacementState(placementId);

            if (adState != PlacementState.NotAvailable)
            {
                Advertisement.Show();
            }
        }
    }
}

public class AdListener : IUnityAdsListener
{
    public void OnUnityAdsDidError(string message)
    {
        
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        switch (showResult)
        {
            case ShowResult.Finished:
                {
                    SaveManager.inst.AddSaves();
                }
                break;
        }
    }

    public void OnUnityAdsDidStart(string placementId)
    {

    }

    public void OnUnityAdsReady(string placementId)
    {

    }
}
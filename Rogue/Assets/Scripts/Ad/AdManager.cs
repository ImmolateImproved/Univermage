using System;
using UnityEngine;
using UnityEngine.Monetization;

public class AdManager : MonoBehaviour
{
    string storeId = "3242528";
    string placementId = "rewardedVideo";

    void Awake()
    {
        Monetization.Initialize(storeId, true);
    }

    public void ShowAdd()
    {
        if (Monetization.IsReady(placementId))
        {
            ShowAdPlacementContent ad = Monetization.GetPlacementContent(placementId) as ShowAdPlacementContent;

            if (ad != null)
            {
                ad.Show(AdCallback);
            }
        }
    }

    void AdCallback(ShowResult showResult)
    {
        switch (showResult)
        {
            case ShowResult.Finished:
                SaveManager.AddSaves();
                break;

            case ShowResult.Failed: throw new NotImplementedException();
        }
    }
}

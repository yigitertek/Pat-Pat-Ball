using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public UIManager uimanager;
    public AdManager admanager;
    public void Start()
    {
        CoinCalculator(0);
        Debug.Log(PlayerPrefs.GetInt("moneyy"));
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || gameObject.CompareTag("FinishLine"))
        {
            Debug.Log("Oyun Bitti");
            admanager.RequestInterstitial();
            admanager.RequestRewardedAd();
            CoinCalculator(100);
            uimanager.CoinTextUpdate();
            uimanager.FinishScreen();
        }
    }

    public void CoinCalculator(int money)
    {
        if (PlayerPrefs.HasKey("moneyy"))
        {
            int oldScore = PlayerPrefs.GetInt("moneyy");
            PlayerPrefs.SetInt("moneyy", oldScore + money);
        }
        else
        {
            PlayerPrefs.SetInt("moneyy", 0);
        }
    }

}

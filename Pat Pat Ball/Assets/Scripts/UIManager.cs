using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Image whiteEffectImage;
    private int effectcontrol = 0;


    public Animator layoutAnimator;

    // Butonlar
    public GameObject settings_Open;
    public GameObject settings_Close;
    public GameObject sound_On;
    public GameObject sound_Off;
    public GameObject vibration_On;
    public GameObject vibration_Off;
    public GameObject iap;
    public GameObject information;



    // Buton Fonksiyonları
    public void Settings_Open()
    {
        settings_Open.SetActive(false);
        settings_Close.SetActive(true);
        layoutAnimator.SetTrigger("Slide_in");
    }
    public void Settings_Close()
    {
        settings_Open.SetActive(true);
        settings_Close.SetActive(false);
        layoutAnimator.SetTrigger("Slide_out");
    }
    public void Sound_On()
    {
        sound_On.SetActive(false);
        sound_Off.SetActive(true);
    }
    public void Sound_Off()
    {
        sound_On.SetActive(true);
        sound_Off.SetActive(false);
    }
    public void Vibration_On()
    {
        vibration_On.SetActive(false);
        vibration_Off.SetActive(true);
    }
    public void Vibration_Off()
    {
        vibration_On.SetActive(true);
        vibration_Off.SetActive(false);
    }
    public IEnumerator WhiteEffect()
    {
        whiteEffectImage.gameObject.SetActive(true);
        while (effectcontrol == 0)
        {
            yield return new WaitForSeconds(0.01f); 
            whiteEffectImage.color += new Color(0, 0, 0, 0.1f);
            if (whiteEffectImage.color == new Color(whiteEffectImage.color.r, whiteEffectImage.color.g, whiteEffectImage.color.b,1))
            {
               effectcontrol = 1;
            }
        }
        while (effectcontrol == 1)
        {
            yield return new WaitForSeconds(0.01f);
            whiteEffectImage.color -= new Color(0, 0, 0, 0.1f);
            if (whiteEffectImage.color == new Color(whiteEffectImage.color.r, whiteEffectImage.color.g, whiteEffectImage.color.b, 0))
            {
                effectcontrol = 2;
            }
        }
        if (effectcontrol == 2)
        {
            Debug.Log("Efekt bitti");
        }
    }
        
}

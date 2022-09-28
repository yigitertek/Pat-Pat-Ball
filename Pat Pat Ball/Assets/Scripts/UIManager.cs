using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


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

    public GameObject intro_Hand;
    public GameObject toptomove_Text;
    public GameObject shop_Button;

    public GameObject restart_Screen;

    public void Start()
    {
        if (PlayerPrefs.HasKey("Sound") == false )
        {
            PlayerPrefs.SetInt("Sound", 1);
        }
        if (PlayerPrefs.HasKey("Vibration") == false)
        {
            PlayerPrefs.SetInt("Vibration", 1);
        }
    }

    public void FirstTouch()
    {
        intro_Hand.SetActive(false);
        toptomove_Text.SetActive(false);
        shop_Button.SetActive(false);
        settings_Open.SetActive(false);
        settings_Close.SetActive(false);
        vibration_On.SetActive(false);
        vibration_Off.SetActive(false);
        iap.SetActive(false);
        information.SetActive(false);
    }
    public void RestartButtonActive()
    {
        restart_Screen.SetActive(true);
    }
    public void RestartScene()
    {
        Variables.firstTouch = 0;
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }


    // Buton Fonksiyonlarý
    public void Settings_Open()
    {
        settings_Open.SetActive(false);
        settings_Close.SetActive(true);
        layoutAnimator.SetTrigger("Slide_in");
      
        if (PlayerPrefs.GetInt("Sound")==1)
        {
            sound_On.SetActive(true);
            sound_Off.SetActive(false);
            AudioListener.volume = 1;
        }
        else if (PlayerPrefs.GetInt("Sound") == 2)
        {
            sound_On.SetActive(false);
            sound_Off.SetActive(true);
            AudioListener.volume = 0;
        }


        if (PlayerPrefs.GetInt("Vibration")==1)
        {
            vibration_On.SetActive(true);
            vibration_Off.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("Vibration")==2)
        {
            vibration_On.SetActive(false);
            vibration_Off.SetActive(true);
        }

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
        AudioListener.volume = 0;
        PlayerPrefs.SetInt("Sound", 2);

    }
    public void Sound_Off()
    {
        sound_On.SetActive(true);
        sound_Off.SetActive(false);
        AudioListener.volume = 1;
        PlayerPrefs.SetInt("Sound", 1);

    }
    public void Vibration_On()
    {
        vibration_On.SetActive(false);
        vibration_Off.SetActive(true);
        PlayerPrefs.SetInt("Vibration", 2); 
    }
    public void Vibration_Off()
    {
        vibration_On.SetActive(true);
        vibration_Off.SetActive(false);
        PlayerPrefs.SetInt("Vibration", 1);
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

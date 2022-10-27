using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class UIManager : MonoBehaviour
{
    public SoundManager sounds;
    public Image whiteEffectImage;
    private int effectcontrol = 0;
    private bool radialshine = false;

    public Image fillRateImage;
    public GameObject Player;
    public GameObject finishLine;

    public Animator layoutAnimator;

    public TextMeshProUGUI coin_Text;

    // Butonlar
    public GameObject settings_Open;
    public GameObject settings_Close;
    public GameObject layout_Background;
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

    //Oyun Sonu Ekraný
    public GameObject finish_Screen;
    public GameObject blackBackground;
    public GameObject complete;
    public GameObject radial_Shine;
    public GameObject coin;
    public GameObject rewarded;
    public GameObject noThanks;

    public GameObject achievedCoin;
    public GameObject nextLevel;
    public TextMeshProUGUI achievedText;
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
        CoinTextUpdate();
    }
    public void Update()
    {
        if (radialshine==true)
        {
            radial_Shine.GetComponent<RectTransform>().Rotate(new Vector3(0, 0, 20 * Time.deltaTime));
        }
        fillRateImage.fillAmount = (Player.transform.position.z*1000 / (finishLine.transform.position.z))/1000;
    }

    public void FirstTouch()
    {
        intro_Hand.SetActive(false);
        toptomove_Text.SetActive(false);
        shop_Button.SetActive(false);
        settings_Open.SetActive(false);
        settings_Close.SetActive(false);
        layout_Background.SetActive(false);
        vibration_On.SetActive(false);
        vibration_Off.SetActive(false);
        iap.SetActive(false);
        information.SetActive(false);
    }
    public void CoinTextUpdate()
    {
        coin_Text.text = PlayerPrefs.GetInt("moneyy").ToString();
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
    public void NextScene()
    {
        Variables.firstTouch = 0;
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }
    public void FinishScreen()
    {
        StartCoroutine("FinishLaunch");
    }

    public IEnumerator FinishLaunch()
    {
        Time.timeScale = 0.4f;
        radialshine = true;
        finish_Screen.SetActive(true);
        blackBackground.SetActive(true);
        sounds.CompleteSound();
        yield return new WaitForSecondsRealtime(1f);
        complete.SetActive(true);
        sounds.CompleteSound();
        yield return new WaitForSecondsRealtime(0.7f);
        radial_Shine.SetActive(true);
        coin.SetActive(true);
        sounds.CompleteSound();
        yield return new WaitForSecondsRealtime(1f);
        rewarded.SetActive(true);
        sounds.CompleteSound();
        yield return new WaitForSecondsRealtime(3f);
        noThanks.SetActive(true);
        sounds.CompleteSound();
    }
    public IEnumerator AfterRewardButton()
    {
        achievedCoin.SetActive(true);
        achievedText.gameObject.SetActive(true);
        rewarded.SetActive(false);
        noThanks.SetActive(false);
        for (int i = 0; i <= 400; i += 4)
        {
            achievedText.text = "+" + i.ToString();
            yield return new WaitForSeconds(0.0001f);
        }    
        yield return new WaitForSecondsRealtime(1f);
        nextLevel.SetActive(true);
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

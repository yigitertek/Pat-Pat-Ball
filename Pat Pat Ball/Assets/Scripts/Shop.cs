using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public UIManager uimaneger;

    public GameObject particle1;
    public GameObject particle2;
    public GameObject particle3;
    public GameObject particle4;
    public GameObject particle5;
    public GameObject particle6;

    public Sprite GreyImage;
    public Sprite GreenImage;

    public GameObject Item1;
    public GameObject Item2;
    public GameObject Item3;
    public GameObject Item4;
    public GameObject Item5;
    public GameObject Item6;

    public GameObject Lock2;
    public GameObject Lock3;
    public GameObject Lock4;
    public GameObject Lock5;
    public GameObject Lock6;

    public void Awake()
    {
        if (PlayerPrefs.HasKey("itemselect") == false)
            PlayerPrefs.SetInt("itemselect", 0);

        //-------------ItemSelect-------------
        if (PlayerPrefs.GetInt("itemselect") == 0)
            Item1Open();
        else if (PlayerPrefs.GetInt("itemselect") == 1)
            Item2Open();
        else if (PlayerPrefs.GetInt("itemselect") == 2)
            Item3Open();
        else if (PlayerPrefs.GetInt("itemselect") == 3)
            Item4Open();
        else if (PlayerPrefs.GetInt("itemselect") == 4)
            Item5Open();
        else if (PlayerPrefs.GetInt("itemselect") == 5)
            Item6Open();


            //---------------LOCKS--------------
            if (PlayerPrefs.HasKey("lock2control")==false)
            PlayerPrefs.SetInt("lock2control", 0);

        if (PlayerPrefs.HasKey("lock3control")==false)
            PlayerPrefs.SetInt("lock3control", 0);

        if (PlayerPrefs.HasKey("lock4control")==false)
            PlayerPrefs.SetInt("lock4control", 0);

        if (PlayerPrefs.HasKey("lock5control")==false)
            PlayerPrefs.SetInt("lock5control", 0);

        if (PlayerPrefs.HasKey("lock6control"))
            PlayerPrefs.SetInt("lock6control", 0);

        if (PlayerPrefs.GetInt("lock2control") == 1)
            Lock2.SetActive(false);
        if (PlayerPrefs.GetInt("lock3control") == 1)
            Lock3.SetActive(false);
        if (PlayerPrefs.GetInt("lock4control") == 1)
            Lock4.SetActive(false);
        if (PlayerPrefs.GetInt("lock5control") == 1)
            Lock5.SetActive(false);
        if (PlayerPrefs.GetInt("lock6control") == 1)
            Lock6.SetActive(false);

    }

    public void Item1Open()
    {
        particle1.SetActive(true);
        particle2.SetActive(false);
        particle3.SetActive(false);
        particle4.SetActive(false);
        particle5.SetActive(false);
        particle6.SetActive(false);

        Item1.GetComponent<Image>().sprite = GreenImage;
        Item2.GetComponent<Image>().sprite = GreyImage;
        Item3.GetComponent<Image>().sprite = GreyImage;
        Item4.GetComponent<Image>().sprite = GreyImage;
        Item5.GetComponent<Image>().sprite = GreyImage;
        Item6.GetComponent<Image>().sprite = GreyImage;

        PlayerPrefs.SetInt("itemselect", 0);
    }

    public void Item2Open()
    {
        particle1.SetActive(false);
        particle2.SetActive(true);
        particle3.SetActive(false);
        particle4.SetActive(false);
        particle5.SetActive(false);
        particle6.SetActive(false);

        Item1.GetComponent<Image>().sprite = GreyImage;
        Item2.GetComponent<Image>().sprite = GreenImage;
        Item3.GetComponent<Image>().sprite = GreyImage;
        Item4.GetComponent<Image>().sprite = GreyImage;
        Item5.GetComponent<Image>().sprite = GreyImage;
        Item6.GetComponent<Image>().sprite = GreyImage;

        PlayerPrefs.SetInt("itemselect", 1);
    }
    public void Item3Open()
    {
        particle1.SetActive(false);
        particle2.SetActive(false);
        particle3.SetActive(true);
        particle4.SetActive(false);
        particle5.SetActive(false);
        particle6.SetActive(false);

        Item1.GetComponent<Image>().sprite = GreyImage;
        Item2.GetComponent<Image>().sprite = GreyImage;
        Item3.GetComponent<Image>().sprite = GreenImage;
        Item4.GetComponent<Image>().sprite = GreyImage;
        Item5.GetComponent<Image>().sprite = GreyImage;
        Item6.GetComponent<Image>().sprite = GreyImage;

        PlayerPrefs.SetInt("itemselect", 2);
    }
    public void Item4Open()
    {
        particle1.SetActive(false);
        particle2.SetActive(false);
        particle3.SetActive(false);
        particle4.SetActive(true);
        particle5.SetActive(false);
        particle6.SetActive(false);

        Item1.GetComponent<Image>().sprite = GreyImage;
        Item2.GetComponent<Image>().sprite = GreyImage;
        Item3.GetComponent<Image>().sprite = GreyImage;
        Item4.GetComponent<Image>().sprite = GreenImage;
        Item5.GetComponent<Image>().sprite = GreyImage;
        Item6.GetComponent<Image>().sprite = GreyImage;

        PlayerPrefs.SetInt("itemselect", 3);
    }
    public void Item5Open()
    {
        particle1.SetActive(false);
        particle2.SetActive(false);
        particle3.SetActive(false);
        particle4.SetActive(false);
        particle5.SetActive(true);
        particle6.SetActive(false);

        Item1.GetComponent<Image>().sprite = GreyImage;
        Item2.GetComponent<Image>().sprite = GreyImage;
        Item3.GetComponent<Image>().sprite = GreyImage;
        Item4.GetComponent<Image>().sprite = GreyImage;
        Item5.GetComponent<Image>().sprite = GreenImage;
        Item6.GetComponent<Image>().sprite = GreyImage;

        PlayerPrefs.SetInt("itemselect", 4);
    }
    public void Item6Open()
    {
        particle1.SetActive(false);
        particle2.SetActive(false);
        particle3.SetActive(false);
        particle4.SetActive(false);
        particle5.SetActive(false);
        particle6.SetActive(true);

        Item1.GetComponent<Image>().sprite = GreyImage;
        Item2.GetComponent<Image>().sprite = GreyImage;
        Item3.GetComponent<Image>().sprite = GreyImage;
        Item4.GetComponent<Image>().sprite = GreyImage;
        Item5.GetComponent<Image>().sprite = GreyImage;
        Item6.GetComponent<Image>().sprite = GreenImage;

        PlayerPrefs.SetInt("itemselect", 5);
    }
    //--------------------------------LOCKS-------------------------------
    public void Lock2Open()
    {
        int money = PlayerPrefs.GetInt("moneyy");
        int lock2control = PlayerPrefs.GetInt("lock2control");
        if (money >= 5000 && lock2control == 0)
        {
            Lock2.SetActive(false);
            PlayerPrefs.SetInt("moneyy", money - 5000);
            PlayerPrefs.SetInt("lock2control", 1);
            Item2Open();
            uimaneger.CoinTextUpdate();
        }
    }

    public void Lock3Open()
    {
        int money = PlayerPrefs.GetInt("moneyy");
        int lock3control = PlayerPrefs.GetInt("lock3control");
        if (money >= 10000 && lock3control == 0)
        {
            Lock3.SetActive(false);
            PlayerPrefs.SetInt("moneyy", money - 10000);
            PlayerPrefs.SetInt("lock3control", 1);
            Item3Open();
            uimaneger.CoinTextUpdate();
        }
    }

    public void Lock4Open()
    {
        int money = PlayerPrefs.GetInt("moneyy");
        int lock4control = PlayerPrefs.GetInt("lock4control");
        if (money >= 15000)
        {
            Lock4.SetActive(false);
            PlayerPrefs.SetInt("moneyy", money - 15000);
            PlayerPrefs.SetInt("lock4control", 1);
            Item4Open();
            uimaneger.CoinTextUpdate();
        }
    }

    public void Lock5Open()
    {
        int money = PlayerPrefs.GetInt("moneyy");
        int lock5control = PlayerPrefs.GetInt("lock5control");
        if (money >= 25000)
        {
            Lock5.SetActive(false);
            PlayerPrefs.SetInt("moneyy", money - 25000);
            PlayerPrefs.SetInt("lock5control", 1);
            Item5Open();
            uimaneger.CoinTextUpdate();
        }
    }

    public void Lock6Open()
    {
        int money = PlayerPrefs.GetInt("moneyy");
        int lock5control = PlayerPrefs.GetInt("lock5control");
        if (money >= 50000)
        {
            Lock6.SetActive(false);
            PlayerPrefs.SetInt("moneyy", money - 50000);
            PlayerPrefs.SetInt("lock6control", 1);
            Item6Open();
            uimaneger.CoinTextUpdate();
        }
    }
}


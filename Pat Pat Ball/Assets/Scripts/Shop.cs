using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public GameObject particle1;
    public GameObject particle2;
    public GameObject particle3;
    public GameObject particle4;
    public GameObject particle5;
    public GameObject particle6;

    public Sprite YellowImage;
    public Sprite GreenImage;

    public GameObject Item1;
    public GameObject Item2;
    public GameObject Item3;
    public GameObject Item4;
    public GameObject Item5;
    public GameObject Item6;

    public void Item1Open()
    {
        particle1.SetActive(false);
        particle2.SetActive(true);
        particle3.SetActive(false);
        particle4.SetActive(false);
        particle5.SetActive(false);
        particle6.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    public CameraShake cameraShake;
    public UIManager uiManager;
    public SoundManager sounds;

    public GameObject cam;
    public GameObject vectorBack;
    public GameObject vectorForward;

    private Rigidbody rb;

    private Touch touch;
    [Range(10,40)]
    public int speedModifier;
    public int forwardSpeed;

    private bool speedBallForward=false;
    private bool firstTouchControl = false;

    private int soundLimitCount;

  
    public void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void Update()
    {
        if (Variables.firstTouch == 1 && speedBallForward ==false)
        {
            transform.position += new Vector3(0, 0, forwardSpeed * Time.deltaTime);
            vectorBack.transform.position += new Vector3(0, 0, forwardSpeed * Time.deltaTime);
            vectorForward.transform.position += new Vector3(0, 0, forwardSpeed * Time.deltaTime);
        }
        if (Input.touchCount >0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                {
                    if (firstTouchControl == false)
                    {
                        Variables.firstTouch = 1;
                        uiManager.FirstTouch();
                        firstTouchControl = true;
                    }          
                }      
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                {
                    rb.velocity = new Vector3(touch.deltaPosition.x * speedModifier * Time.deltaTime,
                                     transform.position.y,
                                     touch.deltaPosition.y * speedModifier * Time.deltaTime);

                    if (firstTouchControl == false)
                    {
                        Variables.firstTouch = 1;
                        uiManager.FirstTouch();
                        firstTouchControl = true;
                    }
                }
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                rb.velocity = Vector3.zero;
            }
           
        }
    }
    public GameObject[] FractureItems;
    public void OnCollisionEnter(Collision hit)
    {
        if (hit.gameObject.CompareTag("Obstacles"))
        {
            cameraShake.CameraShakesCall();
            uiManager.StartCoroutine("WhiteEffect");
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            sounds.BlowSound();
            if (PlayerPrefs.GetInt("Vibration")==1)
            {
                Vibration.Vibrate(100);
            }
            else if (PlayerPrefs.GetInt("Vibration")==2)
            {
                Debug.Log("no vibration");
            }
            Vibration.Vibrate(50);
            foreach (GameObject item in FractureItems)
            {
                item.GetComponent<SphereCollider>().enabled = true;
                item.GetComponent<Rigidbody>().isKinematic = false;
            }
            StartCoroutine(TimeScaleControl());
        }
        if (hit.gameObject.CompareTag("Untagged"))
        {
            
            soundLimitCount++;
        }
        if (hit.gameObject.CompareTag("Untagged") && soundLimitCount % 5 == 0)
        {
            sounds.ObjectHitSound();
        }
    }
    public IEnumerator TimeScaleControl()
    {
        speedBallForward = true;
        yield return new WaitForSecondsRealtime(0.5f);
        Time.timeScale = 0.4f;
        yield return new WaitForSecondsRealtime(0.5f);
        uiManager.RestartButtonActive();
        rb.velocity = Vector3.zero;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    static Manager instance;
    public GameObject[] QRimg;
    public GameObject[] cube;
    private GameObject camera;
    private GameObject cloneCamera;
    private GameObject ARCamera;
    public static bool isEnableObj = false;

    void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        foreach (var item in cube)
        {
            item.SetActive(false);
        }
    }

    private void Update()
    {
        if(camera == null)
        {
            camera = GameObject.Find("TextureBufferCamera");
            if(camera!= null)
            {
                cloneCamera = Instantiate(camera,new Vector3(0,0,1977),new Quaternion(0,0,180,0));
                cloneCamera.transform.localScale = new Vector3(-2000,2000,0);
                print(cloneCamera.transform.position);
                ARCamera = GameObject.Find("BackgroundPlane");
            }
        }
        /*if (ARCamera != null)
        {
            print(ARCamera.transform.position);
        }*/
        if(QRimg[0].GetComponent<DefaultTrackableEventHandler>().Appear == true)
        {
            cube[0].SetActive(true);
            cube[1].SetActive(false);
            cube[2].SetActive(false);
            cube[3].SetActive(false);
        }
        else if(QRimg[1].GetComponent<DefaultTrackableEventHandler>().Appear == true &&
            QRimg[0].GetComponent<DefaultTrackableEventHandler>().Appear == false)
        {
            cube[0].SetActive(false);
            cube[1].SetActive(true);
            cube[2].SetActive(false);
            cube[3].SetActive(false);
        }
        else if (QRimg[2].GetComponent<DefaultTrackableEventHandler>().Appear == true &&
            QRimg[0].GetComponent<DefaultTrackableEventHandler>().Appear == false &&
            QRimg[1].GetComponent<DefaultTrackableEventHandler>().Appear == false)
        {
            cube[0].SetActive(false);
            cube[1].SetActive(false);
            cube[2].SetActive(true);
            cube[3].SetActive(false);
        }
        else if (QRimg[3].GetComponent<DefaultTrackableEventHandler>().Appear == true &&
            QRimg[0].GetComponent<DefaultTrackableEventHandler>().Appear == false &&
            QRimg[1].GetComponent<DefaultTrackableEventHandler>().Appear == false &&
            QRimg[2].GetComponent<DefaultTrackableEventHandler>().Appear == false)
        {
            cube[0].SetActive(false);
            cube[1].SetActive(false);
            cube[2].SetActive(false);
            cube[3].SetActive(true);
        }
    }

}

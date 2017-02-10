using UnityEngine;
using System.Collections;

public class cam : MonoBehaviour
{
    public string deviceName;
    WebCamTexture webCam;
    
    void Start()
    {
        WebCamDevice[] devices = WebCamTexture.devices;
        deviceName = devices[0].name;
        webCam = new WebCamTexture(deviceName, 400, 300, 12);
        GetComponent<Renderer>().material.mainTexture = webCam;
        webCam.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }
}


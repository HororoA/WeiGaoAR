using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ImageMove : MonoBehaviour {

    public Image Left;
    public Image Right;
    public Image WightImage;
    public Image LeftText;
    public Image RightText;
    public Image BackGround;
    public Image Logo;
    public Sprite resetSp;
    public static bool canTouch;
    public static int step = 0;


    // Use this for initialization
	void Start () {
        ResetPos();
	}

    public void ImageMoveTo(string leftORright, Sprite sp)
    {
        if (leftORright == "left")
        {
            StartCoroutine(StartInvokeLeft(sp));
        }
        if (leftORright == "right")
        {
            StartCoroutine(StartInvokeRight(sp));
        }
    }

    public void ResetPos() 
    {
        canTouch = false;
        BackGround.sprite = resetSp;
        WightImage.color = new Color32(255, 255, 255, 0);
        LeftText.color = new Color32(255, 255, 255, 0);
        RightText.color = new Color32(255, 255, 255, 0);
        Logo.color = new Color32(255, 255, 255, 0);
        Left.GetComponent<RectTransform>().localPosition = new Vector3(-505, 0, 0);
        Right.GetComponent<RectTransform>().localPosition = new Vector3(505, 0, 0);
    }

    public void PageOneMove(Sprite sp)
    {
        StartCoroutine(PageOneInokeMove(sp));
    }

    IEnumerator PageOneInokeMove(Sprite sp) {
        InvokeRepeating("coloralpha", 0.02f, 0.02f);
        yield return new WaitForSeconds(2f);
        CancelInvoke("coloralpha");
        BackGround.sprite = sp;
        InvokeRepeating("coloralphaback", 0.02f, 0.02f);
        yield return new WaitForSeconds(0.6f);
        CancelInvoke("coloralphaback");
        canTouch = true;
    }

    IEnumerator StartInvokeLeft(Sprite sp)
    {
        InvokeRepeating("moveTo", 0.02f, 0.02f);
        yield return new WaitForSeconds(2f);
        CancelInvoke("moveTo");
        BackGround.sprite = sp;
        InvokeRepeating("moveBack", 0.02f, 0.02f);
        yield return new WaitForSeconds(0.6f);
        CancelInvoke("moveBack");
        InvokeRepeating("moveTo1", 0.02f, 0.02f);
        yield return new WaitForSeconds(1.5f);
        CancelInvoke("moveTo1");
        canTouch = true;
    }

    IEnumerator StartInvokeRight(Sprite sp)
    {
        InvokeRepeating("moveTo", 0.02f, 0.02f);
        yield return new WaitForSeconds(2f);
        CancelInvoke("moveTo");
        BackGround.sprite = sp;
        InvokeRepeating("moveBack", 0.02f, 0.02f);
        yield return new WaitForSeconds(0.6f);
        CancelInvoke("moveBack");
        InvokeRepeating("moveTo2", 0.02f, 0.02f);
        yield return new WaitForSeconds(1.5f);
        CancelInvoke("moveTo2");
        canTouch = true;
    }

    void coloralpha()
    {
        colorChange(WightImage, new Color32(255, 255, 255, 255), 3);
        colorChange(Logo, new Color32(255, 255, 255, 255), 3);
    }

    void coloralphaback()
    {
        colorChange(Logo, new Color32(255, 255, 255, 0), 8);
        colorChange(WightImage, new Color32(255, 255, 255, 50), 3);
    }

    void moveTo() 
    {
        imageMoveTo(Left, new Vector3(0, 0, 0),3);
        imageMoveTo(Right, new Vector3(330, 0, 0),3);
        colorChange(WightImage, new Color32(255, 255, 255, 255), 3);
        colorChange(Logo, new Color32(255, 255, 255, 255), 3);
        colorChange(LeftText, new Color32(255, 255, 255, 0), 3);
        colorChange(RightText, new Color32(255, 255, 255, 0), 3);
    }

    void moveTo1()
    {
        imageMoveTo(Left, new Vector3(-330, 0, 0),5);
        imageMoveTo(Right, new Vector3(505, 0, 0),5);

        colorChange(WightImage, new Color32(255, 255, 255, 0), 3);
        colorChange(LeftText, new Color32(255, 255, 255, 255), 3);
    }

    void moveTo2()
    {
        imageMoveTo(Left, new Vector3(-505, 0, 0),3);
        imageMoveTo(Right, new Vector3(330, 0, 0),3);

        colorChange(WightImage, new Color32(255, 255, 255, 0), 3);
        colorChange(RightText, new Color32(255, 255, 255, 255), 3);
    }

    void moveBack()
    {
        colorChange(Logo, new Color32(255, 255, 255, 0), 8);
        imageMoveTo(Left, new Vector3(-505, 0, 0),5);
        imageMoveTo(Right, new Vector3(505, 0, 0),5);
        colorChange(WightImage, new Color32(255, 255, 255, 50), 3);
    }

    void imageMoveTo(Image im,Vector3 v,int i) 
    {
        Vector3 vec = im.GetComponent<RectTransform>().localPosition;
        im.GetComponent<RectTransform>().localPosition = Vector3.Lerp(vec, v, Time.deltaTime * i);
    }

    public void colorChange(Image im,Color32 v,int i) 
    {
        Color32 vec = im.color;
        im.color = Color32.Lerp(vec, v, Time.deltaTime * i);
    }
}

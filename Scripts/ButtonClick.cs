using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour
{

    BookData _BookData;
    GameData _GameData;
    Camera MainUICamera;
    ImagesMove _ImagesMove;
    animectr _animectr;
    ImageMove _ImageMove;

    public GameObject SaoMao;
    public GameObject[] SixQukuaiZhuanYong;
    public Sprite[] buttonAllSp1;
    public Sprite[] buttonAllSp_1;

    public Image BackGround;
    public Image mid;

    public Sprite[] bgSp;

    public Image button1, button2, button3, button1_1, button2_1, button3_1;

    public Sprite[] Huxings;
    public GameObject HuxingImage;
    public Sprite[] Qukuais;
    public GameObject QukuaiImage;
    public GameObject[] BieShuHuxing;
    private int j = 1;
    private int temp;

    public Camera ARCameraGam;

    void Awake()
    {
        _BookData = GameObject.Find("Scripts").GetComponent<BookData>();
        _GameData = GameObject.Find("Scripts").GetComponent<GameData>();
        _ImagesMove = GameObject.Find("Scripts").GetComponent<ImagesMove>();
        _ImageMove = GameObject.Find("Scripts").GetComponent<ImageMove>();
    }

    public void Button_QuWei_Click()
    {
        if (ImageMove.canTouch)
        {
            _BookData.bookState = BookData.BookState.pageTwo;
            ImageMove.canTouch = false;
        }
    }

    public void Button_HuXing_Click()
    {
        if (ImageMove.canTouch)
        {
            //if (_GameData.gameState == GameData.GameState.Three)
            //{
            //    _BookData.bookState = BookData.BookState.pageFour;
            //}
            //else
            //{
            //    _BookData.bookState = BookData.BookState.pageThree;
            //}
            _BookData.bookState = BookData.BookState.pageThree;
            ImageMove.canTouch = false;
            ImageMove.step = 3;
            _ImagesMove.Vector333(0);
        }
    }

    public void Back1()
    {
        if (ImageMove.canTouch)
        {
            Debug.Log("Back1");
            _BookData.bookState = BookData.BookState.pageOne;
            ImageMove.step = 1;
            ImageMove.canTouch = false;
        }
    }

    public void Button_YangBan_Click()
    {
        if (ImageMove.canTouch)
        {
            _BookData.bookState = BookData.BookState.pageFour;
            ImageMove.canTouch = false;
            ImageMove.step = 4;
        }

    }

    public void Back2()
    {
        if (ImageMove.canTouch)
        {
            Debug.Log("Back2");
            _BookData.bookState = BookData.BookState.pageTwo;
            ImageMove.step = 2;
            ImageMove.canTouch = false;
        }
    }

    public GameObject StartUI;
    public ImageTargetBehaviour _ImageTargetBehaviour;
    public GameObject ARGam;
    public GameObject ca;

    public GameObject[] NewUI;


    public void startUI()
    {
        StartUI.SetActive(false);
        ARGam.SetActive(true);
        _ImageTargetBehaviour.ResetAR();
        ARCameraGam.enabled = true;
        try
        {
            _GameData.ARCameraGam.enabled = true;
            SaoMao.SetActive(true);
            Camera ARCameraGam2 = GameObject.Find("camera background").GetComponent<Camera>();
            ARCameraGam2.enabled = true;
        }
        catch (System.Exception)
        {

        }
    }

    public void starthalfUI()
    {
        Camera ARCameraGam2 = GameObject.Find("camera background").GetComponent<Camera>();
        ARCameraGam2.enabled = false;
        ca.SetActive(false);
        _BookData.bookState = BookData.BookState.pageOne;
        ImageMove.step = 1;
        //_GameData.ARCameraGam.enabled = false;
        _GameData.cam.enabled = true;
    }

    public void BackToStart()
    {
        //Debug.Log(123);
        StartUI.SetActive(true);
        _ImageTargetBehaviour.CloseAR();
        _GameData.CloseAR();
        Camera ARCameraGam2 = GameObject.Find("camera background").GetComponent<Camera>();
        ARCameraGam2.enabled = false;
        ARCameraGam.enabled = true;
        _GameData.gameState = GameData.GameState.none;
        _BookData.bookState = BookData.BookState.none;
    }

    public void ResetButtonImage()
    {
        button1.sprite = buttonAllSp_1[0];
        button2.sprite = buttonAllSp1[1];
        button3.sprite = buttonAllSp1[2];
    }

    public void ResetButtonImage1()
    {

        button1_1.sprite = buttonAllSp_1[0];
        button2_1.sprite = buttonAllSp1[1];
        button3_1.sprite = buttonAllSp1[2];
    }

    public void SixButton1()
    {
        if (_BookData.bookState == BookData.BookState.pageOne)
        {
            button1.sprite = buttonAllSp_1[0];
            button2.sprite = buttonAllSp1[1];
            button3.sprite = buttonAllSp1[2];
            BackGround.sprite = bgSp[0];
        }
        if (_BookData.bookState == BookData.BookState.pageThree && ImagesMove.canMove)
        {
            button1.sprite = buttonAllSp_1[0];
            button2.sprite = buttonAllSp1[1];
            button3.sprite = buttonAllSp1[2];
            _BookData.sp1 = _GameData.sixSp2_1;
            _ImagesMove.allSp = _GameData.sixSp2_1;
            //_ImagesMove.Reset();
            mid.sprite = _GameData.sixSp4[0];
            _GameData.HuxingButtons[5].SetActive(true);
            _GameData.HuxingButtons[6].SetActive(false);
            _GameData.HuxingButtons[7].SetActive(false);
            //_ImagesMove.Reset();
        }
    }

    public void SixButton2()
    {

        if (_BookData.bookState == BookData.BookState.pageOne)
        {
            button2.sprite = buttonAllSp_1[1];
            button1.sprite = buttonAllSp1[0];
            button3.sprite = buttonAllSp1[2];
            BackGround.sprite = bgSp[1];
        }
        if (_BookData.bookState == BookData.BookState.pageThree && ImagesMove.canMove)
        {
            button2.sprite = buttonAllSp_1[1];
            button1.sprite = buttonAllSp1[0];
            button3.sprite = buttonAllSp1[2];
            _BookData.sp1 = _GameData.sixSp2_2;
            _ImagesMove.allSp = _GameData.sixSp2_2;
            _ImagesMove.Reset();
            _GameData.HuxingButtons[5].SetActive(false);
            _GameData.HuxingButtons[6].SetActive(true);
            _GameData.HuxingButtons[7].SetActive(false);
            mid.sprite = _GameData.sixSp4[1];

            //_ImagesMove.Reset();
        }
    }

    public void SixButton3()
    {

        if (_BookData.bookState == BookData.BookState.pageOne)
        {
            button3.sprite = buttonAllSp_1[2];
            button1.sprite = buttonAllSp1[0];
            button2.sprite = buttonAllSp1[1];
            BackGround.sprite = bgSp[2];
        }
        if (_BookData.bookState == BookData.BookState.pageThree && ImagesMove.canMove)
        {
            button3.sprite = buttonAllSp_1[2];
            button1.sprite = buttonAllSp1[0];
            button2.sprite = buttonAllSp1[1];
            _BookData.sp1 = _GameData.sixSp2_3;
            _ImagesMove.allSp = _GameData.sixSp2_3;
            _ImagesMove.Reset();
            mid.sprite = _GameData.sixSp4[2];
            _GameData.HuxingButtons[5].SetActive(false);
            _GameData.HuxingButtons[6].SetActive(false);
            _GameData.HuxingButtons[7].SetActive(true);
            //mid.sprite = _GameData.sixSp2_3[0];
            //_ImagesMove.Reset();
        }
    }

    public void SixButton1_1()
    {
        if (_BookData.bookState == BookData.BookState.pageFour)
        {
            button1_1.sprite = buttonAllSp_1[0];
            button2_1.sprite = buttonAllSp1[1];
            button3_1.sprite = buttonAllSp1[2];
            _BookData.sp1 = _GameData.sixSp3_1;
            _ImagesMove.allSp = _GameData.sixSp3_1;
            _ImagesMove.Reset();
            mid.sprite = _GameData.sixSp3_1[0];
        }
    }

    public void SixButton2_1()
    {
        if (_BookData.bookState == BookData.BookState.pageFour)
        {
            button2_1.sprite = buttonAllSp_1[1];
            button1_1.sprite = buttonAllSp1[0];
            button3_1.sprite = buttonAllSp1[2];

            _BookData.sp1 = _GameData.sixSp3_2;
            _ImagesMove.allSp = _GameData.sixSp3_2;
            _ImagesMove.Reset();
            mid.sprite = _GameData.sixSp3_2[0];
            //_ImagesMove.Reset();
        }
    }

    public void SixButton3_1()
    {
        if (_BookData.bookState == BookData.BookState.pageFour)
        {
            button3_1.sprite = buttonAllSp_1[2];
            button1_1.sprite = buttonAllSp1[0];
            button2_1.sprite = buttonAllSp1[1];
            _BookData.sp1 = _GameData.sixSp3_3;
            _ImagesMove.allSp = _GameData.sixSp3_3;
            _ImagesMove.Reset();
            mid.sprite = _GameData.sixSp3_3[0];
        }
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void HuxingButtons(string A)
    {
        int i = 0;
        bool isSix = false;
        HuxingImage.SetActive(true);
        switch (A)
        {
            case "A":
                i = 0;
                break;
            case "B":
                i = 1;
                break;
            case "C":
                i = 2;
                break;
            case "D":
                i = 3;
                break;
            case "E":
                i = 4;
                break;
            case "F":
                i = 5;
                break;
            case "G":
                i = 6;
                break;
            case "H":
                i = 7;
                break;
            case "I":
                i = 8;
                break;
            case "Z":
                i = 59;
                break;
            default:
                isSix = true;
                break;
        }
        switch (_GameData.gameState)
        {
            case GameData.GameState.Two:
                if (i * 5 >= 10)
                {
                    i = i + 8;
                    break;
                }
                else
                {
                    temp = i;
                    BieShuHuxing[0].SetActive(true);
                    BieShuHuxing[1].SetActive(true);
                    BieShuHuxing[1].GetComponent<Image>().sprite = _GameData.NextButtons[0];
                    BieShuHuxing[0].GetComponent<Image>().sprite = Huxings[temp * 5 + j];
                    i = i * 5;
                    break;
                }
            case GameData.GameState.Three:
                temp = i;
                BieShuHuxing[0].SetActive(true);
                BieShuHuxing[1].SetActive(true);
                BieShuHuxing[1].GetComponent<Image>().sprite = _GameData.NextButtons[1];
                BieShuHuxing[0].GetComponent<Image>().sprite = Huxings[temp * 4 + j];
                i = i * 4;
                break;
            case GameData.GameState.Six:
                if (isSix)
                {
                    temp = int.Parse(A);
                    BieShuHuxing[0].SetActive(true);
                    BieShuHuxing[1].SetActive(true);
                    BieShuHuxing[1].GetComponent<Image>().sprite = _GameData.NextButtons[2];
                    BieShuHuxing[0].GetComponent<Image>().sprite = Huxings[int.Parse(A) + j];
                }
                break;
        }
        if (isSix) HuxingImage.GetComponent<Image>().sprite = Huxings[int.Parse(A)];
        else HuxingImage.GetComponent<Image>().sprite = Huxings[i];
    }

    public void QukuaiButtons(int Ga)
    {
        if (Ga == 140)
        {
            QukuaiImage.SetActive(true);
            QukuaiImage.GetComponent<Image>().sprite = Qukuais[Ga / 10];
            SixQukuaiZhuanYong[0].SetActive(false);
            SixQukuaiZhuanYong[1].SetActive(false);
            SixQukuaiZhuanYong[2].SetActive(false);
            SixQukuaiZhuanYong[3].SetActive(false);
            SixQukuaiZhuanYong[4].SetActive(false);
            SixQukuaiZhuanYong[5].SetActive(false);
            SixQukuaiZhuanYong[6].SetActive(false);
            SixQukuaiZhuanYong[7].SetActive(true);
            SixQukuaiZhuanYong[8].SetActive(true);
            SixQukuaiZhuanYong[9].SetActive(true);
            return;
        }
        if (Ga == 70)
        {
            SixQukuaiZhuanYong[0].SetActive(true);
            SixQukuaiZhuanYong[1].SetActive(true);
            SixQukuaiZhuanYong[2].SetActive(true);
            SixQukuaiZhuanYong[3].SetActive(true);
            SixQukuaiZhuanYong[4].SetActive(true);
            SixQukuaiZhuanYong[5].SetActive(true);
            SixQukuaiZhuanYong[6].SetActive(true);
            SixQukuaiZhuanYong[7].SetActive(false);
            SixQukuaiZhuanYong[8].SetActive(false);
            SixQukuaiZhuanYong[9].SetActive(false);
            QukuaiImage.SetActive(true);
            QukuaiImage.GetComponent<Image>().sprite = Qukuais[Ga / 10];
            return;
        }
        QukuaiImage.SetActive(true);
        QukuaiImage.GetComponent<Image>().sprite = Qukuais[Ga];
    }

    public void HuxingButtonsCancle(GameObject Ga)
    {
        j = 1;
        BieShuHuxing[0].SetActive(false);
        BieShuHuxing[1].SetActive(false);
        Ga.SetActive(false);
    }

    public void BieShuNextPage()
    {
        switch (_GameData.gameState)
        {
            case GameData.GameState.Two:
                j++;
                if (j % 5 == 0) j = j - 4;
                BieShuHuxing[0].GetComponent<Image>().sprite = Huxings[temp * 5 + j];
                break;
            case GameData.GameState.Three:
                j++;
                if (j % 4 == 0) j = j - 3;
                BieShuHuxing[0].GetComponent<Image>().sprite = Huxings[temp * 4 + j];
                break;
            case GameData.GameState.Six:
                j++;
                if (temp >= 49)
                {
                    if (j % 5 == 0)
                        j = j - 4;
                }
                else if (j % 4 == 0) j = j - 3;
                BieShuHuxing[0].GetComponent<Image>().sprite = Huxings[temp + j];
                break;
        }
    }

    public void SixQukuaiChange(int i)
    {
        _GameData.QukuaiButtons[5].SetActive(false);
        //_GameData.QukuaiButtons[6].SetActive(false);
        _GameData.QukuaiButtons[i + 5].SetActive(true);
        NewUI[0].SetActive(false);
        NewUI[1].SetActive(false);
        NewUI[i].SetActive(true);
        if (i == 1)
        {
            QukuaiImage.SetActive(true);
            QukuaiImage.GetComponent<Image>().sprite = _GameData.sixSp5[i + 11];
        }
        if (i == 0)
        {
            QukuaiImage.SetActive(false);
        }
        BackGround.sprite = _GameData.sixSp5[i + 15];
    }
}

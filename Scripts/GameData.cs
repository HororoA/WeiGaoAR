using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameData : MonoBehaviour
{

    GameState _gameState;

    public static int ButtonStep = 0;

    public Image Left1;
    public Image Right1;
    public Image Logo;

    public Sprite[] selectSp;

    ImagesMove _ImagesMove;
    ButtonClick _ButtonClick;
    animectr _animectr;

    public Sprite[] oneSp;
    public Sprite[] oneSp1;
    public Sprite[] oneSp2;
    public Sprite[] oneSp3;
    public Sprite[] oneSp4;
    public Sprite[] oneSp5;
    public Sprite[] oneButtonSp;
    public Sprite[] oneMovesSp;

    public Sprite[] twoSp;
    public Sprite[] twoSp1;
    public Sprite[] twoSp2;
    public Sprite[] twoSp3;
    public Sprite[] twoSp4;
    public Sprite[] twoSp5;
    public Sprite[] twoButtonSp;
    public Sprite[] twoMovesSp;

    public Sprite[] threeSp;
    public Sprite[] threeSp1;
    public Sprite[] threeSp2;
    public Sprite[] threeSp3;
    public Sprite[] threeSp4;
    public Sprite[] threeSp5;
    public Sprite[] threeButtonSp;
    public Sprite[] threeMovesSp;

    public Sprite[] fourSp;
    public Sprite[] fourSp1;
    public Sprite[] fourSp2;
    public Sprite[] fourSp3;
    public Sprite[] fourSp4;
    public Sprite[] fourSp5;
    public Sprite[] fourButtonSp;
    public Sprite[] fourMovesSp;

    public Sprite[] fiveSp;
    public Sprite[] fiveSp1;
    public Sprite[] fiveSp2;
    public Sprite[] fiveSp3;
    public Sprite[] fiveSp4;
    public Sprite[] fiveSp5;
    public Sprite[] fiveButtonSp;
    public Sprite[] fiveMovesSp;


    public Sprite[] sixSp;
    public Sprite[] sixSp1;
    public Sprite[] sixSp2_1;
    public Sprite[] sixSp2_2;
    public Sprite[] sixSp2_3;
    public Sprite[] sixSp3_1;
    public Sprite[] sixSp3_2;
    public Sprite[] sixSp3_3;
    public Sprite[] sixSp4;
    public Sprite[] sixSp5;
    public Sprite[] sixButtonSp;
    public Sprite[] sixMovesSp;

    public Camera cam;
    public GameObject OneHalfCamera;
    BookData _bookData;
    public Camera ARCameraGam;
    public GameObject SaoMiao;

    public GameObject[] SixButton1, SixButton2;

    public GameObject[] HuQu;

    public Vector3[] One_One_V;
    public Vector3[] One_Two_V;
    public Vector3[] One_Three_V;
    public Vector3[] One_Four_V;
    public Vector3[] One_Five_V;
    public Vector3[] One_Six_V;
    public Vector3[] One_Seven_V;
    public Vector3[] One_Eight_V;

    public Vector3[] Three_One_V;
    public Vector3[] Three_Two_V;
    public Vector3[] Three_Three_V;
    public Vector3[] Three_Four_V;
    public Vector3[] Three_Five_V;
    public Vector3[] Three_Six_V;
    public Vector3[] Three_Seven_V;
    public Vector3[] Three_Eight_V;

    public Vector3[] Four_One_V;
    public Vector3[] Four_Two_V;
    public Vector3[] Four_Three_V;
    public Vector3[] Four_Four_V;
    public Vector3[] Four_Five_V;
    public Vector3[] Four_Six_V;
    public Vector3[] Four_Seven_V;
    public Vector3[] Four_Eight_V;

    public Sprite[] One_Huxing;
    public Sprite[] Two_Huxing;
    public Sprite[] Three_Huxing;
    public Sprite[] Four_Huxing;
    public Sprite[] Five_Huxing;
    public Sprite[] Six_Huxing;

    public GameObject[] HuxingButtons;
    public GameObject[] QukuaiButtons;
    public Sprite[] NextButtons;
    public Sprite[] ModelButtons;
    public GameObject NextStepButton;

    void Awake()
    {
        _bookData = GameObject.Find("Scripts").GetComponent<BookData>();
        _ImagesMove = GameObject.Find("Scripts").GetComponent<ImagesMove>();
        _ButtonClick = GameObject.Find("Scripts").GetComponent<ButtonClick>();

        gameState = GameState.none;
    }
    public void SaoMaoStart()
    {
        SaoMiao.SetActive(true);
    }

    public void CloseAR()
    {
        ARCameraGam.enabled = false;
    }
    public enum GameState
    {
        none,
        One,
        Two,
        Three,
        Four,
        Five,
        Six,
    }

    public GameState gameState
    {
        set
        {
            if (_gameState != value)
            {
                _gameState = value;
                OnGameStateChange(_gameState);
            }
        }
        get
        {
            return _gameState;
        }
    }

    void OnGameStateChange(GameState useGameState)
    {
        switch (useGameState)
        {
            case GameState.none:
                Debug.Log("空");
                _bookData.bookState = BookData.BookState.none;
                for (int i = 0; i < 7; i++) {
                    QukuaiButtons[i].SetActive(false);
                }
                for (int i = 0; i < SixButton1.Length; i++)
                {
                    try
                    {
                        SixButton1[i].SetActive(false);
                        SixButton2[i].SetActive(false);
                    }
                    catch (System.Exception e)
                    {
                        Debug.Log(e);
                    }
                }
                try
                {
                    ARCameraGam.enabled = true;
                    Camera ARCameraGam2 = GameObject.Find("camera background").GetComponent<Camera>();
                    ARCameraGam2.enabled = true;
                }
                catch (System.Exception e)
                {
                    Debug.Log(e);
                }
                cam.enabled = false;
                break;
            case GameState.One:
                SaoMiao.SetActive(false);
                Debug.Log("第一个点");
                OneStart();
                cam.enabled = true;
                break;
            case GameState.Two:
                SaoMiao.SetActive(false);
                Debug.Log("第二个点");
                TwoStart();
                cam.enabled = true;
                break;
            case GameState.Three:
                SaoMiao.SetActive(false);
                Debug.Log("第三个点");
                ThreeStart();
                cam.enabled = true;
                break;
            case GameState.Four:
                SaoMiao.SetActive(false);
                Debug.Log("第四个点");
                FourStart();
                cam.enabled = true;
                break;
            case GameState.Five:
                SaoMiao.SetActive(false);
                Debug.Log("第五个点");
                FiveStart();
                cam.enabled = true;
                break;
            case GameState.Six:
                SaoMiao.SetActive(false);
                Debug.Log("第六个点");
                SixStart();
                cam.enabled = true;
                break;
        }
    }

    void OneStart()
    {
        //ARCameraGam = GameObject.Find("camera background").GetComponent<Camera>();
        //ARCameraGam.enabled = false;
        _bookData.vec3 = new Vector3(-113.6f, 121.6f, 0);
        _ImagesMove.sp = oneMovesSp;
        selectSp = oneSp;
        Right1.sprite = selectSp[0];
        Left1.sprite = selectSp[1];
        Logo.sprite = selectSp[2];
        _bookData.buttonSp = oneButtonSp;
        _bookData.allSp = oneSp1;
        _bookData.sp1 = oneSp2;
        _bookData.sp2 = oneSp3;
        _bookData.sp3 = oneSp4;
        qukuaisloading("One", 6, oneSp5, "quwei");
        qukuaisloading("One", 6, One_Huxing, "huxing");
        _ButtonClick.Qukuais = oneSp5;
        _ButtonClick.Huxings = One_Huxing;
        _bookData.bookState = BookData.BookState.pageOneHalf;
        ButtonStep = 1;
        NextStepButton.GetComponent<Image>().sprite = ModelButtons[0];
        //_animectr.spriteOn("One");
        OneHalfSetOn("ONE");
    }

    void TwoStart()
    {
        ARCameraGam.enabled = false;
        Camera ARCameraGam2 = GameObject.Find("camera background").GetComponent<Camera>();
        ARCameraGam2.enabled = false;
        _bookData.vec3 = new Vector3(-92.2f, 125.2f, 0);
        _ImagesMove.sp = twoMovesSp;
        selectSp = twoSp;
        Right1.sprite = selectSp[0];
        Left1.sprite = selectSp[1];
        Logo.sprite = selectSp[2];
        _bookData.buttonSp = twoButtonSp;
        _bookData.allSp = twoSp1;
        _bookData.sp1 = twoSp2;
        _bookData.sp2 = twoSp3;
        _bookData.sp3 = twoSp4;
        qukuaisloading("Two", 8, twoSp5, "quwei");
        qukuaisloading("Two", 15, Two_Huxing, "huxing");
        _ButtonClick.Qukuais = twoSp5;
        _ButtonClick.Huxings = Two_Huxing;
        ButtonStep = 2;
        _bookData.bookState = BookData.BookState.pageOne;
    }

    void ThreeStart()
    {
        //ARCameraGam = GameObject.Find("camera background").GetComponent<Camera>();
        //ARCameraGam.enabled = false;
        _bookData.vec3 = new Vector3(-148.9f, 69.2f, 0);
        _ImagesMove.sp = threeMovesSp;
        selectSp = threeSp;
        Right1.sprite = selectSp[0];
        Left1.sprite = selectSp[1];
        Logo.sprite = selectSp[2];
        _bookData.buttonSp = threeButtonSp;
        _bookData.allSp = threeSp1;
        _bookData.sp1 = threeSp2;
        _bookData.sp2 = threeSp3;
        _bookData.sp3 = threeSp4;
        qukuaisloading("Three", 6, threeSp5, "quwei");
        qukuaisloading("Three", 20, Three_Huxing, "huxing");
        _ButtonClick.Qukuais = threeSp5;
        _ButtonClick.Huxings = Three_Huxing;
        ButtonStep = 3;
        NextStepButton.GetComponent<Image>().sprite = ModelButtons[1];
        _bookData.bookState = BookData.BookState.pageOneHalf;
        OneHalfSetOn("THREE");
    }

    void FourStart()
    {
        //ARCameraGam = GameObject.Find("camera background").GetComponent<Camera>();
        //ARCameraGam.enabled = false;
        _bookData.vec3 = new Vector3(-59.3f, 72.1f, 0);
        _ImagesMove.sp = fourMovesSp;
        selectSp = fourSp;
        Right1.sprite = selectSp[0];
        Left1.sprite = selectSp[1];
        Logo.sprite = selectSp[2];
        _bookData.buttonSp = fourButtonSp;
        _bookData.allSp = fourSp1;
        _bookData.sp1 = fourSp2;
        _bookData.sp2 = fourSp3;
        _bookData.sp3 = fourSp4;
        qukuaisloading("Four", 5, fourSp5, "quwei");
        qukuaisloading("Four", 9, Four_Huxing, "huxing");
        _ButtonClick.Qukuais = fourSp5;
        _ButtonClick.Huxings = Four_Huxing;
        ButtonStep = 4;
        NextStepButton.GetComponent<Image>().sprite = ModelButtons[2];
        _bookData.bookState = BookData.BookState.pageOneHalf;
        OneHalfSetOn("FOUR");
    }

    void FiveStart()
    {
        ARCameraGam.enabled = false;
        Camera ARCameraGam2 = GameObject.Find("camera background").GetComponent<Camera>();
        ARCameraGam2.enabled = false;
        _bookData.vec3 = new Vector3(4.2f, 99.6f, 0);
        _ImagesMove.sp = fiveMovesSp;
        selectSp = fiveSp;
        Right1.sprite = selectSp[0];
        Left1.sprite = selectSp[1];
        Logo.sprite = selectSp[2];
        _bookData.buttonSp = fiveButtonSp;
        _bookData.allSp = fiveSp1;
        _bookData.sp1 = fiveSp2;
        _bookData.sp2 = fiveSp3;
        _bookData.sp3 = fiveSp4;
        qukuaisloading("Five", 9, fiveSp5, "quwei");
        qukuaisloading("Five", 6, Five_Huxing, "huxing");
        _ButtonClick.Qukuais = fiveSp5;
        _ButtonClick.Huxings = Five_Huxing;
        ButtonStep = 5;
        _bookData.bookState = BookData.BookState.pageOne;
        //_animectr.spriteOn("FIVE");
    }

    void SixStart()
    {
        ARCameraGam.enabled = false;
        Camera ARCameraGam2 = GameObject.Find("camera background").GetComponent<Camera>();
        ARCameraGam2.enabled = false;
        _bookData.vec3 = new Vector3(-25.2f, 129f, 0);
        _ImagesMove.sp = sixMovesSp;
        selectSp = sixSp;
        Right1.sprite = selectSp[0];
        Left1.sprite = selectSp[1];
        Logo.sprite = selectSp[2];
        _bookData.buttonSp = sixButtonSp;
        _bookData.allSp = sixSp1;
        _bookData.sp1 = sixSp2_1;
        _bookData.sp2 = sixSp3_1;
        _bookData.sp3 = sixSp4;
        qukuaisloading("Six", 19, sixSp5, "quwei");
        qukuaisloading("Six", 60, Six_Huxing, "huxing");
        _ButtonClick.Qukuais = sixSp5;
        _ButtonClick.Huxings = Six_Huxing;
        ButtonStep = 6;
        _bookData.bookState = BookData.BookState.pageOne;
    }

    private void OneHalfSetOn(string num)
    {
        OneHalfCamera.SetActive(true);
        _animectr = GameObject.Find("anime").GetComponent<animectr>();
        _animectr.spriteOn(num);
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) gameState = GameState.One;
        if (Input.GetKeyDown(KeyCode.B)) gameState = GameState.Two;
        if (Input.GetKeyDown(KeyCode.C)) gameState = GameState.Three;
        if (Input.GetKeyDown(KeyCode.D)) gameState = GameState.Four;
        if (Input.GetKeyDown(KeyCode.E)) gameState = GameState.Five;
        if (Input.GetKeyDown(KeyCode.F)) gameState = GameState.Six;
    }

    void qukuaisloading(string num, int length, Sprite[] S, string quhu)
    {
        for (int i = 0; i < length; i++)
        {
            S[i] = Resources.Load(num + "/" + quhu + "/" + (i + 1), typeof(Sprite)) as Sprite;
        }
    }
}
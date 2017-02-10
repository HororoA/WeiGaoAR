using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BookData : MonoBehaviour {

    BookState _bookState;
    GameData _GameData;
    public Image star;
    ImageMove _ImageMove;
    ImagesMove _ImagesMove;
    public Sprite[] allSp;
    public GameObject main;
    public GameObject[] AllButton;
    public GameObject In2;
    public GameObject threeButton;
    public Image LeftButtonBG;
    public Image RightButtonBG;

    public Sprite[] sp1;
    public Sprite[] sp2;
    public Sprite[] sp3;
    public Sprite[] buttonSp;
    static public bool isPlaying;

    public Vector3 vec3;
    public Image[] sixButton1,sixButton2;
    ButtonClick _ButtonClick;
    public Sprite[] sixSp;

    public GameObject OneHalf;
    public GameObject HuxingButtons;
    public Sprite[] HuxingS;

    public GameObject quekuai;

    void Awake()
    {
        _ImageMove = GameObject.Find("Scripts").GetComponent<ImageMove>();
        _ImagesMove = GameObject.Find("Scripts").GetComponent<ImagesMove>();
        _GameData = GameObject.Find("Scripts").GetComponent<GameData>();
        _ButtonClick = GameObject.Find("Scripts").GetComponent<ButtonClick>();
        bookState = BookState.none;
    }

    public enum BookState
    {
        none,
        pageOne,
        pageOneHalf,
        pageTwo,
        pageThree,
        pageFour,
    }

    public BookState bookState 
    {
        set 
        {
            if (_bookState != value) 
            {
                _bookState = value;
                OnBookStateChange(_bookState);
            }
        }
        get 
        {
            return _bookState;
        }
    }

    void OnBookStateChange(BookState useBookState)
    {
        switch (useBookState)
        {
            case BookState.none:
                main.SetActive(true);
                _ImageMove.ResetPos();
                isPlaying = false;
                break;
            case BookState.pageOne:
                Debug.Log("第一页");
                if (isPlaying)
                {
                    StartCoroutine(pageone1());
                }
                else
                {
                    StartCoroutine(pageone());
                }
                break;
            case BookState.pageOneHalf:
                Debug.Log("第一页半");
                StartCoroutine(pageonehalf());
                break;
            case BookState.pageTwo:
                Debug.Log("第二页");
                pagetwo();
                break;
            case BookState.pageThree:
                Debug.Log("第三页");
                StartCoroutine(pagethree());
                break;
            case BookState.pageFour:
                StartCoroutine(pagefour());
                Debug.Log("第四页");
                break;
        }
    }

    IEnumerator pageonehalf()
    {
        OneHalf.SetActive(true);
        //In2.SetActive(false);
        //LeftButtonBG.sprite = buttonSp[0];
        //star.rectTransform.localPosition = vec3;
        yield return new WaitForSeconds(2f);
        //main.SetActive(false);
        //_ImageMove.PageOneMove(allSp[3]);
        //ShowButton(0, 1);
        isPlaying = true;
    }

    IEnumerator pageone() 
    {
        In2.SetActive(false);
        LeftButtonBG.sprite = buttonSp[0];
        star.rectTransform.localPosition = vec3;
        yield return new WaitForSeconds(2f);
        quekuai.SetActive(false);
        main.SetActive(false);
        _ImageMove.ImageMoveTo("left", allSp[0]);

        ShowButton(0, 1);
        isPlaying = true;

        if (_GameData.gameState == GameData.GameState.Six)
        {
            yield return new WaitForSeconds(2f);
            for (int i = 0; i < sixButton1.Length; i++)
            {
                sixButton1[i].gameObject.SetActive(true);
                sixButton1[i].sprite = sixSp[i];
            }
        }
    }
    //new Vector3(-69.75f, 45.9f, 0)

    IEnumerator pageone1()
    {
        In2.SetActive(false);
        LeftButtonBG.sprite = buttonSp[0];
        star.rectTransform.localPosition = vec3;
        yield return 0;
        main.SetActive(false);
        QuHuButtons(false, false);
        quekuai.SetActive(false);
        _ImageMove.ImageMoveTo("left", allSp[0]);
        ShowButton(0, 1);

        if (_GameData.gameState == GameData.GameState.Six)
        {
            yield return new WaitForSeconds(2f);
            for (int i = 0; i < sixButton1.Length; i++)
            {
                try
                {
                    sixButton1[i].gameObject.SetActive(true);
                    sixButton2[i].gameObject.SetActive(false);
                    sixButton1[i].sprite = sixSp[i];
                }
                catch (System.Exception)
                {

                }
            }
        }
    }

    void start1() {
        quekuai.SetActive(true);
        QuHuButtons(false, true);
    }

    void start2() { 
        HuxingButtons.SetActive(true);
        if (_GameData.gameState == GameData.GameState.Three)
        {
            _ButtonClick.BieShuHuxing[0].SetActive(true);
            _ButtonClick.BieShuHuxing[1].SetActive(true);
        }
        QuHuButtons(true, true);
    }

    void pagetwo()
    {
        In2.SetActive(false);
        RightButtonBG.sprite = buttonSp[1];
        _ImageMove.ImageMoveTo("right", allSp[1]);
        Invoke("start1", 2.3f);
        QuHuButtons(true, false);
        HuxingButtons.SetActive(false);
        ShowButton(2, 3);
        if (_GameData.gameState == GameData.GameState.Six)
        {
            for (int i = 0; i < sixButton1.Length; i++)
            {
                try
                {
                    sixButton1[i].gameObject.SetActive(false);
                    sixButton2[i].gameObject.SetActive(false);
                }
                catch (System.Exception)
                {

                }
            }
        }
    }

    IEnumerator pagethree()
    {
        _ImageMove.ImageMoveTo("left", allSp[3]);
        ShowButton(4, 5);
        QuHuButtons(false, false);
        quekuai.SetActive(false);
        yield return new WaitForSeconds(2f);
        LeftButtonBG.sprite = buttonSp[2];
        In2.SetActive(true);
        threeButton.SetActive(true);
        Invoke("start2", 1f);
        
        //_ImagesMove.allSp = sp1;
        _ImagesMove.allSp = sp3;

        _ImagesMove.Reset();
        if (_GameData.gameState == GameData.GameState.Six)
        {
            //_ButtonClick.ResetButtonImage();
            //for (int i = 0; i < sixButton1.Length; i++)
            //{
            //    try
            //    {
            //        sixButton1[i].gameObject.SetActive(true);
            //        sixButton2[i].gameObject.SetActive(false);
            //    }
            //    catch (System.Exception)
            //    {
            //    }
            //}
        }
    }

    IEnumerator pagefour()
    {
        QuHuButtons(true, false);
        HuxingButtons.SetActive(false);
        _ImageMove.ImageMoveTo("right", null);
        ShowButton(6);
        if (_GameData.gameState == GameData.GameState.Six)
        {
            _ButtonClick.ResetButtonImage1();
            for (int i = 0; i < sixButton1.Length; i++)
            {
                try
                {
                    sixButton1[i].gameObject.SetActive(false);
                }
                catch (System.Exception)
                {

                }
            }
        }
        yield return new WaitForSeconds(2f);
        RightButtonBG.sprite = buttonSp[3];
        In2.SetActive(true);
        threeButton.SetActive(true);
        _ImagesMove.allSp = sp2;
        //_ImagesMove.allSp1 = sp3;
        _ImagesMove.Reset();
        if (_GameData.gameState == GameData.GameState.Six)
        {
            _ButtonClick.ResetButtonImage1();
            for (int i = 0; i < sixButton1.Length; i++)
            {
                try
                {
                    sixButton2[i].gameObject.SetActive(true);
                }
                catch (System.Exception)
                {

                }
            }
        }
    }

	// Use this for initialization
	void Start () {
        //bookState = BookState.pageOne;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void ShowButton(int num) 
    {
        for (int i = 0; i < AllButton.Length; i++)
        {
            AllButton[i].SetActive(false);
        }
        AllButton[num].SetActive(true);
    }
    void ShowButton(int num1,int num2)
    {
        for (int i = 0; i < AllButton.Length; i++)
        {
            AllButton[i].SetActive(false);
        }
        AllButton[num1].SetActive(true);
        AllButton[num2].SetActive(true);
    }


    /// <summary>
    /// QuHuButtons,A代表户型和区块，B代表开关
    /// </summary>
    /// <param name="A">真为户型，假为区块</param>
    /// <param name="B">真开假关</param>
    /// <returns></returns>
    private void QuHuButtons(bool A, bool B)
    {
        switch (GameData.ButtonStep)
        {
            case 1:
                if (A) _GameData.HuxingButtons[0].SetActive(B);
                else _GameData.QukuaiButtons[0].SetActive(B);
                break;
            case 2:
                if (A) _GameData.HuxingButtons[1].SetActive(B);
                else _GameData.QukuaiButtons[1].SetActive(B);
                break;
            case 3:
                if (A) _GameData.HuxingButtons[2].SetActive(B);
                else _GameData.QukuaiButtons[2].SetActive(B);
                break;
            case 4:
                if (A) _GameData.HuxingButtons[3].SetActive(B);
                else _GameData.QukuaiButtons[3].SetActive(B);
                break;
            case 5:
                if (A) _GameData.HuxingButtons[4].SetActive(B);
                else _GameData.QukuaiButtons[4].SetActive(B);
                break;
            case 6:
                if (A) _GameData.HuxingButtons[5].SetActive(B);
                else _GameData.QukuaiButtons[5].SetActive(B);
                if (!B)
                {
                    _GameData.HuxingButtons[6].SetActive(B);
                    _GameData.HuxingButtons[7].SetActive(B);
                    _GameData.QukuaiButtons[6].SetActive(B);
                }
                break;
        }
    }
}

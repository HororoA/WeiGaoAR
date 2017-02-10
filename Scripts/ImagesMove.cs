using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ImagesMove : MonoBehaviour {

    public Sprite[] allSp;
    public Image mid;
    public Image lef;
    public Image rig;
    int nowPage = 0;
    public static bool canMove = true;

    public Image im1;
    public Image im2;
    public BookData _BookData;
    public GameData _GameData;

    public Sprite[] sp;

    public RectTransform[] HuxingButton1;
    public RectTransform[] HuxingButton3;
    public RectTransform[] HuxingButton4;

    void Awake()
    {
        _GameData = GameObject.Find("Scripts").GetComponent<GameData>();
    }

    public void Reset()
    {
        nowPage = 0;
        im1.sprite = sp[1];
        canMove = true;
        mid.sprite = allSp[nowPage];
        rig.sprite = allSp[nowPage + 1];
        lef.sprite = allSp[allSp.Length - 1];
        switch (_BookData.bookState)
        {
            case BookData.BookState.pageThree:
                switch (_GameData.gameState)
                {
                    case GameData.GameState.One:
                        im1.gameObject.SetActive(true);
                        break;
                    case GameData.GameState.Two:
                        //im1.gameObject.SetActive(true);
                        break;
                    case GameData.GameState.Three:
                        im1.gameObject.SetActive(true);
                        break;
                    case GameData.GameState.Four:
                        im1.gameObject.SetActive(true);
                        break;
                    case GameData.GameState.Five:
                        //im1.gameObject.SetActive(true);
                        break;
                    case GameData.GameState.Six:
                        //im1.gameObject.SetActive(true);
                        break;
                }
                im2.gameObject.SetActive(false);
                break;
            case BookData.BookState.pageFour:
                im1.gameObject.SetActive(false);
                im2.gameObject.SetActive(true);
                break;
        }
    }

    public void MoveLeft() 
    {
        if (canMove)
        {
            //if (_GameData.gameState != GameData.GameState.Six && _BookData.bookState != BookData.BookState.pageThree)
            {
                canMove = false;
                if (nowPage < allSp.Length - 1) nowPage += 1;
                //else if (ImageMove.step != 4) nowPage = 0;
                else nowPage = 0;
                Vector333(nowPage);
                //Debug.Log(nowPage);
                Debug.Log("step:" + ImageMove.step.ToString());
                StartCoroutine(moveLeft());
            }
        }
    }
    public void MoveRight()
    {
        if (canMove)
        {
            //if (_GameData.gameState != GameData.GameState.Six && _BookData.bookState != BookData.BookState.pageThree)
            {
                canMove = false;
                if (nowPage > 0) nowPage -= 1;
                //else if (ImageMove.step != 4) nowPage = allSp.Length - 1;
                else nowPage = allSp.Length - 1;
                Vector333(nowPage);
                Debug.Log(nowPage);
                StartCoroutine(moveRight());
            }
        }
    }

    IEnumerator moveLeft()
    {
        InvokeRepeating("midMoveLeft", 0.02f, 0.02f);
        if (ImageMove.step == 4) yield return new WaitForSeconds(2f);
        else yield return null;
        CancelInvoke("midMoveLeft");
        MoveOver();
    }

    IEnumerator moveRight()
    {
        InvokeRepeating("midMoveRight", 0.02f, 0.02f);
        if (ImageMove.step == 4) yield return new WaitForSeconds(2f);
        else yield return null;
        CancelInvoke("midMoveRight");
        MoveOver();
    }

    void MoveOver()
    {
        mid.sprite = allSp[nowPage];
        mid.rectTransform.localPosition = new Vector3(0,0,0);
        if (nowPage > 0) 
        {
            lef.sprite = allSp[nowPage - 1];

        }
        else
        {
            lef.sprite = allSp[allSp.Length - 1];

        }
        lef.rectTransform.localPosition = new Vector3(-581, 0, 0);
        if (nowPage < allSp.Length - 1)
        {
            rig.sprite = allSp[nowPage + 1];

        }
        else
        {
            rig.sprite = allSp[0];

        }
        rig.rectTransform.localPosition = new Vector3(581, 0, 0);
        canMove = true;
    }
    void midMoveLeft()
    {
        move(mid, -581);
        move(rig, 0);
    }
    void midMoveRight()
    {
        move(mid, 581);
        move(lef, 0);
    }

    void move(Image im,int pos)
    {
        if (nowPage > 0)
        {
            im1.sprite = sp[1];
        }
        else
        {
            im1.sprite = sp[1];
        }
        if (nowPage < allSp.Length - 1)
        {
            im1.sprite = sp[1];
        }
        else
        {
            im1.sprite = sp[1];
        }
        Vector3 vec = im.rectTransform.localPosition;
        im.rectTransform.localPosition = Vector3.Lerp(vec, new Vector3(pos, 0, 0), Time.deltaTime * 4);
    }


    Vector3 startPos;
    Vector3 endPos;

    public void ButtonDown()
    {
        startPos = Input.mousePosition;
    }

    public void ButtonUp()
    {
        endPos = Input.mousePosition;
        if (startPos.x - endPos.x > 20)
        {
            MoveLeft();
        }
        if (startPos.x - endPos.x < -20)
        {
            MoveRight();
        }
    }

    public void Vector333(int nowPage)
    {
        int n = 0;
        switch (_GameData.gameState)
        {
            case GameData.GameState.One:
                n = 5;
                for (int i = 0; i <= n; i++)
                {
                    switch (nowPage)
                    {
                        case 0:
                            HuxingButton1[i].localPosition = new Vector3(_GameData.One_One_V[i].x, _GameData.One_One_V[i].y, _GameData.One_One_V[i].z);
                            break;
                        case 1:
                            HuxingButton1[i].localPosition = new Vector3(_GameData.One_Two_V[i].x, _GameData.One_Two_V[i].y, _GameData.One_Two_V[i].z);
                            break;
                        case 2:
                            HuxingButton1[i].localPosition = new Vector3(_GameData.One_Three_V[i].x, _GameData.One_Three_V[i].y, _GameData.One_Three_V[i].z);
                            break;
                        case 3:
                            HuxingButton1[i].localPosition = new Vector3(_GameData.One_Four_V[i].x, _GameData.One_Four_V[i].y, _GameData.One_Four_V[i].z);
                            break;
                        case 4:
                            HuxingButton1[i].localPosition = new Vector3(_GameData.One_Five_V[i].x, _GameData.One_Five_V[i].y, _GameData.One_Five_V[i].z);
                            break;
                        case 5:
                            HuxingButton1[i].localPosition = new Vector3(_GameData.One_Six_V[i].x, _GameData.One_Six_V[i].y, _GameData.One_Six_V[i].z);
                            break;
                        case 6:
                            HuxingButton1[i].localPosition = new Vector3(_GameData.One_Seven_V[i].x, _GameData.One_Seven_V[i].y, _GameData.One_Seven_V[i].z);
                            break;
                        case 7:
                            HuxingButton1[i].localPosition = new Vector3(_GameData.One_Eight_V[i].x, _GameData.One_Eight_V[i].y, _GameData.One_Eight_V[i].z);
                            break;
                    }
                }
                break;
            case GameData.GameState.Three:
                n = 4;
                for (int i = 0; i <= n; i++)
                {
                    Debug.Log(nowPage);
                    switch (nowPage)
                    {
                        case 0:
                            HuxingButton3[i].localPosition = new Vector3(_GameData.Three_One_V[i].x, _GameData.Three_One_V[i].y, _GameData.Three_One_V[i].z);
                            break;
                        case 1:
                            HuxingButton3[i].localPosition = new Vector3(_GameData.Three_Two_V[i].x, _GameData.Three_Two_V[i].y, _GameData.Three_Two_V[i].z);
                            break;
                        case 2:
                            HuxingButton3[i].localPosition = new Vector3(_GameData.Three_Three_V[i].x, _GameData.Three_Three_V[i].y, _GameData.Three_Three_V[i].z);
                            break;
                        case 3:
                            HuxingButton3[i].localPosition = new Vector3(_GameData.Three_Four_V[i].x, _GameData.Three_Four_V[i].y, _GameData.Three_Four_V[i].z);
                            break;
                        case 4:
                            HuxingButton3[i].localPosition = new Vector3(_GameData.Three_Five_V[i].x, _GameData.Three_Five_V[i].y, _GameData.Three_Five_V[i].z);
                            break;
                        case 5:
                            HuxingButton3[i].localPosition = new Vector3(_GameData.Three_Six_V[i].x, _GameData.Three_Six_V[i].y, _GameData.Three_Six_V[i].z);
                            break;
                        case 6:
                            HuxingButton3[i].localPosition = new Vector3(_GameData.Three_Seven_V[i].x, _GameData.Three_Seven_V[i].y, _GameData.Three_Seven_V[i].z);
                            break;
                        case 7:
                            HuxingButton3[i].localPosition = new Vector3(_GameData.Three_Eight_V[i].x, _GameData.Three_Eight_V[i].y, _GameData.Three_Eight_V[i].z);
                            break;
                    }
                }
                break;
            case GameData.GameState.Four:
                n = 8;
                for (int i = 0; i <= n; i++)
                {
                    Debug.Log(nowPage);
                    switch (nowPage)
                    {
                        case 0:
                            HuxingButton4[i].localPosition = new Vector3(_GameData.Four_One_V[i].x, _GameData.Four_One_V[i].y, _GameData.Four_One_V[i].z);
                            break;
                        case 1:
                            HuxingButton4[i].localPosition = new Vector3(_GameData.Four_Two_V[i].x, _GameData.Four_Two_V[i].y, _GameData.Four_Two_V[i].z);
                            break;
                        case 2:
                            HuxingButton4[i].localPosition = new Vector3(_GameData.Four_Three_V[i].x, _GameData.Four_Three_V[i].y, _GameData.Four_Three_V[i].z);
                            break;
                        case 3:
                            HuxingButton4[i].localPosition = new Vector3(_GameData.Four_Four_V[i].x, _GameData.Four_Four_V[i].y, _GameData.Four_Four_V[i].z);
                            break;
                        case 4:
                            HuxingButton4[i].localPosition = new Vector3(_GameData.Four_Five_V[i].x, _GameData.Four_Five_V[i].y, _GameData.Four_Five_V[i].z);
                            break;
                        case 5:
                            HuxingButton4[i].localPosition = new Vector3(_GameData.Four_Six_V[i].x, _GameData.Four_Six_V[i].y, _GameData.Four_Six_V[i].z);
                            break;
                        case 6:
                            HuxingButton4[i].localPosition = new Vector3(_GameData.Four_Seven_V[i].x, _GameData.Four_Seven_V[i].y, _GameData.Four_Seven_V[i].z);
                            break;
                        case 7:
                            HuxingButton4[i].localPosition = new Vector3(_GameData.Four_Eight_V[i].x, _GameData.Four_Eight_V[i].y, _GameData.Four_Eight_V[i].z);
                            break;
                    }
                }
                break;
            case GameData.GameState.Six:
                _GameData.HuxingButtons[5].SetActive(false);
                _GameData.HuxingButtons[6].SetActive(false);
                _GameData.HuxingButtons[7].SetActive(false);
                _GameData.HuxingButtons[5 + nowPage].SetActive(true);
                break;
        }
    }
}

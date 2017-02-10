using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class animectr : MonoBehaviour {

    public Image I;
    public Sprite[] sprites;
    public Slider S;
    public Image[] IM;
    public Image Hand;
    bool isplay = false;
    public bool isstart = false;

    int A;     //位移距离
    int B = 0; //最终取值
    int C;     //鼠标抬起记录最终取值，并作为下次的起点
    int D;     //鼠标下摁坐标记录

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (isplay)
        {
            A = int.Parse(Input.mousePosition.x.ToString()) - D;
            int num = ((C + (A / 5)) % 50);
            if (num >= 0) B = 50 - num;
            else B = Mathf.Abs(num);
            I.sprite = sprites[B - 1];
        }

        if (isstart) {
            S.value = S.value - 0.005f;
            if (S.value == 0)
            {
                Invoke("Onesecond", 2f);
                isstart = false;
            }
        }
        IM[0].color = new Color(255, 255, 255, S.value);
        //IM[1].color = new Color(255, 255, 255, 1 - S.value);
	}

    void Onesecond() {
        S.value = 1;
        isstart = true;
    }

    public void cd()
    {
        isplay = true;
        D = int.Parse(Input.mousePosition.x.ToString());
    }

    public void cu()
    {
        isplay = false;
        C = Mathf.Abs(50 - B);
    }

    public void spriteOn(string num)
    {
        Debug.Log("xinliezhen_" + num + "_ALL/c_01_0000");
        int j = 0;
        for (int i = 0; i < 200; i = i + 4)
        {
            if (i < 10) sprites[j] = Resources.Load("xinliezhen_" + num + "_ALL/0000" + i.ToString() + "", typeof(Sprite)) as Sprite;
            if (i > 10 && i < 100) sprites[j] = Resources.Load("xinliezhen_" + num + "_ALL/000" + i.ToString() + "", typeof(Sprite)) as Sprite;
            if (i >= 100) sprites[j] = Resources.Load("xinliezhen_" + num + "_ALL/00" + i.ToString() + "", typeof(Sprite)) as Sprite;
            j++;
        }
        I.sprite = sprites[0];
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Terry : MonoBehaviour
{
    public GameObject MainCamera;
    public GameObject Q1, Q2, Q3, Q4, Q5;
    public GameObject Q1C1, Q2C3, Q3C4, Q4C1, Q5C4;
    public GameObject Q1Char, Q2Char, Q3Char, Q4Char, Q5Char;

    public GameObject Q1Pic, Q2Pic, Q3Pic, Q4Pic, Q5Pic;

    public GameObject pictarget;

    public LayerMask _cull;
    public LayerMask _normal;

    public bool Q1B = false, Q2B = false, Q3B = false, Q4B = false, Q5B = false;

    [SerializeField] protected RuntimeAnimatorController idle;
    [SerializeField] protected RuntimeAnimatorController running;

    protected bool SpawnCharBool;
    protected bool _cam = true;
    protected bool _char = true;
    protected bool _scale = true;
    protected bool blink = false;

    public Image CorrectPic;
    public Image WrongPic;

    public Text Score;
    public Image LikeBar;

    private Animator animator;
    void Start()
    {
        SetQuestion();
    }

    // Update is called once per frame
    void Update()
    {
        if(Q1B == true)
        {
            Debug.Log("1");
            Q1Animation();
        }
        if (Q2B == true)
        {
            Debug.Log("2");
            Q2Animation();
        }
        if (Q3B == true)
        {
            Debug.Log("3");
            Q3Animation();
        }
        if (Q4B == true)
        {
            Debug.Log("4");
            Q4Animation();
        }
        if (Q5B == true)
        {
            Debug.Log("5");
            Q5Animation();
        }
    }

    public void SetQuestion()
    {
        Q1.SetActive(true);
        Q2.SetActive(false);
        Q3.SetActive(false);
        Q4.SetActive(false);
        Q5.SetActive(false);

        Q1Pic.SetActive(true);
        Q2Pic.SetActive(false);
        Q3Pic.SetActive(false);
        Q4Pic.SetActive(false);
        Q5Pic.SetActive(false);

        Q1Char.SetActive(false);
        Q2Char.SetActive(false);
        Q3Char.SetActive(false);
        Q4Char.SetActive(false);
        Q5Char.SetActive(false);

        MainCamera.transform.position = new Vector3(Q1.transform.position.x, 60, Q1.transform.position.z);
        MainCamera.transform.LookAt(Q1.transform.position);
        MainCamera.GetComponent<Camera>().cullingMask = _normal;
    }

    public void ClickOne()
    {
        Q1Char.SetActive(true);

        Q1B = true;
    }

    public void Q1Animation()
    {
        Animator CharAnimator = Q1Char.GetComponent<Animator>();
        
        CharAnimator.runtimeAnimatorController = running;
        Q1Char.transform.position = Vector3.Lerp(Q1Char.transform.position, new Vector3(Q1C1.transform.position.x, 2, Q1C1.transform.position.z), 1f * Time.deltaTime);

        if (Vector3.Distance(Q1Char.transform.position, Q1C1.transform.position) < 1f)
        {
            Debug.Log("Arrive");
            CharAnimator.runtimeAnimatorController = idle;
            Q1Char.transform.rotation = Quaternion.Lerp(Q1Char.transform.rotation, Quaternion.Euler(0,30,0) , 1f * Time.deltaTime);

            float forwardangle = Q1Char.transform.rotation.y - 30;

            if (forwardangle < 0.1f)
            {
                MainCamera.transform.position = Vector3.Lerp(MainCamera.transform.position, Q1C1.transform.position, 1f * Time.deltaTime);
                MainCamera.transform.rotation = Quaternion.Lerp(MainCamera.transform.rotation, Quaternion.Euler(0, 30, 0), 1f * Time.deltaTime);

                Score.text = ("1000");
                LikeBar.fillAmount = 0.2f;

                if(MainCamera.transform.position.x - Q1C1.transform.position.x < 5)
                {
                    MainCamera.GetComponent<Camera>().cullingMask = _cull;
                    Q1Char.SetActive(false);
                }
                _scale = false;
            }
        }
        if(_scale == false && MainCamera.transform.position.x - Q1C1.transform.position.x < 1)
        {
            RectTransform PicTran = Q1Pic.GetComponent<RectTransform>();
            Vector3 PicStartSize = new Vector3(PicTran.localScale.x, PicTran.localScale.y, PicTran.localScale.z);
            Vector3 PicEndSize = new Vector3(3, 3, PicTran.localScale.z);

            Vector3 PicStartPos = PicTran.transform.position;
            Vector3 PicEndPos = pictarget.transform.position;

            Color PicStartColor = Q1Pic.GetComponent<Image>().color;
            Color TargetColor = new Color(0, 0, 0, 0);
            
            Q1Pic.transform.position = Vector3.Lerp(PicStartPos, PicEndPos, 1f * Time.deltaTime);
            Debug.Log("Correct Cam move");

            if (Vector3.Distance(Q1Pic.transform.position, PicEndPos) < 1f)
            {
                Debug.Log("Correct, Color changing and Scaling");
                PicTran.localScale = Vector2.Lerp(PicStartSize, PicEndSize, 1f * Time.deltaTime);
            }

            if (Vector3.Distance(PicTran.localScale, PicEndSize) < 1f)
            {
                _scale = true;
                blink = false;
                Q1B = false;
                QuestionTwoSet();
            }
        }
    }

    public void QuestionTwoSet()
    {
        Q1.SetActive(false);
        Q2.SetActive(true);
        Q3.SetActive(false);
        Q4.SetActive(false);
        Q5.SetActive(false);

        Q1Pic.SetActive(false);
        Q2Pic.SetActive(true);
        Q3Pic.SetActive(false);
        Q4Pic.SetActive(false);
        Q5Pic.SetActive(false);

        Q1Char.SetActive(false);
        Q2Char.SetActive(true);
        Q3Char.SetActive(false);
        Q4Char.SetActive(false);
        Q5Char.SetActive(false);

        MainCamera.transform.position = new Vector3(Q2.transform.position.x, 60, Q2.transform.position.z);
        MainCamera.transform.LookAt(Q2.transform.position);
        MainCamera.GetComponent<Camera>().cullingMask = _normal;
    }

    public void ClickTwo()
    {
        Q2Char.SetActive(true);

        Q2B = true;
    }

    public void Q2Animation()
    {
        Animator CharAnimator = Q2Char.GetComponent<Animator>();

        CharAnimator.runtimeAnimatorController = running;
        Q2Char.transform.position = Vector3.Lerp(Q2Char.transform.position, new Vector3(Q2C3.transform.position.x, 2, Q2C3.transform.position.z), 0.5f * Time.deltaTime);

        if (Vector3.Distance(Q2Char.transform.position, Q2C3.transform.position) < 1f)
        {
            Debug.Log("Arrive");
            CharAnimator.runtimeAnimatorController = idle;
            Q2Char.transform.rotation = Quaternion.Lerp(Q2Char.transform.rotation, Quaternion.Euler(0, 270, 0), 0.5f * Time.deltaTime);

            if (Q2Char.transform.rotation.y == 270)
            {
                MainCamera.transform.position = Vector3.Lerp(MainCamera.transform.position, Q2C3.transform.position, 0.5f * Time.deltaTime);
                MainCamera.transform.rotation = Quaternion.Lerp(MainCamera.transform.rotation, Q2Char.transform.rotation, 0.5f * Time.deltaTime);
                if (MainCamera.transform.position.x - Q2C3.transform.position.x < 5)
                {
                    MainCamera.GetComponent<Camera>().cullingMask = _cull;
                    Q2Char.SetActive(false);
                }
                _scale = false;
            }
        }
        if (_scale == false && MainCamera.transform.position.x - Q2C3.transform.position.x < 1)
        {
            RectTransform PicTran = Q2Pic.GetComponent<RectTransform>();
            Vector3 PicStartSize = new Vector3(PicTran.localScale.x, PicTran.localScale.y, PicTran.localScale.z);
            Vector3 PicEndSize = new Vector3(3, 3, PicTran.localScale.z);

            Vector3 PicStartPos = PicTran.transform.position;
            Vector3 PicEndPos = pictarget.GetComponent<RectTransform>().transform.position;

            Color PicStartColor = Q2Pic.GetComponent<Image>().color;
            Color TargetColor = new Color(0, 0, 0, 0);

            Q2Pic.transform.position = Vector3.Lerp(PicStartPos, PicEndPos, 0.5f * Time.deltaTime);
            Debug.Log("Correct Cam move");

            if (Vector3.Distance(Q2Pic.transform.position, PicEndPos) < 1f)
            {
                Debug.Log("Correct, Color changing and Scaling");
                PicTran.localScale = Vector2.Lerp(PicStartSize, PicEndSize, 0.5f * Time.deltaTime);
            }

            if (Vector3.Distance(PicTran.localScale, PicEndSize) < 1f)
            {
                _scale = true;
                blink = false;
                Q2B = false;
                QuestionThreeSet();
            }
        }
    }

    public void QuestionThreeSet()
    {
        Q1.SetActive(false);
        Q2.SetActive(false);
        Q3.SetActive(true);
        Q4.SetActive(false);
        Q5.SetActive(false);

        Q1Pic.SetActive(false);
        Q2Pic.SetActive(false);
        Q3Pic.SetActive(true);
        Q4Pic.SetActive(false);
        Q5Pic.SetActive(false);

        Q1Char.SetActive(false);
        Q2Char.SetActive(false);
        Q3Char.SetActive(true);
        Q4Char.SetActive(false);
        Q5Char.SetActive(false);

        MainCamera.transform.position = new Vector3(Q3.transform.position.x, 60, Q3.transform.position.z);
        MainCamera.transform.LookAt(Q3.transform.position);
        MainCamera.GetComponent<Camera>().cullingMask = _normal;
    }

    public void ClickThree()
    {
        Q3Char.SetActive(true);

        Q3B = true;
    }

    public void Q3Animation()
    {
        Animator CharAnimator = Q3Char.GetComponent<Animator>();

        CharAnimator.runtimeAnimatorController = running;
        Q3Char.transform.position = Vector3.Lerp(Q3Char.transform.position, new Vector3(Q3C4.transform.position.x, 2, Q3C4.transform.position.z), 0.5f * Time.deltaTime);

        if (Vector3.Distance(Q3Char.transform.position, Q3C4.transform.position) < 1f)
        {
            Debug.Log("Arrive");
            CharAnimator.runtimeAnimatorController = idle;
            Q3Char.transform.rotation = Quaternion.Lerp(Q3Char.transform.rotation, Quaternion.Euler(0, 30, 0), 0.5f * Time.deltaTime);

            float forwardangle = Q3Char.transform.rotation.y - 30;

            if (forwardangle < 0.1f)
            {
                MainCamera.transform.position = Vector3.Lerp(MainCamera.transform.position, Q3C4.transform.position, 0.5f * Time.deltaTime);
                MainCamera.transform.rotation = Quaternion.Lerp(MainCamera.transform.rotation, Q3Char.transform.rotation, 0.5f * Time.deltaTime);
                
                if (MainCamera.transform.position.x - Q3C4.transform.position.x < 5)
                {
                    MainCamera.GetComponent<Camera>().cullingMask = _cull;
                    Q3Char.SetActive(false);
                }
                _scale = false;
            }
        }
        if (_scale == false && MainCamera.transform.position.x - Q3C4.transform.position.x < 1)
        {
            RectTransform PicTran = Q3Pic.GetComponent<RectTransform>();
            Vector3 PicStartSize = new Vector3(PicTran.localScale.x, PicTran.localScale.y, PicTran.localScale.z);
            Vector3 PicEndSize = new Vector3(3, 3, PicTran.localScale.z);

            Vector3 PicStartPos = PicTran.transform.position;
            Vector3 PicEndPos = pictarget.GetComponent<RectTransform>().transform.position;

            Color PicStartColor = Q3Pic.GetComponent<Image>().color;
            Color TargetColor = new Color(0, 0, 0, 0);

            Q3Pic.transform.position = Vector3.Lerp(PicStartPos, PicEndPos, 0.5f * Time.deltaTime);
            Debug.Log("Correct Cam move");

            if (Vector3.Distance(Q3Pic.transform.position, PicEndPos) < 1f)
            {
                Debug.Log("Correct, Color changing and Scaling");
                PicTran.localScale = Vector2.Lerp(PicStartSize, PicEndSize, 0.5f * Time.deltaTime);
            }

            if (Vector3.Distance(PicTran.localScale, PicEndSize) < 1f)
            {
                _scale = true;
                blink = false;
                Q3B = false;
                QuestionFourSet();
            }
        }
    }

    public void QuestionFourSet()
    {
        Q1.SetActive(false);
        Q2.SetActive(false);
        Q3.SetActive(false);
        Q4.SetActive(true);
        Q5.SetActive(false);

        Q1Pic.SetActive(false);
        Q2Pic.SetActive(false);
        Q3Pic.SetActive(false);
        Q4Pic.SetActive(true);
        Q5Pic.SetActive(false);

        Q1Char.SetActive(false);
        Q2Char.SetActive(false);
        Q3Char.SetActive(false);
        Q4Char.SetActive(true);
        Q5Char.SetActive(false);

        MainCamera.transform.position = new Vector3(Q4.transform.position.x, 60, Q4.transform.position.z);
        MainCamera.transform.LookAt(Q4.transform.position);
        MainCamera.GetComponent<Camera>().cullingMask = _normal;
    }

    public void ClickFour()
    {
        Q4Char.SetActive(true);

        Q4B = true;
    }

    public void Q4Animation()
    {
        Animator CharAnimator = Q3Char.GetComponent<Animator>();

        CharAnimator.runtimeAnimatorController = running;
        Q4Char.transform.position = Vector3.Lerp(Q4Char.transform.position, new Vector3(Q4C1.transform.position.x, 2, Q4C1.transform.position.z), 0.5f * Time.deltaTime);

        if (Vector3.Distance(Q4Char.transform.position, Q4C1.transform.position) < 1f)
        {
            Debug.Log("Arrive");
            CharAnimator.runtimeAnimatorController = idle;
            Q4Char.transform.rotation = Quaternion.Lerp(Q4Char.transform.rotation, Quaternion.Euler(0, 30, 0), 0.5f * Time.deltaTime);

            float forwardangle = Q4Char.transform.rotation.y - 30;

            if (forwardangle < 0.1f)
            {
                MainCamera.transform.position = Vector3.Lerp(MainCamera.transform.position, Q4C1.transform.position, 0.5f * Time.deltaTime);
                MainCamera.transform.rotation = Quaternion.Lerp(MainCamera.transform.rotation, Q4Char.transform.rotation, 0.5f * Time.deltaTime);
                if (MainCamera.transform.position.x - Q4C1.transform.position.x < 5)
                {
                    MainCamera.GetComponent<Camera>().cullingMask = _cull;
                    Q4Char.SetActive(false);
                }
                _scale = false;
            }
        }
        if (_scale == false && MainCamera.transform.position.x - Q4C1.transform.position.x < 1)
        {
            RectTransform PicTran = Q4Pic.GetComponent<RectTransform>();
            Vector3 PicStartSize = new Vector3(PicTran.localScale.x, PicTran.localScale.y, PicTran.localScale.z);
            Vector3 PicEndSize = new Vector3(3, 3, PicTran.localScale.z);

            Vector3 PicStartPos = PicTran.transform.position;
            Vector3 PicEndPos = pictarget.GetComponent<RectTransform>().transform.position;

            Color PicStartColor = Q4Pic.GetComponent<Image>().color;
            Color TargetColor = new Color(0, 0, 0, 0);

            Q4Pic.transform.position = Vector3.Lerp(PicStartPos, PicEndPos, 0.5f * Time.deltaTime);
            Debug.Log("Correct Cam move");

            if (Vector3.Distance(Q4Pic.transform.position, PicEndPos) < 1f)
            {
                Debug.Log("Correct, Color changing and Scaling");
                PicTran.localScale = Vector2.Lerp(PicStartSize, PicEndSize, 0.5f * Time.deltaTime);
            }

            if (Vector3.Distance(PicTran.localScale, PicEndSize) < 1f)
            {
                _scale = true;
                blink = false;
                Q4B = false;
                QuestionFiveSet();
            }
        }
    }

    public void QuestionFiveSet()
    {
        Q1.SetActive(false);
        Q2.SetActive(false);
        Q3.SetActive(false);
        Q4.SetActive(false);
        Q5.SetActive(true);

        Q1Pic.SetActive(false);
        Q2Pic.SetActive(false);
        Q3Pic.SetActive(false);
        Q4Pic.SetActive(false);
        Q5Pic.SetActive(true);

        Q1Char.SetActive(false);
        Q2Char.SetActive(false);
        Q3Char.SetActive(false);
        Q4Char.SetActive(false);
        Q5Char.SetActive(true);

        MainCamera.transform.position = new Vector3(Q5.transform.position.x, 60, Q5.transform.position.z);
        MainCamera.transform.LookAt(Q5.transform.position);
        MainCamera.GetComponent<Camera>().cullingMask = _normal;
    }

    public void ClickFive()
    {
        Q5Char.SetActive(true);

        Q5B = true;
    }

    public void Q5Animation()
    {
        Animator CharAnimator = Q5Char.GetComponent<Animator>();

        CharAnimator.runtimeAnimatorController = running;
        Q5Char.transform.position = Vector3.Lerp(Q5Char.transform.position, new Vector3(Q5C4.transform.position.x, 2, Q5C4.transform.position.z), 0.5f * Time.deltaTime);

        if (Vector3.Distance(Q5Char.transform.position, Q5C4.transform.position) < 1f)
        {
            Debug.Log("Arrive");
            CharAnimator.runtimeAnimatorController = idle;
            Q5Char.transform.rotation = Quaternion.Lerp(Q5Char.transform.rotation, Quaternion.Euler(0, 30, 0), 0.5f * Time.deltaTime);

            float forwardangle = Q5Char.transform.rotation.y - 30;

            if (forwardangle < 0.1f)
            {
                MainCamera.transform.position = Vector3.Lerp(MainCamera.transform.position, Q5C4.transform.position, 0.5f * Time.deltaTime);
                MainCamera.transform.rotation = Quaternion.Lerp(MainCamera.transform.rotation, Q5Char.transform.rotation, 0.5f * Time.deltaTime);
                if (MainCamera.transform.position.x - Q5C4.transform.position.x < 5)
                {
                    MainCamera.GetComponent<Camera>().cullingMask = _cull;
                    Q5Char.SetActive(false);
                }
                _scale = false;
            }
        }
        if (_scale == false && MainCamera.transform.position.x - Q5C4.transform.position.x < 1)
        {
            RectTransform PicTran = Q5Pic.GetComponent<RectTransform>();
            Vector3 PicStartSize = new Vector3(PicTran.localScale.x, PicTran.localScale.y, PicTran.localScale.z);
            Vector3 PicEndSize = new Vector3(3, 3, PicTran.localScale.z);

            Vector3 PicStartPos = PicTran.transform.position;
            Vector3 PicEndPos = pictarget.GetComponent<RectTransform>().transform.position;

            Color PicStartColor = Q5Pic.GetComponent<Image>().color;
            Color TargetColor = new Color(0, 0, 0, 0);

            Q5Pic.transform.position = Vector3.Lerp(PicStartPos, PicEndPos, 0.5f * Time.deltaTime);
            Debug.Log("Correct Cam move");

            if (Vector3.Distance(Q5Pic.transform.position, PicEndPos) < 1f)
            {
                Debug.Log("Correct, Color changing and Scaling");
                PicTran.localScale = Vector2.Lerp(PicStartSize, PicEndSize, 0.5f * Time.deltaTime);
            }

            if (Vector3.Distance(PicTran.localScale, PicEndSize) < 1f)
            {
                _scale = true;
                blink = false;
                Q5B = false;
                QuestionFinish();
            }
        }
    }

    public void QuestionFinish()
    {
        MainCamera.transform.position = new Vector3(Q5.transform.position.x, 60, Q5.transform.position.z);
        MainCamera.transform.LookAt(Q5.transform.position);

        Q1.SetActive(false);
        Q2.SetActive(false);
        Q3.SetActive(false);
        Q4.SetActive(false);
        Q5.SetActive(false);

        Q1Pic.SetActive(false);
        Q2Pic.SetActive(false);
        Q3Pic.SetActive(false);
        Q4Pic.SetActive(false);
        Q5Pic.SetActive(false);

        Q1Char.SetActive(false);
        Q2Char.SetActive(false);
        Q3Char.SetActive(false);
        Q4Char.SetActive(false);
        Q5Char.SetActive(false);
    }

    IEnumerator Blink(Image img)
    {
        img.enabled = true;
        for(int i = 0; i < 4; i++)
        {
            switch (img.GetComponent<Image>().color.a.ToString())
            {
                case "0":
                    img.GetComponent<Image>().color = new Color(img.GetComponent<Image>().color.r, img.GetComponent<Image>().color.g, img.GetComponent<Image>().color.b, 1);
                    //Play sound
                    yield return new WaitForSeconds(0.5f);
                    break;
                case "1":
                    img.GetComponent<Image>().color = new Color(img.GetComponent<Image>().color.r, img.GetComponent<Image>().color.g, img.GetComponent<Image>().color.b, 0);
                    //Play sound
                    yield return new WaitForSeconds(0.5f);
                    break;
            }
        }
        
        blink = true;
        img.enabled = false;
    }
}

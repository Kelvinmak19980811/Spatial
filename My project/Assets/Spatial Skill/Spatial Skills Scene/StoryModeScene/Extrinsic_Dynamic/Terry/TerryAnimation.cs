using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TerryAnimation : MonoBehaviour
{
    public GameObject SpawnChar;//spawn character
    public GameObject Area;//area position
    public GameObject Target;//vfx position
    
    public Vector3 PicStartPos;
    public Color PicStartColor;
    public float PicStartSizeHeight;
    public float PicStartSizeWidth;

    bool blink = false;

    protected Animator animator;
    
    [SerializeField] protected RuntimeAnimatorController idle;
    [SerializeField] protected RuntimeAnimatorController running;

    protected bool SpawnCharBool = false;

    protected bool _char = true;
    protected bool _cam = true;
    protected bool _scale = true;
    public bool Answer;
    public bool NextQuestion;

    protected Vector3 CharPos;

    public TerryShow MainCamera;

    public Image CorrectPic;
    public Image WrongPic;
    void Start()
    {
        NextQuestion = false;
        CorrectPic.enabled = false;
        WrongPic.enabled = false;
        PicStartColor = MainCamera.pic.GetComponent<Image>().color;
    }

    // Update is called once per frame
    void Update()
    {
        if(SpawnCharBool == true && _char == false)
        {
            CharMove();
        }

        if (_cam == false)
        {
            CamMove();
        }

        if(_scale == false && Answer == true)
        {
            Correct();
        }

        if (_scale == false && Answer == false)
        {
            Wrong();
        }
    }

    public void SpawnCharacter()
    {
        DestroyChar("Character");
        float X = Target.transform.position.x + Random.Range(0, 50) ;
        float Z = Target.transform.position.z + Random.Range(0, 50);
        CharPos = new Vector3(X, 1, Z);
        SpawnChar = Instantiate(SpawnChar, CharPos, Quaternion.identity);
        SpawnChar.transform.localScale = new Vector3(2, 2, 2);
        SpawnChar.layer = 10;
        SpawnChar.tag = "Character";
        SpawnChar.name = "SpawnChar";
        SpawnCharBool = true;

        
    }

    public void DestroyChar(string ObjectTag)
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(ObjectTag);
        foreach (GameObject enemy in enemies)
            GameObject.Destroy(enemy);
    }

    public void CharMove()
    {
        Animator CharAnimator;

        CharAnimator = SpawnChar.GetComponent<Animator>();

        CharAnimator.runtimeAnimatorController = running;

        SpawnChar.transform.position = Vector3.Lerp(CharPos, Target.transform.position, 0.5f * Time.deltaTime);


        if (Vector3.Distance(CharPos, Area.transform.position) < 1f)
        {
            Debug.Log("Arrive");
            animator.runtimeAnimatorController = idle;
            SpawnChar.transform.rotation = Quaternion.Lerp(SpawnChar.transform.rotation, Quaternion.LookRotation(Target.transform.position), 0.5f * Time.deltaTime);

            float forwardangle = Vector3.Angle(SpawnChar.transform.forward, Target.transform.position);

            if (forwardangle < 1f)
            {
                _cam = false;
                _char = true;
            }
        }
    }

    public void CamMove()
    {
        GameObject MCamObj = MainCamera.MainCamera;
        Debug.Log("Camera");
        Vector3 MCPos = MCamObj.transform.position;

        Vector3 MCPosEnd = new Vector3(CharPos.x, 2, CharPos.z);

        MCamObj.transform.position = Vector3.Lerp(MCPos, MCPosEnd, 1 * Time.deltaTime);

        MCamObj.transform.rotation = Quaternion.Lerp(MCamObj.transform.rotation, Quaternion.LookRotation(Target.transform.position), 0.5f * Time.deltaTime);

        if (Vector3.Distance(MCamObj.transform.position, MCPosEnd) < 1f)
        {
            MCamObj.GetComponent<Camera>().cullingMask = 10;
            if (Vector3.Distance(MCamObj.transform.position, MCPosEnd) < 0.005f)
            {
                _scale = false;
                _cam = true;
            }
        }
    }

    public void Wrong()
    {
        RectTransform PicTran = MainCamera.pic.GetComponent<RectTransform>();
        Vector3 PicStartSize = new Vector3(PicTran.localScale.x, PicTran.localScale.y, PicTran.localScale.z);
        Vector3 PicEndSize = new Vector3(2, 2, PicTran.localScale.z);

        Vector3 PicStartPos = PicTran.transform.position;
        Vector3 PicEndPos = MainCamera.pic.GetComponent<RectTransform>().transform.position;

        Color PicColor = MainCamera.pic.GetComponent<Image>().color;
        Color TargetColor = new Color(0, 0, 0, 0);

        do
        {
            MainCamera.pic.transform.position = Vector3.Lerp(PicStartPos, PicEndPos, 1 * Time.deltaTime);
            Debug.Log("Correct Cam move");
        } while (Vector3.Distance(MainCamera.pic.transform.position, PicEndPos) < 1f);

        if (Vector3.Distance(MainCamera.pic.transform.position, PicEndPos) < 1f)
        {
            do
            {
                Debug.Log("Correct, Color changing and Scaling");
                PicTran.localScale = Vector2.Lerp(PicStartSize, PicEndSize, 1 * Time.deltaTime);
                PicColor = Color.Lerp(PicColor, TargetColor, 0.5f * Time.deltaTime);
            } while ((PicColor.a - TargetColor.a) < 0.5f);
        }

        if ((PicColor.a - TargetColor.a) < 0.5f)
        {
            StopAllCoroutines();
            ImgFlicking(WrongPic);
            StartCoroutine("Blink");
        }

        if (blink == true)
        {
            PicTran.transform.position = PicStartPos;
            PicTran.transform.localScale = PicStartSize;
            PicColor = new Color(0, 0, 0, 1);

            _scale = true;
            blink = false;
            NextQuestion = true;
        }
    }

    public void Correct()
    {
        RectTransform PicTran = MainCamera.pic.GetComponent<RectTransform>();
        Vector3 PicStartSize = new Vector3(PicTran.localScale.x, PicTran.localScale.y, PicTran.localScale.z);
        Vector3 PicEndSize = new Vector3(2, 2, PicTran.localScale.z);

        Vector3 PicStartPos = PicTran.transform.position;
        Vector3 PicEndPos = MainCamera.pictarget.GetComponent<RectTransform>().transform.position;

        PicStartColor = MainCamera.pic.GetComponent<Image>().color;
        Color TargetColor = new Color(0, 0, 0, 0);

        do
        {
            MainCamera.pic.transform.position = Vector3.Lerp(PicStartPos, PicEndPos, 1 * Time.deltaTime);
            Debug.Log("Correct Cam move");
        } while (Vector3.Distance(MainCamera.pic.transform.position, PicEndPos) < 1f);


        if (Vector3.Distance(MainCamera.pic.transform.position, PicEndPos) < 1f)
        {
            do
            {
                Debug.Log("Correct, Color changing and Scaling");
                PicTran.localScale = Vector2.Lerp(PicStartSize, PicEndSize, 1 * Time.deltaTime);
                MainCamera.pic.GetComponent<Image>().color = Color.Lerp(PicStartColor, TargetColor, 0.5f * Time.deltaTime);
            } while ((MainCamera.pic.GetComponent<Image>().color.a - TargetColor.a) < 0.5f);
        }

        if ((PicStartColor.a - TargetColor.a) < 0.5f)
        {
            StopAllCoroutines();
            ImgFlicking(CorrectPic);
            StartCoroutine("Blink");
        }

        if (blink == true)
        {
            PicTran.transform.position = PicStartPos;
            PicTran.transform.localScale = PicStartSize;
            MainCamera.pic.GetComponent<Image>().color = new Color(0, 0, 0, 1);

            _scale = true;
            blink = false;
        }
    }

    public void ImgFlicking(Image img)
    {
        img.enabled = true;
        IEnumerator Blink()
        {
            for (int i = 0; i < 4; i++)
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
}

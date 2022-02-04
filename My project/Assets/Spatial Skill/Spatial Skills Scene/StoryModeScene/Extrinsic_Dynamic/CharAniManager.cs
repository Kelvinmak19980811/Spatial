using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharAniManager : MonoBehaviour
{
    public GameObject[] Char;
    public GameObject Area;
    private GameObject Character;
    protected Vector3 CharPos;
    protected float charspeed = 0.1f;
    protected Animator animator;
    [SerializeField] protected RuntimeAnimatorController idle;
    [SerializeField] protected RuntimeAnimatorController running;

    public GameObject Target;

    public GameObject MainCamera;

    [SerializeField] protected LayerMask _CullingLayer;

    protected Vector3 SpawnCharPos;

    protected bool _char = true;
    protected bool _cam = true;
    protected bool _scale = true;


    public Button _Button;
    EDS_QM _QuizManager;

    public GameObject Pic;
    public GameObject PicTarget;

    public bool Answer;
    // Start is called before the first frame update
    void Start()
    {
        CharacterSpawn();
        Button btn = _Button.GetComponent<Button>();
    }

    private void Update()
    {
        if (_char == false)
        {
            CharMovement();
        }
        if(_cam == false)
        {
            CameraMove();
        }
        if(_scale == false)
        {
            if (Answer)
            {
                PicScaleCorrect();
            }else if (Answer == false)
            {
                PicScaleWrong();
            }
        }
    }

    void CameraMove()
    {
        Debug.Log("Camera");
        Vector3 MCPos = MainCamera.transform.position;

        Vector3 MCPosEnd = new Vector3(CharPos.x, 2, CharPos.z);

        MainCamera.transform.position = Vector3.Lerp(MCPos, MCPosEnd, 1 * Time.deltaTime);

        MainCamera.transform.rotation = Quaternion.Lerp(MainCamera.transform.rotation, Quaternion.LookRotation(Target.transform.position), 0.5f * Time.deltaTime);

        if (Vector3.Distance(MainCamera.transform.position, MCPosEnd) < 1f)
        {
            MainCamera.GetComponent<Camera>().cullingMask = _CullingLayer;
            if(Vector3.Distance(MainCamera.transform.position, MCPosEnd) < 0.005f)
            {
                _scale = false;
                _cam = true;
            }
        }
    }
    void CharMovement()
    {
        CharPos = new Vector3(Character.transform.position.x, 1, Character.transform.position.z);

        animator.runtimeAnimatorController = running;

        Character.transform.position = Vector3.Lerp(CharPos, Area.transform.position, charspeed * Time.deltaTime);

        if (Vector3.Distance(CharPos, Area.transform.position) < 1f)
        {
            Debug.Log("Arrive");
            animator.runtimeAnimatorController = idle;
            Character.transform.rotation = Quaternion.Lerp(Character.transform.rotation, Quaternion.LookRotation(Target.transform.position), 1 * Time.deltaTime);

            float forwardangle = Vector3.Angle(Character.transform.forward, Target.transform.position);
            
            if (forwardangle < 1f)
            {
                _cam = false;
                _char = true;
            }
        }
    }
    void CharacterSpawn()
    {
        CharacterSetting();
    }
    void CharacterSetting()
    {
        float RandX, RandZ;
        RandX = Area.transform.position.x + Random.Range(Area.transform.localScale.x, -Area.transform.localScale.x);
        RandZ = Area.transform.position.z + Random.Range(Area.transform.localScale.z, -Area.transform.localScale.z);
        SpawnCharPos = new Vector3(RandX, 1, RandZ);
        Character = Instantiate(Char[Random.Range(0, Char.Length)], SpawnCharPos, Quaternion.identity);
        Character.transform.localScale = new Vector3(2, 2, 2);
        Character.layer = 10;
        foreach (Transform T in Character.transform) //set character child object tag and layer
        {
            T.gameObject.tag = Character.tag; // set character child obj tag
            T.gameObject.layer = Character.layer; // set character child obj layer
        }
        Character.transform.LookAt(Area.transform.position);
        animator = Character.GetComponent<Animator>();
    }

    public void Testing()
    {
        _char = false;
    }

    public void PicScaleCorrect()
    {
        RectTransform PicTran = Pic.GetComponent<RectTransform>();
        Vector3 PicStartSize = new Vector3(PicTran.localScale.x, PicTran.localScale.y, PicTran.localScale.z);
        Vector3 PicEndSize = new Vector3(2, 2, PicTran.localScale.z);

        Vector3 PicStartPos = PicTran.transform.position;
        Vector3 PicEndPos = PicTarget.GetComponent<RectTransform>().transform.position;


        Pic.transform.position = Vector3.Lerp(PicStartPos, PicEndPos, 1 * Time.deltaTime);

        Color PicColor = Pic.GetComponent<Image>().color;


        if (Vector3.Distance(Pic.transform.position, PicEndPos) < 1f)
        {
            Debug.Log("Correct");
            PicTran.localScale = Vector2.Lerp(PicStartSize, PicEndSize, 1 * Time.deltaTime);
        }

        if (Vector2.Distance(PicStartSize, PicEndSize) < 1f)
        {
            _scale = true;
        }
    }
    public void PicScaleWrong()
    {
        RectTransform PicTran = Pic.GetComponent<RectTransform>();
        Vector3 PicStartSize = new Vector3(PicTran.localScale.x, PicTran.localScale.y, PicTran.localScale.z);
        Vector3 PicEndSize = new Vector3(2, 2, PicTran.localScale.z);

        Vector3 PicStartPos = PicTran.transform.position;
        Vector3 PicEndPos = PicTarget.GetComponent<RectTransform>().transform.position;


        Pic.transform.position = Vector3.Lerp(PicStartPos, PicEndPos, 1 * Time.deltaTime);

        Color PicColor = Pic.GetComponent<Image>().color;
        

        if (Vector3.Distance(Pic.transform.position, PicEndPos) < 1f)
        {
            Debug.Log("Wrong");
            PicTran.localScale = Vector2.Lerp(PicStartSize, PicEndSize, 1 * Time.deltaTime);
        }

        if (Vector2.Distance(PicStartSize, PicEndSize) < 1f)
        {
            _scale = true;
        }
    }
}

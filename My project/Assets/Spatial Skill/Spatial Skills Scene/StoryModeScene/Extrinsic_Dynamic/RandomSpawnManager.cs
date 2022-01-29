using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawnManager : MonoBehaviour
{
    public GameObject CityArea;
    public GameObject[] Characterlist;
    public GameObject CharacterSector;
    public GameObject MainCamera;


    private float RandX, RandZ;

    public Vector3 SpawnSize;
    private Vector3 RandPos;
    private Vector3 SpawnPos;
    public Vector3 CloneSize;

    private GameObject Area;

    public LayerMask spawnedObjectLayer;
    [SerializeField]
    private LayerMask CameraMask;

    private int SpawnIndex = 4;

    private float CameraHeight = 80.0f;

    public void RandSpawn()
    {
        DestroyObj("Character");
        DestroyObj("Area");

        RandX = Random.Range(70, 1117);
        RandZ = Random.Range(360, 710);

        RandPos = new Vector3(RandX, 1, RandZ);

        Vector3 AreaSize = new Vector3(SpawnSize.x, SpawnSize.y, SpawnSize.z);

        Area = GameObject.CreatePrimitive(PrimitiveType.Cube);

        Area = SpawnObjDetail(("Area"), ("Spawned Area"), 10);

        Vector3 AreaPos = Area.transform.position;

        AreaPos = RandPos;
        Area.transform.localScale = AreaSize;
        Area.transform.rotation = Quaternion.identity;

        Camera MCam = MainCamera.GetComponent<Camera>();

        MCam.transform.position = new Vector3(AreaPos.x, CameraHeight, AreaPos.z);
        MCam.transform.LookAt(Area.transform.position);
    }

    public void DestroyObj(string ObjectTag)
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(ObjectTag);
        foreach (GameObject enemy in enemies)
            GameObject.Destroy(enemy);
    }

    public void SpawnCharacter()
    {
        DestroyObj("Character");

        GameObject clone;

        for (int i = 0; i < SpawnIndex; i++)
        {
            do 
            {
                RandPosCheck();
            } while (RandPosCheck() == true);

            int chari = Random.Range(0, Characterlist.Length);

            clone = Instantiate(Characterlist[chari], SpawnPos, Quaternion.identity); // spawn character

            clone.transform.LookAt(Area.transform.position); // set all character look at the center of spawn area

            clone = SpawnObjDetail(("Character_" + i), ("Character"), 10 ); // set character name, tag and layer

            clone.transform.localScale = new Vector3(CloneSize.x, CloneSize.y, CloneSize.z); // set character size by using defined value

            foreach (Transform T in clone.transform) //set character child object tag and layer
            {
                T.gameObject.tag = clone.tag; // set character child obj tag
                T.gameObject.layer = clone.layer; // set character child obj layer
            }

            GameObject CharView = Instantiate(CharacterSector, clone.transform.position, clone.transform.rotation); //instantiate cone view at character position and rotation
            CharView.transform.SetParent(clone.transform); // set character as cone view parent obj

            CharView = SpawnObjDetail(("Character_" + i + "_View"), ("Character"), 10); // set cone view name , tag and layer

            CharView.transform.localScale = new Vector3(1, 1, 1); // set cone view scale

            

            GameObject CharCam = Instantiate(MainCamera, new Vector3(clone.transform.position.x, 2, clone.transform.position.z + 1), clone.transform.rotation);
            CharCam.transform.SetParent(clone.transform);

            CharCam = SpawnObjDetail(("Charater_" + i + "_Camera"), ("Character"), 10);

            Camera Cam = CharCam.GetComponent<Camera>();

            Cam.cullingMask = CameraMask;
            CharCam.GetComponent<AudioListener>().enabled = false;

        }
    }

    bool RandPosCheck()
    {
        bool Overlapping;

        Vector3 cloneCheckSize = new Vector3(5, 5, 5);

        RandX = Area.transform.position.x + Random.Range(Area.transform.localScale.x / 2, -Area.transform.localScale.x / 2);
        RandZ = Area.transform.position.z + Random.Range(Area.transform.localScale.z / 2, -Area.transform.localScale.z / 2);

        SpawnPos = new Vector3(RandX, 1, RandZ);

        if (Physics.CheckBox(SpawnPos, cloneCheckSize, Quaternion.identity, spawnedObjectLayer))
        {
            Overlapping = true;
            return Overlapping;
        }
        else
        {
            Overlapping = false;
            return Overlapping;
        }
    }

    public GameObject SpawnObjDetail(string objtag, string objname, int objlayer)
    {
        GameObject obj = new GameObject();
        
        obj.tag = objtag;
        obj.name = (objname);
        obj.layer = objlayer;
        return obj;
    }
}

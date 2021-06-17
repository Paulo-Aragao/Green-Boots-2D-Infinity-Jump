using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private float _maxHeight = 0;
    [SerializeField] private GameObject[] _prefab;
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = GameObject.FindObjectOfType<GameManager>();
            }

            return _instance;
        }
    }
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        CreatePlataforms();
        _maxHeight = 32;
    }

    public Text fpsText;
    public float deltaTime;
    //config general const
    public float screenSize = 6;
    void Update () {
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        float fps = 1.0f / deltaTime;
        fpsText.text = Mathf.Ceil (fps).ToString ();
        if(Player.Instance.transform.position.y > _maxHeight){
            CreatePlataforms();
            _maxHeight = Player.Instance.transform.position.y + 32;
        }
    }
    private void CreatePlataforms(){
        float position = _maxHeight;
        int randPositionIndex;
        int randPrefabIndex;
        var postiions = new float[]{-4.5f,-2.2f,0f,2.2f,4.5f}; 
        for (int i = 0; i < 8; i++)
        {
            position +=4;
            randPositionIndex =  Random.Range(0, 4);
            randPrefabIndex = Random.Range(0, _prefab.Length-1);;
            Instantiate(_prefab[randPrefabIndex], new Vector3(postiions[randPositionIndex],position, 0), Quaternion.identity);
        }
    }
    public void RestartLevel(){
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Plataforme");
        for(int i=0; i< enemies.Length; i++)
        {
            GameObject.Destroy(enemies[i]);
        }
        _maxHeight = 0;
        Instantiate(_prefab[0], new Vector3(0,-9, 0), Quaternion.identity);
        Instantiate(_prefab[0], new Vector3(-2.5f,-6, 0), Quaternion.identity);
        Instantiate(_prefab[0], new Vector3(2.5f,-3, 0), Quaternion.identity);
        Instantiate(_prefab[0], new Vector3(-2.5f,0, 0), Quaternion.identity);
        Instantiate(_prefab[0], new Vector3(2.5f,3, 0), Quaternion.identity);
        CreatePlataforms();
        _maxHeight = 32;
        GameObject.FindObjectOfType<Camera>().transform.position = new Vector3(0,0,-10);
        GameObject.FindObjectOfType<CameraControll>().maxHeight = 0;
        Player.Instance.gameObject.transform.position = new Vector3(0,-6,0);
    }
}

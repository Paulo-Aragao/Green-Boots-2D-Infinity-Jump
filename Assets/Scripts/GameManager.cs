using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    private float _maxHeight = 0;
    private int _lastHeight = 6;
    private int _coins = 0;
    //power ups
    private int _rokket_impulse_remaining = 1;
    private int _rokket_impulse_level = 1;
    private int _fashion_level = 1;
    private int _coin_plus_level = 1;
    [SerializeField] private GameObject _resultPanel;
    [SerializeField] private GameObject[] _prefabPlataformes;
    [SerializeField] private GameObject[] _prefabPowerUps;
    [SerializeField] private GameObject[] _prefabEnemys;
    [SerializeField] private TMP_Text _height;
    [SerializeField] private TMP_Text _record_height;
    [SerializeField] private Transform _heightColletor;
    [SerializeField] private SnowControll _snowControll;
    public Text fpsText;
    public float deltaTime;
    //config general const
    public float screenSize = 6;
    public int GetCoins(){
        return _coins;
    }
    public int GetHeight(){
        return ((_lastHeight+6)*2);
    }
    public int GetCoinPlusLevel(){
        return _coin_plus_level;
    }
    public int GetRokketLevel(){
        return _rokket_impulse_level;
    }
    public int GetFashionLevel(){
        return _fashion_level;
    }
    public void SetCoinPlusLevel(int new_level){
        _coin_plus_level = new_level;
    }
    public void SetRokketLevel(int new_level){
        _rokket_impulse_level = new_level;
    }
    public void SetFashionLevel(int new_level){
        _fashion_level = new_level;
    }
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
        _fashion_level = PlayerPrefs.GetInt("FashionLevel");
        _rokket_impulse_level = PlayerPrefs.GetInt("RokketLevel");
        _coin_plus_level = PlayerPrefs.GetInt("CoinPlusLevel");
    }
    void Start()
    {
        
        _resultPanel.SetActive(false);
        _record_height.text = PlayerPrefs.GetInt("HighHeightScore").ToString();
        _height.text = _lastHeight.ToString();
        CreatePlataforms();
        _maxHeight = 32;
    }

    void Update () {
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        float fps = 1.0f / deltaTime;
        fpsText.text = Mathf.Ceil (fps).ToString ();
        if(_heightColletor.position.y > _maxHeight){
            CreatePlataforms();
            _maxHeight = _heightColletor.position.y + 32;
        }
        if(Player.Instance.transform.position.y > _lastHeight){
            _lastHeight = (int)Player.Instance.transform.position.y;
            _height.text = ((_lastHeight*2)+12).ToString();
        }   
        
        
    }
    public void AddCoin(){
        _coins+=10;
    }
    private void CreatePlataforms(){
        GameObject[] prefabsPlataforme;
        GameObject[] prefabsPowerUp;
        GameObject[] prefabsEnemys;
        //levels dificult
        //Very hard
        if(_lastHeight > 10000 ){
            prefabsPlataforme = new GameObject[] {_prefabPlataformes[0]};
            prefabsPowerUp = new GameObject[] {_prefabPowerUps[0]};
            prefabsEnemys = new GameObject[] {_prefabEnemys[0]};
            SpawnPlataformes(prefabsPlataforme,prefabsPowerUp,prefabsEnemys,3,6,0);
        }else if(_lastHeight > 1200 ){//mid-high
            prefabsPlataforme = new GameObject[] {_prefabPlataformes[1],_prefabPlataformes[2],_prefabPlataformes[3]};
            prefabsPowerUp = new GameObject[] {_prefabPowerUps[0]}; 
            prefabsEnemys = new GameObject[] {_prefabEnemys[0]};
            SpawnPlataformes(prefabsPlataforme,prefabsPowerUp,prefabsEnemys,5,7,0);
        }
        else if(_lastHeight > 750 ){//mid-high
            prefabsPlataforme = new GameObject[] {_prefabPlataformes[4],_prefabPlataformes[5],_prefabPlataformes[2],_prefabPlataformes[3]};
            prefabsPowerUp = new GameObject[] {_prefabPowerUps[0]};
            prefabsEnemys = new GameObject[] {_prefabEnemys[0]};
            SpawnPlataformes(prefabsPlataforme,prefabsPowerUp,prefabsEnemys,3,6,0);
        }else if(_lastHeight > 500 ){//mid-high
            prefabsPlataforme = new GameObject[] {_prefabPlataformes[4],_prefabPlataformes[5],_prefabPlataformes[2]};
            prefabsPowerUp = new GameObject[] {_prefabPowerUps[0]};
            prefabsEnemys = new GameObject[] {_prefabEnemys[0]};
            SpawnPlataformes(prefabsPlataforme,prefabsPowerUp,prefabsEnemys,3,6,0);
        }else if(_lastHeight > 250 ){//middle
            
            prefabsPlataforme = new GameObject[] {_prefabPlataformes[0],_prefabPlataformes[1]};
            prefabsPowerUp = new GameObject[] {_prefabPowerUps[0]};
            prefabsEnemys = new GameObject[] {_prefabEnemys[0]};
            SpawnPlataformes(prefabsPlataforme,prefabsPowerUp,prefabsEnemys,3,6,0);
        }else{//base
            prefabsPlataforme = new GameObject[] {_prefabPlataformes[0]};
            prefabsPowerUp = new GameObject[] {_prefabPowerUps[0]};
            prefabsEnemys = new GameObject[] {_prefabEnemys[0]};
            SpawnPlataformes(prefabsPlataforme,prefabsPowerUp,prefabsEnemys,3,4,0);
        }
        if(_heightColletor.position.y > 2500){
            _snowControll.gameObject.GetComponent<ParticleSystem>().Stop();
        }else{
            _snowControll.IncreaseSnow();
        }
    }
    private void SpawnPlataformes(GameObject[] prefabsPlataforme,GameObject[] prefabsPowerUps,GameObject[] prefabsEnemys,int rateExtraPlataform, int ratePowerUp, int rateEnemys){
        float position = _maxHeight;
        int randPositionIndex;
        int randPrefabIndex;
        var postiions = new float[]{-4f,-2f,0f,2f,4f};
        for (int i = 0; i < 8; i++)
        {
            position +=4;
            randPositionIndex =  Random.Range(0, 4);
            randPrefabIndex = Random.Range(0, prefabsPlataforme.Length);
            Instantiate(prefabsPlataforme[randPrefabIndex], new Vector3(postiions[randPositionIndex],position, 0), Quaternion.identity);
            if(Random.Range(0, rateExtraPlataform) == 1){//extra plataformes
                randPositionIndex =  Random.Range(0, 4);
                randPrefabIndex = Random.Range(0, prefabsPlataforme.Length);
                Instantiate(_prefabPlataformes[randPrefabIndex], new Vector3(postiions[randPositionIndex],position+2, 0), Quaternion.identity);
            }
            if(Random.Range(0, rateExtraPlataform) == 1){//extra plataformes
                randPositionIndex =  Random.Range(0, 4);
                randPrefabIndex = Random.Range(0, prefabsPlataforme.Length);
                Instantiate(_prefabPlataformes[randPrefabIndex], new Vector3(postiions[randPositionIndex],position-2, 0), Quaternion.identity);
            }
            if(Random.Range(0, ratePowerUp) == 1){
                randPositionIndex =  Random.Range(0, 4);
                randPrefabIndex = Random.Range(0, prefabsPowerUps.Length);
                Instantiate(prefabsPowerUps[randPrefabIndex], new Vector3(postiions[randPositionIndex],position-2, 0), Quaternion.identity);
            }
            if(Random.Range(0, rateEnemys) == 1){
                randPositionIndex =  Random.Range(0, 4);
                randPrefabIndex = Random.Range(0, prefabsEnemys.Length);
                Instantiate(prefabsEnemys[randPrefabIndex], new Vector3(postiions[randPositionIndex],position-2, 0), Quaternion.identity);
            }
        }
    }
    public void GameOver(){
        _resultPanel.SetActive(true);
        if(((_lastHeight+6)*2) > PlayerPrefs.GetInt("HighHeightScore"))
        {
            PlayerPrefs.SetInt("HighHeightScore" , ((_lastHeight+6)*2));
            PlayerPrefs.Save ();
            _record_height.text = ((_lastHeight+6)*2).ToString();
        }
        GameObject[] plataforms = GameObject.FindGameObjectsWithTag("Plataforme");
        for(int i=0; i< plataforms.Length; i++)
        {
            GameObject.Destroy(plataforms[i]);
        }
        GameObject[] powerups = GameObject.FindGameObjectsWithTag("PowerUp");
        for(int i=0; i< powerups.Length; i++)
        {
            GameObject.Destroy(powerups[i]);
        }
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        for(int i=0; i< enemies.Length; i++)
        {
            GameObject.Destroy(enemies[i]);
        }
    }
    public void RestartLevel(){
        _resultPanel.SetActive(false);
        _snowControll.ResetSnow();
        _maxHeight = 0;
        _coins = 0;
        _lastHeight = 0;    
        _height.text = _lastHeight.ToString();
        Instantiate(_prefabPlataformes[0], new Vector3(0,-9, 0), Quaternion.identity);
        Instantiate(_prefabPlataformes[0], new Vector3(-2.5f,-6, 0), Quaternion.identity);
        Instantiate(_prefabPlataformes[0], new Vector3(2.5f,-3, 0), Quaternion.identity);
        Instantiate(_prefabPlataformes[0], new Vector3(-2.5f,0, 0), Quaternion.identity);
        Instantiate(_prefabPlataformes[0], new Vector3(2.5f,3, 0), Quaternion.identity);
        CreatePlataforms();
        _maxHeight = 32;
        GameObject.FindObjectOfType<Camera>().transform.position = new Vector3(0,0,-10);
        GameObject.FindObjectOfType<CameraControll>().maxHeight = 0;
        Player.Instance.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
        Invoke("SpawnPlayer",0.2f);
    }
    public void SpawnPlayer(){
        Player.Instance.gameObject.transform.position = new Vector3(0,-1,0);
    }
}

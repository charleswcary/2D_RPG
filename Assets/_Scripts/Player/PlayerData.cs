using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerData : MonoBehaviour {
    static private PlayerData _instance;
    static public PlayerData Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindObjectOfType<PlayerData>();
                DontDestroyOnLoad(_instance.gameObject);
            }
            return _instance;
        }
        set { }
    }
    float physical_f;
    float magic_f;
    
    public string health_s = "health";
    public float maxHealth_f = 30f;
    [SerializeField]
    private float _currentHealth;
    public float CurrentHealth_f
    {
        get { return _currentHealth; }
        set
        {
            if(value > maxHealth_f) { value = maxHealth_f; }
            if(value < 0) { value = 0; }
            _currentHealth = value;
            UpdateUI(_currentHealth, maxHealth_f, health_s);
        }
    }
    private string mana_s;
    private float _manaPoints;
    private float maxManaPoints_f = 30f;
    public float ManaPoints_f
    {
        get { return _manaPoints; }
        set
        {
            if(value > maxManaPoints_f) { value = maxManaPoints_f; }
            if(value < 0) { value = 0; }
            _manaPoints = value;
            UpdateUI(_manaPoints, maxManaPoints_f, mana_s);
        }
    }


    public int playerLevel_i;
    public int abilityPoints_i;
    public string xp_s = "XP";
    public float xpToLevel_f = 100f;
    [SerializeField]
    private float _currentXP;
    public float CurrentXP_f
    {
        get { return _currentXP; }
        set
        {
            if(value >= xpToLevel_f) { LevelUp(); }
            _currentXP = value;
            UpdateUI(_currentXP, xpToLevel_f, xp_s);
        }
    }
    


    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            if (_instance != this)
                Destroy(gameObject);
        }
            
    }
    void Start()
    {
        playerLevel_i = 1;
        CurrentHealth_f = maxHealth_f;
        ManaPoints_f = maxManaPoints_f;
        
    }
    void Update()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("BattleGround"))
        {
            UpdateUI(CurrentHealth_f, maxHealth_f, health_s);
            UpdateUI(ManaPoints_f, maxManaPoints_f, mana_s);
        }
    }

    public void TakeDamage(float damage)
    {
        CurrentHealth_f -= damage;
    }

    public void UpdateUI(float minValue, float maxValue, string UI)
    {
        float update_f = minValue / maxValue;
        if (UI == health_s)
        {
            if (HealthHUD.instance != null)
            {
                HealthHUD.instance.UpdateHealthHUD(minValue, maxValue);
            }
            else
                return;
        }
        else if(UI == xp_s) { return; }
        //else if(UI == mana_s) { ManaHUD.instance.UpdateManaHUD(minValue, maxValue); }
    }

    public void LevelUp()
    {
        playerLevel_i++;
        abilityPoints_i += 1;
        xpToLevel_f += playerLevel_i * (playerLevel_i * 100);
        maxHealth_f += (playerLevel_i + Random.Range(2, 8));
        CurrentHealth_f = maxHealth_f;
    }

    



}

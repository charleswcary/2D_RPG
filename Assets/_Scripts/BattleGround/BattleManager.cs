using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour {

    GameObject characterOne_go;
    public GameObject slimeEnemy_prefab;
    public List<Transform> enemyPosition_list = new List<Transform>();
    public List<Transform> characterPosition_list = new List<Transform>();
    List<GameObject> enemies_go = new List<GameObject>();

    public GameObject actionPanel;

    float actionTimer_f = 5f;
    float actionCounter_f = 0f;

    bool playerAction_b = false;

    enum BattleStates { Start, Wait, PlayerTurn, EnemyTurn, Lose, Win }

    BattleStates currentState_bs;

    void Start()
    {
        currentState_bs = BattleStates.Start;
    }
    void Update()
    {
        if (actionCounter_f == 0f)
        {
            StartCoroutine(ActionTimer());
        }

        switch (currentState_bs)
        {
            case (BattleStates.Start):
                SpawnEnemies();
                SpawnCharacters();
                NextCase();
                break;
            case (BattleStates.Wait):
                if (FindObjectOfType<Enemy>() == null)
                {
                    WinBattle();
                }
                else
                    NextCase();
                break;
            case (BattleStates.PlayerTurn):
                ChooseAction();
                break;
            case (BattleStates.EnemyTurn):
                EnemyAction();
                break;
            case (BattleStates.Lose):
                //if player dies, game over
                break;
            case (BattleStates.Win):
                WinBattle();
                break;
        }

        
    }


    public IEnumerator ActionTimer()
    {
        Debug.Log(actionTimer_f);
        actionCounter_f++;
        yield return new WaitForSeconds(1f);
        UpdateActionHUD();
        if (actionCounter_f == actionTimer_f)
        {
            playerAction_b = true;
            //NextCase();
        }
        else
        {
            StartCoroutine(ActionTimer());
        }
    }
    public void ChooseAction()
    {
        actionPanel.SetActive(true);
    }
    public void TakeAction()
    {
        actionPanel.SetActive(false);
        playerAction_b = false;
        actionCounter_f = 0;
        UpdateActionHUD();
        NextCase();
    }
    public void EnemyAction()
    {
        if (enemies_go.Count != 0)
        {
            characterOne_go.GetComponent<PlayerData>().TakeDamage(5);
            NextCase();
        }
        else
        {
            currentState_bs = BattleStates.Win;
        }
    }
    public void WinBattle()
    {
        GameObject dungeonMaster = GameObject.Find("DungeonMaster");
        dungeonMaster.GetComponent<LoadSceneManager>().OnLoadTestScene();
    }
    public void SpawnCharacters()
    {
        characterOne_go = GameObject.FindGameObjectWithTag("Player");
        characterOne_go.transform.position = characterPosition_list[0].position;
    }
    public void SpawnEnemies()
    {
        enemies_go.Add(Instantiate(slimeEnemy_prefab, enemyPosition_list[0].position, Quaternion.identity));
        enemies_go.Add(Instantiate(slimeEnemy_prefab, enemyPosition_list[1].position, Quaternion.identity));
        enemies_go.Add(Instantiate(slimeEnemy_prefab, enemyPosition_list[2].position, Quaternion.identity));
    }
    
    public void UpdateActionHUD()
    {
        ActionBarHUD.instance.UPdateActionTimerHUD(actionCounter_f, actionTimer_f);
    }
    public void NextCase()
    {
        if(currentState_bs == BattleStates.Start)
        {
            currentState_bs = BattleStates.Wait;
        }
        else if(currentState_bs == BattleStates.Wait && playerAction_b)
        {
            currentState_bs = BattleStates.PlayerTurn;
        }
        else if (currentState_bs == BattleStates.PlayerTurn && !playerAction_b)
        {
            currentState_bs = BattleStates.EnemyTurn;
        }
        else if (currentState_bs == BattleStates.EnemyTurn && !playerAction_b)
        {
                currentState_bs = BattleStates.Wait;
        }

    }
}

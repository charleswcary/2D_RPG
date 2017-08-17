using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float health = 10f;
    public float damage;
    
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            KillEnemy();
        }
    }

    public void KillEnemy()
    {
        Destroy(gameObject);
    //    GameObject battleManager = GameObject.Find("BattleManager");
    //    battleManager.GetComponent<BattleManager>().RemoveEnemies();
    }
}

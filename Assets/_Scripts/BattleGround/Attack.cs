using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

    public int damage = 10;

    public void DoDamage()
    {
        Enemy[] targets = FindObjectsOfType<Enemy>();
        targets[0].TakeDamage(damage);
    }
}

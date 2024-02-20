using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class HpManager : MonoBehaviour
{
    public int hp;
    [SerializeField] int maxHp;
    public enum damageType { arrow, sword}

    public void TakeDamage(int amount)
    {
        hp -= amount;
        if (hp <= 0)
        {
            hp = 0;
            Death();
        }
    }

    void Death()
    {
        GetComponent<IDeathAble>().Death();
    }

}

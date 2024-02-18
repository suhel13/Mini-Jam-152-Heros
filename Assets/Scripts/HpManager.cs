using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpManager : MonoBehaviour
{
    [SerializeField] int hp;
    [SerializeField] int maxHp;

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

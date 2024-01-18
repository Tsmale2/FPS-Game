using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float EnemyHp = 100f;

    bool isDead = false;

    public bool IsDead()
    {
        return isDead;
    }

    public void TakeDamage(float damage)
    {
        GetComponent<EnemyAI>().OnDamageTaken();
        EnemyHp -= damage;
        if (EnemyHp <= 0)
            Die();
    }

    private void Die()
    {
        if(isDead)
        {
            return;
        }
        isDead = true;
        GetComponent<Animator>().SetTrigger("isDying");
    }
}

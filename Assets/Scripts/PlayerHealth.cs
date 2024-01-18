using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float PlayerHp = 100f;

    public void TakeDamage(float damage)
    {
        PlayerHp -= damage;
        if (PlayerHp <= 0)
        {
            GetComponent<DeathHandler>().HandleDeath();
        }
            
    }
}

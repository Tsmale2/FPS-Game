using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour

{
    [SerializeField] float damage = 20f;
    [SerializeField] PlayerHealth Target;


    private void Start()
    {
        Target = FindObjectOfType<PlayerHealth>();
    }
    public void AttackHitEvent()
    {
        print("attacking");
        if (Target == null) { return; }
        Target.TakeDamage(damage);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    private float timeBtwAttacks;
    public float startTimeBtwAttacks;
    public float damage;

    public Transform attackPositon;
    public float attackRange;

    public LayerMask enemyLayer;

    void Update() {
        if(timeBtwAttacks <= 0) {
            if(Input.GetMouseButtonDown(0)) {
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPositon.position, attackRange, enemyLayer);
                
                Debug.Log("Attacked!");

                for(int i = 0; i < enemiesToDamage.Length; i++) {
                    enemiesToDamage[i].GetComponent<EnemyHealth>().TakeDamage(damage);
                }
            }

            timeBtwAttacks = startTimeBtwAttacks;
        }
        else {
            timeBtwAttacks -= Time.deltaTime;
        }
    }

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPositon.position, attackRange);
    }
}

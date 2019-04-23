using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GeneralState
{
    idle,
    walk,
    attack,
    stagger,
    dead
}

public class EnemyGeneral : MonoBehaviour
{

    public EnemyState currentState;
    public FloatValue maxHealth;
    public float health = 2f;
    public string enemyName;
    public int baseAttack;
    public float moveSpeed;

    [SerializeField] GameObject deathVFX;
    [SerializeField] float durationOfDeath = 5f;
    [SerializeField] GameObject generalCorpse;

    private void Awake()
    {
        health = maxHealth.initialValue;
    }





    private void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            //Die();
        }
    }

    /*private void Die()
    {
        GameObject death = Instantiate(deathVFX, transform.position, transform.rotation);
        StartCoroutine(DeathWait());
    }

    public IEnumerator DeathWait()
    {
        yield return new WaitForSeconds(5f);
        generalCorpse = Instantiate(generalCorpse, transform.position, transform.rotation);
        Death();
    }


   private void Death()
    {
        Destroy(death, durationOfDeath);
        Destroy(gameObject);
    }*/







    public void Knock(Rigidbody2D myRigidBody, float knockTime, float damage)
    {
        StartCoroutine(KnockCo(myRigidBody, knockTime));
        TakeDamage(damage);
    }

    private IEnumerator KnockCo(Rigidbody2D myRigidBody, float knockTime)
    {
        if (myRigidBody != null)
        {
            yield return new WaitForSeconds(knockTime);
            myRigidBody.velocity = Vector2.zero;
            myRigidBody.GetComponent<Enemy>().currentState = EnemyState.idle;
            myRigidBody.velocity = Vector2.zero;
        }
    }




}

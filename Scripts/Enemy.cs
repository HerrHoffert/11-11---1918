using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    idle,
    walk,
    attack,
    stagger,
    dead
}

public class Enemy : MonoBehaviour
{
    
    public EnemyState currentState;
    public FloatValue maxHealth;
    public float health = 2f;
    public string enemyName;
    public int baseAttack;
    public float moveSpeed;

    [SerializeField] GameObject deathVFX;
    [SerializeField] float durationOfDeath = 5f;
    [SerializeField] GameObject germanCorpse;

    [SerializeField] AudioClip bounceSFX;
    [SerializeField] [Range(0, 1)] float bounceSoundVolume = 0.75f;

    [SerializeField] int scoreValue = 1;

    private void Awake()
    {
        health = maxHealth.initialValue;
    }

    private void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            FindObjectOfType<GameSession>().AddToScore(scoreValue);
            Die();
        }
    }

    private void Die()
    {
        
        foreach (Behaviour childCompnent in gameObject.GetComponentsInChildren<Behaviour>())
            childCompnent.enabled = false;
        StartCoroutine(Death());
    }

    IEnumerator Death()
    {
        yield return new WaitForSeconds(0.2f);
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        GameObject death = Instantiate(deathVFX, transform.position, transform.rotation);
        Destroy(death, durationOfDeath);
        yield return new WaitForSeconds(1.8f);
        germanCorpse = Instantiate(germanCorpse, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    public void Knock(Rigidbody2D myRigidBody, float knockTime, float damage)
    {
        StartCoroutine(KnockCo(myRigidBody, knockTime));
        TakeDamage(damage);
    }

    private IEnumerator KnockCo(Rigidbody2D myRigidBody, float knockTime)
    {
        if (myRigidBody != null)
        {
            AudioSource.PlayClipAtPoint(bounceSFX, Camera.main.transform.position, bounceSoundVolume);
            yield return new WaitForSeconds(knockTime);
            myRigidBody.velocity = Vector2.zero;
            myRigidBody.GetComponent<Enemy>().currentState = EnemyState.idle;
            myRigidBody.velocity = Vector2.zero;
        }
    }

}

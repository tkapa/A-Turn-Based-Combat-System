using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObject : MonoBehaviour {

    public Enemy enemyData;
    public EnemyList enemies;

    [SerializeField]
    private Data data;

    public GameEvent deathEvent;
    public Material material;
    public bool isTargeted = false;

    public Resource playerTarget;
    public Resource playerHealth;

    Renderer render;
    MaterialPropertyBlock propertyBlock;

    private void Awake()
    {
        data = enemyData.data;

        render = GetComponent<Renderer>();
        propertyBlock = new MaterialPropertyBlock();
        render.GetPropertyBlock(propertyBlock);

        propertyBlock.SetTexture("_MonsterTexture", data.texture);
        render.SetPropertyBlock(propertyBlock);
    }

    private void Start()
    {
        
    }

    //Ensure the enemy adds and removes themselves from the enemy list automatically
    private void OnEnable()
    {
        enemies.Add(this);
    }

    private void OnDisable()
    {
        enemies.Remove(this);
    }

    //Sets player's current target to clicked enemy
    private void OnMouseDown()
    {
        enemies.items[playerTarget.currentValue].Targeted();
        playerTarget.currentValue = enemies.items.FindIndex(s=>s==this);
        Targeted();
    }

    //Determines skill to use on own turn
    public void ExecuteAction()
    {
        Debug.Log("Enemy performed an Action!");

        playerHealth.currentValue -= data.skills[0].damage;
    }

    //Changes status of enemy to targeted or untargeted
    public void Targeted()
    {
        render.GetPropertyBlock(propertyBlock);

        isTargeted = !isTargeted;
        
        if (isTargeted)
        { 
            propertyBlock.SetInt("_IsTargeted", 1);
        }           
        else
        {
            propertyBlock.SetInt("_IsTargeted", 0);
        }

        render.SetPropertyBlock(propertyBlock);
    }

    //Called things that happen when the enemy takes damage
    public void TakeDamage(int damage)
    {
        data.health -= damage;

        if (data.health <= 0)
            Death();
    }

    void Death()
    {
        StartCoroutine(DeathAnimation());

        //Exp rewards, death actions, run enemy death events
        if (isTargeted)
        {
            Targeted();
            enemies.Remove(this);
            playerTarget.currentValue = 0;

            if (enemies.items.Count != 0)
                enemies.items[playerTarget.currentValue].Targeted();
        }   
    }

    //A coroutine that animates the death of an enemy, disintegrating them, then they die
    private IEnumerator DeathAnimation()
    {
        render.GetPropertyBlock(propertyBlock);

        float currentValue = 0;

        while(currentValue < 1)
        {
            yield return new WaitForFixedUpdate();

            currentValue += Time.fixedDeltaTime;
            propertyBlock.SetFloat("_DissolveValue", currentValue);
            render.SetPropertyBlock(propertyBlock);
        }

        deathEvent.Raise();
        this.gameObject.SetActive(false);

        yield return null;
    }
}

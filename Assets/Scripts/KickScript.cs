using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;

public class KickScript : MonoBehaviour
{
    [Header("Variables")]
    public GameObject enemy;
    public bool isTrigger;
    public HealthSystem hs; 
    public EnemyAbility ea; 
    public bool commencePain;
    public float cooldown;
    public float damageCooldown;
    float lastShot;
    float lastDam;
    public float holdTime;
    public float changePerSecond;
    public Animator anim;
    public Material whiteMat;
    public Material basicMat;
    public ParticleSystem hitEffect;
    public BoxCollider collider;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BoxEnemy") && isTrigger == true)
        {
            enemy = other.gameObject;
            ea = enemy.GetComponent<EnemyAbility>();
            Debug.Log("Kick");
            commencePain = true;
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            collider.enabled = true;
            if(Time.time - lastShot < cooldown)
            {
                return;
            }
            lastShot = Time.time;
            isTrigger = true;
            anim.SetBool("isAttacking", true);
        }

        if(Input.GetMouseButton(0))
        {
            collider.enabled = true;
            holdTime += changePerSecond * Time.deltaTime;

            if(holdTime > 0.05f)
            {
                isTrigger = false;
                commencePain = false;
                anim.SetBool("isAttacking", false);
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            collider.enabled = false;
            isTrigger = false;
            commencePain = false;
            holdTime = 0f;
            enemy = null;
            anim.SetBool("isAttacking", false);
        }

        if (commencePain == true)
        {
            if(Time.time - lastDam < damageCooldown)
            {
                return;
            }
            lastDam = Time.time;
            ea.healthPoints -= 20f;
            hitEffect.Play();
        }

        if (commencePain == false)
        {
            ea.healthPoints -= 0f;
            hitEffect.Stop();
        }
    } 
}

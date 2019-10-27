using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mage : MonoBehaviour
{
    public Stats mageStats;
    public int hp, mp;
    public int experienceGifted = 1;
    public bool attacking = false;
    public Text damageReceived;
    public float numberTime, chance;
    public bool enemyMovement = true;
    public CircleCollider2D enemyCollider;
    public GameObject hearth;

    public EnemyFSMState currentState = EnemyFSMState.WAIT;

    public float waitTime = 2.0f;
    public float timeWaited, timeWaitedSinceAttack;

    public Animator anim;

    public Transform[] path;
    int currentPathNode = 0;

    public float speed = 2.0f;
    public int visionRadious = 10;
    public float dist;

    public Vector3 target;
    public Vector2 knockBack;

    public Rigidbody2D rb;

    public enum EnemyFSMState
    {
        MOVE, WAIT, CHANGE_PATH, FOLLOW
    }

    void Initialize(Stats batStats)
    {
        this.mageStats = batStats;
        hp = Formulas.GetMaxHp(batStats);
        mp = Formulas.GetMaxMp(batStats);
    }

    private void Awake()
    {
        Initialize(mageStats);
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        enemyCollider = gameObject.GetComponent<CircleCollider2D>();
        knockBack = new Vector2(0, 0);
    }

    void Move()
    {
        if (enemyMovement == true)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, path[currentPathNode].position, speed * Time.deltaTime);
        }

        if (dist <= visionRadious)
        {
            currentState = EnemyFSMState.FOLLOW;
        }
        else if (Vector3.Distance(this.transform.position, path[currentPathNode].position) < 0.001f)
        {
            currentState = EnemyFSMState.CHANGE_PATH;
        }
    }

    void ChangePath()
    {
        currentPathNode++;
        if (currentPathNode >= path.Length)
        {
            currentPathNode = 0;
        }
        if (dist <= visionRadious)
        {
            currentState = EnemyFSMState.FOLLOW;
        }
        else
        {
            currentState = EnemyFSMState.WAIT;
        }
    }

    void Wait()
    {
        timeWaited += Time.deltaTime;

        if (timeWaited > waitTime)
        {
            currentState = EnemyFSMState.MOVE;
            timeWaited = 0f;
        }
    }

    void Follow()
    {
        if (enemyMovement == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }

        Vector3 diff = target - transform.position;
        if (Mathf.Abs(diff.x) > Mathf.Abs(diff.y))
        {
            if (diff.x > 0)
            {
                anim.Play("Bat_Idle");
            }
            else
            {
                anim.Play("Bat_Idle");
            }
        }
        else
        {
            if (diff.y > 0)
            {
                anim.Play("Bat_Back");
            }
            else
            {
                anim.Play("Bat_Idle");
            }
        }

        if (dist > visionRadious)
        {
            currentState = EnemyFSMState.MOVE;
        }
    }

    void Attack()
    {
        attacking = true;

        Player.Instance.playerStats.hp -= Formulas.GetMagicalDamage(mageStats, Player.Instance.playerStats, 1);

        Vector3 diff = target - transform.position;
        if (Mathf.Abs(diff.x) > Mathf.Abs(diff.y))
        {
            if (diff.x > 0)
            {
                Player.Instance.movement = false;
                UIManager.Instance.newPlayer.GetComponent<Rigidbody2D>().AddForce(new Vector2(20, 0));
                Invoke("EnablePlayerMovement", 0.5f);
            }
            else
            {
                Player.Instance.movement = false;
                UIManager.Instance.newPlayer.GetComponent<Rigidbody2D>().AddForce(new Vector2(-20, 0));
                Invoke("EnablePlayerMovement", 0.5f);
            }
        }
        else
        {
            if (diff.y > 0)
            {
                Player.Instance.movement = false;
                UIManager.Instance.newPlayer.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 20));
                anim.Play("Bat_Back");
                Invoke("EnablePlayerMovement", 0.5f);
            }
            else
            {
                Player.Instance.movement = false;
                UIManager.Instance.newPlayer.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -20));
                Invoke("EnablePlayerMovement", 0.5f);
            }

        }
    }

    private void Update()
    {
        if (currentState == EnemyFSMState.WAIT)
        {
            Wait();
        }
        else if (currentState == EnemyFSMState.MOVE)
        {
            Move();
        }
        else if (currentState == EnemyFSMState.CHANGE_PATH)
        {
            ChangePath();
        }
        else if (currentState == EnemyFSMState.FOLLOW)
        {
            Follow();
        }

        target = UIManager.Instance.newPlayer.transform.position;

        if (hp <= 0)
        {
            chance = Random.Range(1, 101);
            if (chance <= 40)
            {
                Instantiate(hearth, transform.position, Quaternion.Euler(0, 0, 0));
            }
            EnablePlayerMovement();
            Destroy(gameObject);
            damageReceived.text = "";
            Player.Instance.playerStats.experience += experienceGifted;
        }

        timeWaitedSinceAttack += Time.deltaTime;
        if (timeWaitedSinceAttack >= 2)
        {
            attacking = false;
            timeWaitedSinceAttack = 0;
        }

        numberTime += Time.deltaTime;
        damageReceived.transform.position = this.transform.position + new Vector3(0, 1, 0);
        if (numberTime >= 1)
        {
            numberTime = 0;
            damageReceived.text = "";
        }

        dist = Vector3.Distance(target, transform.position);
        rb.velocity = knockBack;
    }

    void EnablePlayerMovement()
    {
        Player.Instance.movement = true;
        Player.Instance.rb.velocity = new Vector3(0, 0, 0);
    }

    void EnableEnemyMovement()
    {
        enemyMovement = true;
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Attack"))
        {
            hp -= Formulas.GetPhysicalDamage(Player.Instance.playerStats, mageStats, 1);
            damageReceived.text = "" + Formulas.GetPhysicalDamage(Player.Instance.playerStats, mageStats, 1);
            Vector3 diff = transform.position - target;
            if (Mathf.Abs(diff.x) > Mathf.Abs(diff.y))
            {
                if (diff.x > 0)
                {
                    enemyMovement = false;
                    knockBack = new Vector2(300, 0);
                    rb.AddForce(knockBack);
                    knockBack = new Vector2(0, 0);
                    Invoke("EnableEnemyMovement", 0.5f);
                }
                else
                {
                    enemyMovement = false;
                    knockBack = new Vector2(-300, 0);
                    rb.AddForce(knockBack);
                    knockBack = new Vector2(0, 0);
                    Invoke("EnableEnemyMovement", 0.5f);
                }
            }
            else
            {
                if (diff.y > 0)
                {
                    enemyMovement = false;
                    knockBack = new Vector2(0, 300);
                    rb.AddForce(knockBack);
                    knockBack = new Vector2(0, 0);
                    Invoke("EnableEnemyMovement", 0.5f);
                }
                else
                {
                    enemyMovement = false;
                    knockBack = new Vector2(0, -300);
                    rb.AddForce(knockBack);
                    knockBack = new Vector2(0, 0);
                    Invoke("EnableEnemyMovement", 0.5f);
                }
            }
        }
        if (coll.CompareTag("FireBall"))
        {
            hp -= Formulas.GetMagicalDamage(Player.Instance.playerStats, mageStats, 1);
            damageReceived.text = "" + Formulas.GetMagicalDamage(Player.Instance.playerStats, mageStats, 1);
            Vector3 diff = transform.position - target;
            if (Mathf.Abs(diff.x) > Mathf.Abs(diff.y))
            {
                if (diff.x > 0)
                {
                    enemyMovement = false;
                    knockBack = new Vector2(300, 0);
                    rb.AddForce(knockBack);
                    knockBack = new Vector2(0, 0);
                    Invoke("EnableEnemyMovement", 0.5f);
                }
                else
                {
                    enemyMovement = false;
                    knockBack = new Vector2(-300, 0);
                    rb.AddForce(knockBack);
                    knockBack = new Vector2(0, 0);
                    Invoke("EnableEnemyMovement", 0.5f);
                }
            }
            else
            {
                if (diff.y > 0)
                {
                    enemyMovement = false;
                    knockBack = new Vector2(0, 300);
                    rb.AddForce(knockBack);
                    knockBack = new Vector2(0, 0);
                    Invoke("EnableEnemyMovement", 0.5f);
                }
                else
                {
                    enemyMovement = false;
                    knockBack = new Vector2(0, -300);
                    rb.AddForce(knockBack);
                    knockBack = new Vector2(0, 0);
                    Invoke("EnableEnemyMovement", 0.5f);
                }
            }

        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            timeWaitedSinceAttack = 0;
            Attack();
            currentState = EnemyFSMState.WAIT;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            currentState = EnemyFSMState.MOVE;
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    public Stats playerStats;

    public Vector2 mov;
    public float speed = 6;
    public float horizontalInput, verticalInput;
    public Rigidbody2D rb;
    public Animator anim;
    public Text statsPoints;
    public GameObject mainCamera;
    public GameObject fireBall;
    public static GameObject newWave;
    public bool attacking, movement;

    public GameObject playerHpBar;
    public GameObject hpText;

    CircleCollider2D attackCollider;


    public int expLackToLevelUp, nextLevelExp, manaCost;

    private void Awake()
    {
        Initialize(playerStats);
        Instance = this;
    }

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        attackCollider = transform.GetChild(0).GetComponent<CircleCollider2D>();
        attackCollider.enabled = false;
        movement = true;
        playerHpBar = GameObject.FindGameObjectWithTag("HealthBar");
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        manaCost = Formulas.ManaCost(playerStats);
        LevelUp();
        expLackToLevelUp = nextLevelExp - playerStats.experience;
        PhysicalAttack();
        MagicalAttack();
        ShortKeys();
        if(playerStats.hp <= 0)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Main_Menu");
        }
        if(playerStats.hp > playerStats.maxHp)
        {
            playerStats.hp = playerStats.maxHp;
        }

        playerHpBar.transform.localScale = new Vector2((float)playerStats.hp / (float)playerStats.maxHp, 1);
        hpText = GameObject.FindGameObjectWithTag("HpText");
        hpText.GetComponent<Text>().text = playerStats.hp + " / " + playerStats.maxHp;
    }

    void FixedUpdate()
    {
        PlayerMovement();
        Animations();
    }

    private void PlayerMovement()
    {
        float fixedSpeed = speed * Time.deltaTime;
        if(movement == true)
        {
            rb.MovePosition(rb.position + mov * fixedSpeed);
        }
    }

    private void Animations()
    {
        mov = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
        if(mov != Vector2.zero)
        {
            anim.SetFloat("MovX", mov.x);
            anim.SetFloat("MovY", mov.y);
            anim.SetBool("Walking", true);
        }
        else
        {
            anim.SetBool("Walking", false);
        }

        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        attacking = stateInfo.IsName("Player_Attack");

        if (Input.GetMouseButtonDown(0) && !attacking)
        {
            anim.SetTrigger("Attacking");
        }
    }

    void Initialize(Stats playerStats)
    {
        if(CharacterStats.level == 0)
        {
            CharacterStats.level = 1;
        }
        if (CharacterStats.strength == 0)
        {
            CharacterStats.strength = 1;
        }
        if (CharacterStats.constitution == 0)
        {
            CharacterStats.constitution = 1;
        }
        if (CharacterStats.dexterity == 0)
        {
            CharacterStats.dexterity = 1;
        }
        if (CharacterStats.intelligence == 0)
        {
            CharacterStats.intelligence = 1;
        }
        if (CharacterStats.wisdom == 0)
        {
            CharacterStats.wisdom = 1;
        }
        if (CharacterStats.maxHp == 0)
        {
            CharacterStats.maxHp = Formulas.GetMaxHp(playerStats);
        }
        if (CharacterStats.hp == 0)
        {
            CharacterStats.hp = Formulas.GetMaxHp(playerStats);
        }
        if (CharacterStats.maxMp == 0)
        {
            CharacterStats.maxMp = Formulas.GetMaxMp(playerStats);
        }
        if (CharacterStats.mp == 0)
        {
            CharacterStats.mp = Formulas.GetMaxMp(playerStats);
        }
        this.playerStats = playerStats;
        playerStats.level = CharacterStats.level;
        playerStats.experience = CharacterStats.experience;
        playerStats.strength = CharacterStats.strength;
        playerStats.constitution = CharacterStats.constitution;
        playerStats.dexterity = CharacterStats.dexterity;
        playerStats.intelligence = CharacterStats.intelligence;
        playerStats.wisdom = CharacterStats.wisdom;
        playerStats.statsPoints = CharacterStats.statsPoints;
        playerStats.maxHp = CharacterStats.maxHp;
        playerStats.hp = CharacterStats.hp;
        playerStats.maxMp = CharacterStats.maxMp;
        playerStats.mp = CharacterStats.mp;
    }

    public void SaveLocalStats()
    {
        CharacterStats.level = playerStats.level;
        CharacterStats.experience = playerStats.experience;
        CharacterStats.strength = playerStats.strength;
        CharacterStats.constitution = playerStats.constitution;
        CharacterStats.dexterity = playerStats.dexterity;
        CharacterStats.intelligence = playerStats.intelligence;
        CharacterStats.wisdom = playerStats.wisdom;
        CharacterStats.statsPoints = playerStats.statsPoints;
        CharacterStats.maxHp = playerStats.maxHp;
        CharacterStats.maxMp = playerStats.maxMp;
        CharacterStats.hp = playerStats.hp;
        CharacterStats.mp = playerStats.mp;
    }

    public void LevelUp()
    {
        int iniExp, aux, currentLevelExp;

        iniExp = 0;
        nextLevelExp = 1;
        currentLevelExp = playerStats.level;
        for(currentLevelExp = 0; currentLevelExp < playerStats.level; currentLevelExp++)
        {
            aux = iniExp;
            iniExp = nextLevelExp;
            nextLevelExp = aux + iniExp;
        }

        if(playerStats.experience >= nextLevelExp)
        {
            playerStats.experience = 0;
            playerStats.level++;
            playerStats.strength++;
            playerStats.constitution++;
            playerStats.dexterity++;
            playerStats.intelligence++;
            playerStats.wisdom++;
            playerStats.statsPoints++;
            playerStats.maxHp = Formulas.GetMaxHp(playerStats);
            playerStats.hp = Formulas.GetMaxHp(playerStats);
            playerStats.maxMp = Formulas.GetMaxMp(playerStats);
            playerStats.mp = Formulas.GetMaxMp(playerStats);
            SaveLocalStats();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Hearth" && playerStats.hp != playerStats.maxHp)
        {
            playerStats.hp += 5;
            Destroy(collision.gameObject);
        }

        if(collision.gameObject.CompareTag("FirstCity - Route01"))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Route_01");
            UIManager.playerInstantiate = new Vector3(0, 0, 0);
            SaveLocalStats();
        }
        if (collision.gameObject.CompareTag("Route01 - FirstCity"))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("First_City");
            UIManager.playerInstantiate = new Vector3(-26, -5, 0);
            SaveLocalStats();
        }
        if (collision.gameObject.CompareTag("Route01 - Trap"))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Trap");
            UIManager.playerInstantiate = new Vector3(0, 0, 0);
            SaveLocalStats();
        }
        if (collision.gameObject.CompareTag("Trap - Route01"))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Route_01");
            UIManager.playerInstantiate = new Vector3(-16, 12, 0);
            SaveLocalStats();
        }
    }

    public void PhysicalAttack()
    {
        if(mov != Vector2.zero)
        {
            attackCollider.offset = new Vector2(mov.x * 0.3f, mov.y * 0.3f);
        }
        if (attacking == true)
        {
            attackCollider.enabled = true;
        }
        else
        {
            attackCollider.enabled = false;
        }
    }

    public void Resume()
    {
        PauseMenu.Instance.pauseMenuUI.SetActive(false);
        PauseMenu.Instance.statsMenuPanelUI.SetActive(false);
        PauseMenu.Instance.statsMenuUI.SetActive(false);
        PauseMenu.Instance.healthBar.SetActive(true);
        Time.timeScale = 1f;
        PauseMenu.gameIsPaused = false;
        PauseMenu.inStatsMenu = false;
    }

    public void Pause()
    {
        PauseMenu.Instance.pauseMenuUI.SetActive(true);
        PauseMenu.Instance.healthBar.SetActive(false);
        Time.timeScale = 0f;
        PauseMenu.gameIsPaused = true;
    }

    void ShortKeys()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (PauseMenu.gameIsPaused == true)
            {
                Resume();
            }
            else if (PauseMenu.inStatsMenu == true)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (PauseMenu.inStatsMenu == false)
            {
                GoToStatsMenu();
            }
            else if (PauseMenu.inStatsMenu == true)
            {
                Resume();
            }
        }
    }

    public void GoToStatsMenu()
    {
        PauseMenu.Instance.pauseMenuUI.SetActive(false);
        PauseMenu.Instance.healthBar.SetActive(false);
        PauseMenu.Instance.statsMenuPanelUI.SetActive(true);
        PauseMenu.Instance.statsMenuUI.SetActive(true);
        Time.timeScale = 0f;
        PauseMenu.inStatsMenu = true;
    }

    void MagicalAttack()
    {
        if(Input.GetMouseButtonDown(1) && playerStats.mp >= manaCost)
        {
            float angle = Mathf.Atan2(anim.GetFloat("MovY"), anim.GetFloat("MovX")) * Mathf.Rad2Deg;

            GameObject newFireBall = Instantiate(fireBall, transform.position, Quaternion.AngleAxis(angle, Vector3.forward));

            playerStats.mp -= manaCost;

            FireBall fir = newFireBall.GetComponent<FireBall>();
            fir.mov.x = anim.GetFloat("MovX");
            fir.mov.y = anim.GetFloat("MovY");
            SaveLocalStats();
        }
    }
}

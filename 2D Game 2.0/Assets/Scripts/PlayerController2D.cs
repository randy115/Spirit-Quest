using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController2D : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb2d;
    static int key = 0;
    SpriteRenderer spriteRenderer;
    bool isGrounded;
    public float jumpHeight;
    public float runSpeed;
    [SerializeField]
    Transform GroundCheck;
    [SerializeField]
    Transform GroundCheckL;
    [SerializeField]
    Transform GroundCheckR;
    public float timeBetweenAttack;
    public int health = 2;
    public bool is_dead = false;
    public int positionx = 0;
    public int positiony = 0;
    public int positionz = 0;
    public float cooldown;
    public float startTimeBetweenAttack;
    public LayerMask whatIsEnemies;
    public int damage;
    public Transform attackPos;
    public int killcounters;
    public bool invicible;
    public float attackRange;
    public float invicibility_timer = 0f;
    public float max = 2f;
    public float max_cooldown = 2f;
    Color new_color;

    //Start is called before the first frame update
    void Start()
    {
        is_dead = false;
        cooldown = 0;
        invicible = false;
        killcounters = 0;
        positionx = 0;
        positiony = 0;
        positionz = 0;
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    private void FixedUpdate()
    {
        if(cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }
        if (invicibility_timer > 0)
        {
            gameObject.layer = 10;
            invicibility_timer -= Time.deltaTime;

            //make sprite transparent
            new_color = new Color(1, 1, 1, .2f);
            spriteRenderer.color = new_color;
        }
        else
        {
            //make sprite opaque
           new_color = new Color(1, 1, 1);
            spriteRenderer.color = new_color;
        }
        //here
        if (health <= 0 && is_dead == false)
        {
            is_dead = true;
            Time.timeScale = 0;
            float wait = 2f;
            animator.Play("Die");
            while (wait > 0)
            {
                wait -= Time.deltaTime;
            }
            Resources.UnloadUnusedAssets();
            PlayerPrefs.SetInt("Player_Score", killcounters);
            //Debug.Log(PlayerPrefs.GetInt(key).ToString());
            SceneManager.LoadScene(2);

        }

        if ((Physics2D.Linecast(transform.position, GroundCheck.position, 1 << LayerMask.NameToLayer("Ground"))) ||
            (Physics2D.Linecast(transform.position, GroundCheckL.position, 1 << LayerMask.NameToLayer("Ground"))) ||
            (Physics2D.Linecast(transform.position, GroundCheckR.position, 1 << LayerMask.NameToLayer("Ground"))))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
            animator.Play("Jump");
        }
        if (Input.GetKey("d") || Input.GetKey("right") || positionx == 1)
        {
            rb2d.velocity = new Vector2(runSpeed, rb2d.velocity.y);
            if (isGrounded)
            {
                animator.Play("Run");
            }
            spriteRenderer.flipX = false;
        }
        else if (Input.GetKey("a") || Input.GetKey("left") || positionx == -1)
        {
            rb2d.velocity = new Vector2(-1*runSpeed, rb2d.velocity.y);
            if (isGrounded)
            {
                animator.Play("Run");
            }
            spriteRenderer.flipX = true;
        }
        else if (Input.GetKey("b") || positionz == 1)
        {
                animator.Play("Attack");
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    if(enemiesToDamage[i].tag == "Voldo")
                    {
                         enemiesToDamage[i].GetComponent<VoldoScript>().takeDamage(damage);
                    }
                    else if(enemiesToDamage[i].tag == "Gruby")
                    {
                        enemiesToDamage[i].GetComponent<GrubyScript>().takeDamage(damage);
                    }

                }

        }
        else
        {
            if (isGrounded)
            {
                animator.Play("Idle");
            }
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        }
        if ((Input.GetKey("space") || positiony == 1) && isGrounded)
        {

            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpHeight);
            animator.Play("Jump");
            isGrounded = false;
        }
        if ((Input.GetKey("space") || positiony == 1) && (Input.GetKey("b") || positionz == 1))
        {
            animator.Play("Jump");
            animator.Play("Jump_Attack");
        }
    }
    public void playerDamage(int damage)
    {
        if (invicibility_timer <= 0)
        {
            health -= damage;

            //grant brief invulnerability IF player is still alive
            if (health > 0)
            {
                invicibility_timer = max;
            }
        }

    }

    public void killcounter(int kill)
    {
        killcounters++;
    }
    public int killreturn()
    {
        return killcounters;
    }

    //TOUCH SCREEN FUNCTIONALITY
    /*-----------MOVEMENT------------------*/
    public void Lseft()
    {
        positionx = -1;
    }
    public void resetx()
    {
        positionx = 0;
    }
    public void right()
    {
        positionx = 1;
    }

    //===========Fight
    public void resetz()
    {
        positionz = 0;
    }
    public void fight()
    {
        positionz = 1;
    }
    //JUMPING
    public void resety()
    {
        positiony = 0;
    }
    public void jump()
    {
        positiony = 1;

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoldoScript : MonoBehaviour
{
    public int health = 5;

    public float speed;

    private float dazedTime;

    Animator voldoAnimator;

    Rigidbody2D voldo_rb2d;

    SpriteRenderer voldoSpriteRenderer;

    bool isRunning = true;

    private Material matWhite;

    private Material matDefault;

    public Transform Target;

    public float attackDistance;

    public float engaugeDistance;

    private bool facingLeft;

    public PlayerController2D hero;

    //Random r = new Random();

    //int lol = r.Next(2);


    //public Transform enemyAttackPos;

    public int increase;
    public int factor;
    public bool aggresive;

    void Start()
    {
        aggresive = false;
        voldoAnimator = GetComponent<Animator>();
        voldo_rb2d = GetComponent<Rigidbody2D>();
        voldoSpriteRenderer = GetComponent<SpriteRenderer>();
        hero = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController2D>();
        Target = GameObject.FindWithTag("Player").transform;
        //matWhite = Resources.Load("WhiteFlash",typeof(Material)) as Material;
        //matDefault = voldoSpriteRenderer.material;
    }

    // Update is called once per frame
    void Update()
    {
        if (aggresive == false && increase <= hero.killreturn())
        {
            aggresive = true;
            health *= 2;
            speed *= (float) 1.5;
            increase *= factor;
            aggresive = false;
            engaugeDistance *= (float)1.6;

        }
        voldoAnimator.SetBool("isIdle", true);
        voldoAnimator.SetBool("isRunning", false);
        voldoAnimator.SetBool("isAttacking", false);
        if(Vector2.Distance(Target.position,this.transform.position) < engaugeDistance)
        {
            voldoAnimator.SetBool("isIdle", false);
            Vector2 Direction = Target.position - this.transform.position;
            if(Mathf.Sign(Direction.x) == 1 && facingLeft)
            {
                Flip();
            }
            else if(Mathf.Sign(Direction.x) == -1 && !facingLeft)
            {
                Flip();
            }
            if(Direction.magnitude >= attackDistance)
            {
                voldoAnimator.SetBool("isRunning",true);
                Debug.DrawLine(Target.transform.position, this.transform.position, Color.yellow);
                if (facingLeft)
                {
                    this.transform.Translate(Vector2.left * (Time.deltaTime * speed));
                }
                else if(!facingLeft)
                {
                    this.transform.Translate(Vector2.right * (Time.deltaTime * speed));
                } 
            }
            if(Direction.magnitude < attackDistance)
            {
                Debug.DrawLine(Target.transform.position, this.transform.position, Color.red);
                voldoAnimator.SetBool("isAttacking", true);
                hero.playerDamage(1);
                Debug.Log("fuck");

            }
        }
        else if(Vector2.Distance(Target.position,this.transform.position) > engaugeDistance)
        {
            Debug.DrawLine(Target.position, this.transform.position, Color.green);
        }
        if (health <= 0)
        {
            //if(this.gameObject != null)
            //{
                hero.killcounter(1);
                Destroy(this.gameObject);
            //}
        }

        /*if()
        voldoAnimator.Play("Voldo_Run");   
        if (dazedTime <= 0)
        {
            speed = 5;
        }
        else
        {
            voldoAnimator.Play("Voldo_Idle");
            voldoSpriteRenderer.material = matWhite;
            speed = 0;
            dazedTime -= Time.deltaTime;
        }
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            voldoSpriteRenderer.material = matDefault;
        }

        voldo_rb2d.velocity = new Vector2(4, voldo_rb2d.velocity.y);
        */
    }
    public void takeDamage(int damage)
    {
        health -=damage;
        Debug.Log("LOL");
    }

    private void Flip()
    {
        facingLeft = !facingLeft;
        Vector2 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}

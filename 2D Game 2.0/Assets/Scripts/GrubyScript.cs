using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrubyScript : MonoBehaviour
{
    public int health = 5;

    public float speed;

    private float dazedTime;
    Animator grubyAnimator;

    Rigidbody2D gruby_rb2d;

    SpriteRenderer grubySpriteRenderer;

    //bool isRunning = true;

    private Material matWhite;

    private Material matDefault;

    public Transform Target;

    public float attackDistance;

    public float engaugeDistance;

    private bool facingLeft;
    public int increase;
    public int factor;
    public bool aggresive;

    public PlayerController2D hero;
    public bool Death = false;



    void Start()
    {
        aggresive = false;
        grubyAnimator = GetComponent<Animator>();
        gruby_rb2d = GetComponent<Rigidbody2D>();
        grubySpriteRenderer = GetComponent<SpriteRenderer>();
        hero = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController2D>();
        Target = GameObject.FindWithTag("Player").transform;
        //Target = 
        //matWhite = Resources.Load("WhiteFlash",typeof(Material)) as Material;
        //matDefault = voldoSpriteRenderer.material;
    }

    // Update is called once per frame
    void Update()
    {
        if(aggresive == false && increase <= hero.killreturn())
        {
            aggresive = true;
            health *= 2;
            speed *= (float) 1.3;
            increase *= factor;
            aggresive = false;
            engaugeDistance *= (float)1.3;
        }
        grubyAnimator.SetBool("isIdle", true);
        grubyAnimator.SetBool("isRunning", false);
        grubyAnimator.SetBool("isAttacking", false);
        if (Vector2.Distance(Target.position, this.transform.position) < engaugeDistance)
        {
            grubyAnimator.SetBool("isIdle", false);
            Vector2 Direction = Target.position - this.transform.position;
            if (Mathf.Sign(Direction.x) == 1 && facingLeft)
            {
                Flip();
            }
            else if (Mathf.Sign(Direction.x) == -1 && !facingLeft)
            {
                Flip();
            }
            if (Direction.magnitude >= attackDistance)
            {
                grubyAnimator.SetBool("isRunning", true);
                Debug.DrawLine(Target.transform.position, this.transform.position, Color.yellow);
                if (facingLeft)
                {
                    this.transform.Translate(Vector2.left * (Time.deltaTime * speed));
                }
                else if (!facingLeft)
                {
                    this.transform.Translate(Vector2.right * (Time.deltaTime * speed));
                }
            }
            if (Direction.magnitude < attackDistance)
            {
                Debug.DrawLine(Target.transform.position, this.transform.position, Color.red);
       
                grubyAnimator.SetBool("isAttacking", true);
                hero.playerDamage(1);
               

            }
        }
        else if (Vector2.Distance(Target.position, this.transform.position) > engaugeDistance)
        {
            Debug.DrawLine(Target.position, this.transform.position, Color.green);
        }
        if (health <= 0 && Death == false)
        {
            //if(this.gameObject != null)
            //{
            Death = true;
                grubyAnimator.Play("Gruby_Death");
            //grubySpriteRenderer.sortingOrder = 0;
            //yield WaitForSeconds(grubyAnimator["Gruby_Death"].length);
             Destroy(gameObject,1.1f);
            
                hero.killcounter(1);
            //}
        }
    }
    public void takeDamage(int damage)
    {
        health -= damage;
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


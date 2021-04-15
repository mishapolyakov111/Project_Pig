using UnityEngine;
using UnityEngine.UI;

public class Pig : Unit

{
   
    public float speedX = 50.0F;
    public float verticalImpulse = 53.0F;
    private float rad = 0.3F;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public int numOfHearts;

    public Image[] hearts;

    Vector3 Right = new Vector3(1f,0f,0f);

    private int jumps = 1; //количество доп прыжков

    private Rigidbody2D rb;
    private Animator animator;

    private bool onGround;
    private bool Alive = true;

    void Start(){
        Application.targetFrameRate = 150;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }

    new void FixedUpdate()
        //вызывается через фиксированный очень маленький промежуток времени
        //проверяется сколько жизней у игрока и наличие земли под ногами игрока
        //результатом является возможность прыжка
    {
        base.FixedUpdate();

        if (Input.GetButton("Horizontal")) Run();
        else animator.SetFloat("Speed", 0);

        if ((hp < 1)&&(Alive))
        {
            animator.SetTrigger("Dead");
            Alive = false;
        }

        Check(); //отвечает за проверку земли под ногами игрока
        if (onGround) jumps = 1;
    }

    private void Update()
        //вызывается каждый кадр
        //проверяет нажата ли кнопки, взаивисимости от чего и проиходит прыжок или бег
   {

        if (Input.GetKeyDown(KeyCode.W) && (onGround || (jumps > 0)))
        {
            Jump(); 
            jumps--;
        }

        //часть кода отвечает за отображение сердечек 
        if (hp > numOfHearts) hp = numOfHearts;

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < numOfHearts) { hearts[i].enabled = true; }
            else { hearts[i].enabled = false; }

            if (i < hp) { hearts[i].sprite = fullHeart; }
            else { hearts[i].sprite = emptyHeart; }
        }
    } 
    private void Run() //отвечает за бег
    {
        animator.SetFloat("Speed", 1);

        Vector3 direction = Right * Input.GetAxis("Horizontal");
        
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speedX * Time.deltaTime);
        if ((direction.x * transform.right.x < 0f)) transform.Rotate(0f, 180f, 0f);
        //если направление движения не совпадает с направлением игрока, то нужно повернуть игрока

    }

   
    private void Jump()//прыжок
    {      
        rb.AddForce(transform.up * verticalImpulse, ForceMode2D.Impulse);
    }

    private void Check()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, rad);
        onGround = colliders.Length > 1;
        //если количество коллайдеров около ног игрока больше 1, то можно прыгать
        animator.SetBool("IsJumping", !onGround);
    }

    public override void Damage() 
        //когда игрока бьют, он немного отлетает, а не просто стоит на месте
    {
        base.Damage();

        rb.velocity = Vector3.zero;
        rb.AddForce(transform.up * 50.0F, ForceMode2D.Impulse);
        rb.AddForce(transform.right * -Input.GetAxis("Horizontal") * 10.0F, ForceMode2D.Impulse);
    }


}

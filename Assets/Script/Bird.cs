using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public float upForce;                       //Upward force of the "flap".
    private bool isDead = false;            //Has the player collided with a wall?
    private Rigidbody2D rb2d;
    private Animator anim;
    public int maxHealth = 10;
    public int health { get { return currentHealth; } }   // Define a Property
    int currentHealth = 0;
    public AudioClip jmp; //재생할 소리를 변수로 담습니다.
    AudioSource myAudio; //AudioSorce 컴포넌트를 변수로 담습니다.
    public static Bird instance;  //자기자신을 변수로 담습니다.
    void Awake() //Start보다도 먼저, 객체가 생성될때 호출됩니다
    {
        if (Bird.instance == null) //incetance가 비어있는지 검사합니다.
        {
            Bird.instance = this; //자기자신을 담습니다.
        }
    }
  
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentHealth = 0;
        myAudio = this.gameObject.GetComponent<AudioSource>(); //AudioSource 오브젝트를 변수로 담습니다.

    }

    // Update is called once per frame
    void Update()
    {
   
        if (currentHealth < 0)
        {
            rb2d.velocity = Vector2.zero;
            isDead = true;
            anim.SetTrigger("Die");
            GameControl.instance.BirdDied();
        }
        if (isDead == false) // 죽지 않으면 실행 // 죽으면 눌러도 안됨
        {
            GameControl.instance.BirdScored();

            if (Input.GetMouseButtonDown(1))//좌클릭시
            {
                //rb2d.velocity = new Vector2(1,0);  //vector2(2차원)
                rb2d.velocity = Vector2.zero;
                rb2d.AddForce(new Vector2(0, upForce)); //힘추가 ( upForce위로 힘 증가)= > 올라가는 효과ㅣ
                anim.SetTrigger("Jump");
                myAudio.PlayOneShot(jmp);
            }
            if (Input.GetMouseButton(0))
            {
                rb2d.velocity = Vector2.zero;
                rb2d.AddForce(new Vector2(0, (upForce * -1)) / 2);
                anim.SetTrigger("Eat");

            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                rb2d.velocity = Vector2.zero;
                rb2d.AddForce(new Vector2(200, 0));
            }
            //if (Input.GetMouseButtonUp(0))
            //{
            //    rb2d.velocity = new Vector2(2, 0);
            //}

        }

    }
    public void ChangeHealth(int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, -1, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
    }
   

}



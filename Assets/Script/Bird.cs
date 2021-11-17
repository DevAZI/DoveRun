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
    public AudioClip jmp; //����� �Ҹ��� ������ ����ϴ�.
    AudioSource myAudio; //AudioSorce ������Ʈ�� ������ ����ϴ�.
    public static Bird instance;  //�ڱ��ڽ��� ������ ����ϴ�.
    void Awake() //Start���ٵ� ����, ��ü�� �����ɶ� ȣ��˴ϴ�
    {
        if (Bird.instance == null) //incetance�� ����ִ��� �˻��մϴ�.
        {
            Bird.instance = this; //�ڱ��ڽ��� ����ϴ�.
        }
    }
  
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentHealth = 0;
        myAudio = this.gameObject.GetComponent<AudioSource>(); //AudioSource ������Ʈ�� ������ ����ϴ�.

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
        if (isDead == false) // ���� ������ ���� // ������ ������ �ȵ�
        {
            GameControl.instance.BirdScored();

            if (Input.GetMouseButtonDown(1))//��Ŭ����
            {
                //rb2d.velocity = new Vector2(1,0);  //vector2(2����)
                rb2d.velocity = Vector2.zero;
                rb2d.AddForce(new Vector2(0, upForce)); //���߰� ( upForce���� �� ����)= > �ö󰡴� ȿ����
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



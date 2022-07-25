using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public bool lookLeft;// indica se o player está virado pra esquerda

	public int idAnimation;//Controla qual animação usar

	public bool grounded;//Verifica se estar no chão

	public Transform groundCheck;//Cria ojeto para verififcar o chão

	public LayerMask whatIsGround; // configura as layers que tem surpefície

	public float speed;//Velocidade de movimento do personagem

	public float jumpForce; //Força do Pulo

	private Rigidbody2D playerBody;

	private Animator playerAnimation;//Controla o Animator

	private float h,v;//H-> Horizontal; V-> Vertical

    private bool isDoubleJump;
    private bool isJumping;
    private GameController gameController;


    // Start is called before the first frame update
    void Start()
    {
			playerAnimation = GetComponent<Animator> ();
			playerBody = GetComponent<Rigidbody2D> ();
			gameController = FindObjectOfType<GameController>() as GameController;
    }

    void FixedUpdate()
	{
        grounded = Physics2D.OverlapCircle(groundCheck.position, 0.02f, whatIsGround);
        playerBody.velocity = new Vector2(h * speed, playerBody.velocity.y);	
	}

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxisRaw ("Horizontal");
	    v= Input.GetAxisRaw("Vertical");

		if (h > 0 && lookLeft) {
			flip ();
		} else if(h<0 && !lookLeft) {
			flip ();
		}

        if (h != 0) {
			idAnimation = 1;

		} else {
			idAnimation = 0;
		}

        if(Input.GetButtonDown("Jump")){
            if(!isJumping&&grounded){
                playerBody.AddForce (new Vector2 (0,jumpForce), ForceMode2D.Impulse);
                isDoubleJump=!isDoubleJump;
            }else if(isDoubleJump){
                playerBody.AddForce (new Vector2 (0,jumpForce), ForceMode2D.Impulse);
                isDoubleJump=!isDoubleJump;
                idAnimation = 2;
            }
        }

        playerAnimation.SetBool ("grounded",grounded);
				playerAnimation.SetInteger ("idAnimation",idAnimation);
    }


    void flip(){
			lookLeft = !lookLeft;//Inverte Valor da Variavel
			float x= transform.localScale.x;
			x *= -1;
			transform.localScale = new Vector3 (x,transform.localScale.y,transform.localScale.z);//Altera o Scale
		}

		private void OnTriggerEnter2D(Collider2D other) {
			if(other.gameObject.tag.Equals("colectable")){
					other.gameObject.GetComponent<ItemController>().colectItem();
			}
		}

		private void OnCollisionEnter2D(Collision2D other) {
			 if(other.gameObject.tag.Equals("spike")){
            Destroy(gameObject);
						gameController.gameOver();
        }
		}
		
}

using UnityEngine;
using System.Collections;

public class Player1 : Character 
{	
	public Character[] players;
	
	// Use this for initialization
	public override void Start () 
	{
		base.Start();
		
		spawnPos = thisTransform.position;
	}
	
	// Update is called once per frame
	public void Update () 
	{
		// these are false unless one of keys is pressed
		isLeft = false;
		isRight = false;
		isJump = false;
		isPass = false;
		
		movingDir = moving.None;

        /*
        // ���� ��ġ�Ǿ� �ִ� ī��Ʈ ��������
        int cnt = Input.touchCount;

        //Debug.Log("touch Cnt : " + cnt);

        // ���ÿ� �������� ��ġ �� �� �ֱ� ����.
        for (int i = 0; i < cnt; ++i)
        {
            // i ��°�� ��ġ�� �� �̶�� ���� �ȴ�. 
            Touch touch = Input.GetTouch(i);
            Vector2 pos = touch.position;

            Debug.Log("touch(" + i + ") : x = " + pos.x + ", y = " + pos.y);
        }
        */

        /* ȭ�� ��ġ�� �����̱�
        if (Input.GetMouseButton(0) == true)
        {
            Vector3 pos1 = Input.mousePosition;


            int i32Width  = Screen.width/2;
            int i32Height = Screen.height/3;

            //Debug.Log("width = " + i32Width + ", height = " + i32Height);

            if (pos1.x > i32Width)
            {
                isRight = true;
                facingDir = facing.Right;
            }
            if (pos1.x <= i32Width)
            {
                isLeft = true;
                facingDir = facing.Left;
            }
            if (pos1.y > i32Height)
            {
                isJump = true; 
            }
            //Debug.Log("touch(" + 0 + ") : x = " + pos1.x + ", y = " + pos1.y);
        }
        */
        //��ư���� �����̱� 
        if ( xa.buttonType == xa.ButtonType.left)
        {
            isLeft = true;
            facingDir = facing.Left;
        }

        if (xa.buttonType == xa.ButtonType.right && isLeft == false)
        {
            isRight = true;
            facingDir = facing.Right;
        }

        if (xa.buttonType == xa.ButtonType.jump)
        {
            isJump = true;
        }


		// keyboard input
		if(Input.GetKey(KeyCode.A)) 
		{ 
			isLeft = true; 
			facingDir = facing.Left;
		}
		if (Input.GetKey(KeyCode.D) && isLeft == false) 
		{ 
			isRight = true; 
			facingDir = facing.Right;
		}
		
		if (Input.GetKeyDown(KeyCode.W)) 
		{ 
			isJump = true; 
		}
		
		if(Input.GetKeyDown(KeyCode.S))
		{
			isPass = true;
		}
		
		if(Input.GetKeyDown(KeyCode.R))
		{
			ResetBall();
		}
		
		if(Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.T))
		{
			//print ("reload level");
			Application.LoadLevel(0);
		}
		
		if(Input.GetKeyDown(KeyCode.Alpha2))
		{
			players[0].HideMe();
			players[1].HideMe();
		}
		
		if(Input.GetKeyDown(KeyCode.Alpha3))
		{
			players[0].ShowMe();
			players[1].HideMe();
		}
		if(Input.GetKeyDown(KeyCode.Alpha4))
		{
			players[0].ShowMe();
			players[1].ShowMe();
		}
		
		UpdateMovement();
	}
	
	void OnTriggerEnter(Collider other)
	{
        /*
		if (other.gameObject.CompareTag("Ball"))
		{
			PickUpBall();
		}
         */
	}
	
	public void Respawn()
	{
		if(alive == true)
		{
			thisTransform.position = spawnPos;
			hasBall = false;
			rayDistUp = 0.375f;
		}
	}
}

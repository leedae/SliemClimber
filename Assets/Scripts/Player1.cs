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
        // 현재 터치되어 있는 카운트 가져오기
        int cnt = Input.touchCount;

        //Debug.Log("touch Cnt : " + cnt);

        // 동시에 여러곳을 터치 할 수 있기 때문.
        for (int i = 0; i < cnt; ++i)
        {
            // i 번째로 터치된 값 이라고 보면 된다. 
            Touch touch = Input.GetTouch(i);
            Vector2 pos = touch.position;

            Debug.Log("touch(" + i + ") : x = " + pos.x + ", y = " + pos.y);
        }
        */

        /* 화면 터치로 움직이기
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
        //버튼으로 움직이기 
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

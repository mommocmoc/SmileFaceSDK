using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FaceControlSDK;
using UnityEngine.Serialization;
using UnityEngine.UI;


public class FaceControllerExample : MonoBehaviour
{
    
    [SerializeField] public bool faceControlMode = true;
    [SerializeField] private FaceInterface faceInterface;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float moveSpeed = 40f; 

    private void Start()
    {
        Initialization();
    }

    void Update()
    {
        //Face Interface 값 받아서 컨트롤러 코드 짤 때 사용할 수 있는 기본 틀입니다.
        //컨트롤러용 값 조정
        float horizonClamVal = Mathf.Clamp(faceInterface.headRoll,1.0f,-1.0f);
        float middleHeadRoll = 4;
        float pitchRad = faceInterface.headPitch * Mathf.Deg2Rad;
        float sinVal = Mathf.Sin(pitchRad);
        float verticalClamVal = Mathf.Clamp(sinVal, -0.3f, 1);

        if (faceControlMode && faceInterface.isFaceAnalyzerOn && faceInterface.probExpDict.Count > 0)
        {
            //고개가 가운데 있을 때
            if (faceInterface.headRoll < middleHeadRoll && faceInterface.headRoll > -middleHeadRoll)
            {
                //"Stop"
                moveStop();
            }

            //고개 왼쪽으로 꺽을 때 
            if (horizonClamVal <-0.2)
            {
                //"Left"
                moveLeft();
            }
            //고개 오른쪽으로 꺽을 때 
            else if(horizonClamVal > 0.2)
            {
                //Do Something "Right";
                moveRight();
            }
            
            //고개 아래로 할 때
            if (verticalClamVal <0)
            {
                //Do Something "Down";
                moveDown();
            }
            else
            {
                //Do Something "Up";
                moveUp();
            }

            //감정 표현 값이 0.9 이상이면 오브젝트에 무엇인가 하기["surprise",
            if (faceInterface.probExpDict["happy"] > 0.9)
            {
                //Do Something
                jump();
            }
             
            if ( faceInterface.probExpDict["surprise"] > 0.9)
            {
                //Do Something
                fire();
            }

        }

    }
    protected virtual void Initialization()
    {
        faceInterface = GameObject.Find("SmileFaceAnalyzerSDK").GetComponent<FaceInterface>();
        _rigidbody = this.GetComponent <Rigidbody2D>();
    }

    public void faceControlOn()
    {
        faceControlMode = true;
    }

    public void faceContolOff()
    {
        faceControlMode = false;
    }

    void moveLeft()
    {
        _rigidbody.velocity = new Vector2(-moveSpeed, _rigidbody.velocity.y);
    }

    void moveRight()
    {
        _rigidbody.velocity = new Vector2(+moveSpeed, _rigidbody.velocity.y);
    }

    void moveStop()
    {
        _rigidbody.velocity = new Vector2(0, _rigidbody.velocity.y);
    }
    
    void moveUp()
    {
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, moveSpeed);
    }
    
    void moveDown()
    {
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x,-moveSpeed);
    }

    void jump()
    {
        
    }

    void fire()
    {
        
    }
}

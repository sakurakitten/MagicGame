using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.U2D;

public class chanter: MonoBehaviour {
	GameObject lineObj;
	SpriteRenderer mysprite;
	public Sprite Normalchanter;
    public Sprite Holdchanter;
	// Use this for initialization
	void Start () {
		lineObj = GameObject.Find( "line" );
		mysprite = gameObject.GetComponent<SpriteRenderer>();
		//Normalchanter= Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);
		//Holdchanter= Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);
	}
	//スマホ向け そのオブジェクトがタッチされていたらtrue（マルチタップ対応）
    bool OnTouchDown() {
        // タッチされているとき
        if( 0 < Input.touchCount){
            // タッチされている指の数だけ処理
            for(int i = 0; i < Input.touchCount; i++){
                // タッチ情報をコピー
                Touch t = Input.GetTouch(i);
				Vector2 vec =t.position;
				vec = Camera.main.ScreenToWorldPoint (vec);
                // タッチしたときかどうか
                if(t.phase == TouchPhase.Began ){
					if(System.Math.Abs(transform.position.x-vec.x)<0.5f&&System.Math.Abs(transform.position.y-vec.y)<0.5f){
						return true;
					}
                }
            }
        }
        return false; //タッチされてなかったらfalse
    }
	//PC向け そのオブジェクト上でクリックが始まったらtrue（マルチタップ対応）
	bool  OnMouseDown() {
		Vector2 vec = Input.mousePosition;
		vec = Camera.main.ScreenToWorldPoint (vec);
		// タッチしたときかどうか
		if(Input.GetMouseButtonDown(0)){
			if(System.Math.Abs(transform.position.x-vec.x)<0.5f&&System.Math.Abs(transform.position.y-vec.y)<0.5f){
				print("そのオブジェクト上でクリックが始まった");
				Debug.Log("そのオブジェクト上でクリックが始まった");
				return true;
			}
		}
        return false; //タッチされてなかったらfalse
    }
	//スマホ向け　ドラッグしながら触れられたか
	bool OnDragOver() {
        // タッチされているとき
        if( 0 < Input.touchCount){
            // タッチされている指の数だけ処理
            for(int i = 0; i < Input.touchCount; i++){
                // タッチ情報をコピー
                Touch t = Input.GetTouch(i);
				Vector2 vec =t.position;
				vec = Camera.main.ScreenToWorldPoint (vec);
                if(t.phase == TouchPhase.Moved ){
					if(System.Math.Abs(transform.position.x-vec.x)<0.5f&&System.Math.Abs(transform.position.y-vec.y)<0.5f){
						
						return true;
					}
                }
            }
        }
        return false; //タッチされてなかったらfalse
    }
	//PC向け　ドラッグしながら触れられたか
	bool OnMouseEnter(){
		if(Input.GetMouseButton(0)==true){
			Vector2 vec = Input.mousePosition;
			vec = Camera.main.ScreenToWorldPoint(vec);
			if(System.Math.Abs(transform.position.x-vec.x)<0.5f&&System.Math.Abs(transform.position.y-vec.y)<0.5f){
				print("ドラッグしながら触れられたか");
				Debug.Log("ドラッグしながら触れられたか");
				return true;
			}
		}
		Debug.Log("ドラッグしながら触れられてない");
        return false; //タッチされてなかったらfalse
    }
	// Update is called once per frame
	void Update () {
		if(OnTouchDown()==true){
			line linecomp = lineObj.GetComponent<line>();
			linecomp.startdrawline(transform.position);
		}
		if( OnMouseDown()==true){
			print("ドラッグしながら触れられたか");
			line linecomp = lineObj.GetComponent<line>();
			linecomp.startdrawlinePC(transform.position);
		}
		if(OnDragOver()==true ){
			line linecomp=lineObj.GetComponent<line>();
			linecomp.makeTurningPoint(transform.position);
		}
		if(OnMouseEnter()==true){
			print("ドラッグしながら触れられたか");
			line linecomp = lineObj.GetComponent<line>();
			linecomp.makeTurningPointPC(transform.position);
		}
	}
    
	
}

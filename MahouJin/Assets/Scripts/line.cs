using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class line : MonoBehaviour {
	private int lineswitch=0;
	
	// Use this for initialization
	
	private List<Vector2> vecs = new List<Vector2>();
	void Start () {
		
	}
	public void startdrawline(Vector2 chantervec){
		lineswitch=1;
		if(vecs.Count>0){vecs.Clear();}
		vecs.Add(chantervec);
		Touch touch= Input.GetTouch(0);
		Vector2 touchvec = Camera.main.ScreenToWorldPoint (touch.position);
		vecs.Add(touchvec);
	}
	public void startdrawlinePC(Vector2 chantervec){
		lineswitch=1;
		if(vecs.Count>0){vecs.Clear();}
		vecs.Add(chantervec);
		Vector2 touchvec = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		vecs.Add(touchvec);
	}
	public void enddrawline(){
		lineswitch=0;
	}
	public void enddrawlinePC(){
		lineswitch=0;
	}
	public void makeTurningPoint(Vector2 chantervec){
		if(vecs[vecs.Count-2]==chantervec){

		}else{
			vecs[vecs.Count-1]=chantervec;
			Touch touch= Input.GetTouch(0);
			Vector2 touchvec = Camera.main.ScreenToWorldPoint (touch.position);
			vecs.Add(touchvec);
		}
	}
	public void makeTurningPointPC(Vector2 chantervec){
		if(vecs[vecs.Count-2]==chantervec){

		}else{
			vecs[vecs.Count-1]=chantervec;
			Vector2 touchvec = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			vecs.Add(touchvec);
		}
	}
	
	// Update is called once per frame
	void Update () {
		//Smartphone
		if(lineswitch==1 && Input.touchCount>0){
			LineRenderer　linerenderer = GetComponent<LineRenderer>();
			linerenderer.sortingLayerName="players";
			// 線の幅
			linerenderer.SetWidth(0.1f, 0.1f);
			// 頂点の数
			linerenderer.SetVertexCount(vecs.Count);
			Touch touch= Input.GetTouch(0);
			Vector2 touchvec = Camera.main.ScreenToWorldPoint (touch.position);
			if(touch.phase == TouchPhase.Began)
			{
				//mysprite.sprite = Holdchanter;
				// タッチ開始
			}
			else if (touch.phase == TouchPhase.Moved)
			{
				// 頂点を設定
				
				vecs[vecs.Count-1]=touchvec;
				for(int i=0;i<vecs.Count;i++){
					linerenderer.SetPosition(i,vecs[i]);
				}
				// タッチ移動
			}
			else if (touch.phase == TouchPhase.Ended)
			{
				linerenderer.SetVertexCount(0);
				vecs.Clear();
				enddrawlinePC();
				//mysprite.sprite = Normalchanter;
			}
		}
		//PC
		if(lineswitch==1 ){
			LineRenderer　linerenderer = GetComponent<LineRenderer>();
			linerenderer.sortingLayerName="players";
			// 線の幅
			linerenderer.SetWidth(0.1f, 0.1f);
			// 頂点の数
			linerenderer.SetVertexCount(vecs.Count);
			Vector2 touchvec = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			if(Input.GetMouseButtonDown(0))
			{
				//mysprite.sprite = Holdchanter;
				// タッチ開始
			}
			else if (Input.GetMouseButton(0))
			{
				// 頂点を設定
				
				vecs[vecs.Count-1]=touchvec;
				for(int i=0;i<vecs.Count;i++){
					linerenderer.SetPosition(i,vecs[i]);
				}
				// タッチ移動
			}
			else if (Input.GetMouseButtonUp(0))
			{
				linerenderer.SetVertexCount(0);
				vecs.Clear();
				enddrawlinePC();
				//mysprite.sprite = Normalchanter;
			}
		}
	}
}

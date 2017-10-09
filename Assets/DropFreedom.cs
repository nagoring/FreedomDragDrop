using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropFreedom : MonoBehaviour ,IDropHandler, IPointerEnterHandler, IPointerExitHandler{


	public void OnPointerEnter(PointerEventData eventData)
	{
		if(eventData.pointerDrag == null) return;
		eventData.pointerDrag.transform.SetAsLastSibling();
	}
	public void OnDrop(PointerEventData eventData)
	{
		
//		Debug.Log("aaaaaaaaaaaaaaaaaaaaaaaaa");
//		Debug.Log("s:" + eventData.pointerDrag.transform.position.x + ":" + eventData.pointerDrag.transform.position.y);
//		Vector3 worldPos = ScreenToWorld(eventData.pointerDrag.transform.position.x, eventData.pointerDrag.transform.position.y);
//		Debug.Log("w:" + worldPos.x + ":" + worldPos.y);
//		Vector3 beginVector3 = new Vector3(ItemManager.instance.beginDragItemPosition.x, ItemManager.instance.beginDragItemPosition.y);
//		transform.localPosition.x = ItemManager.instance.beginDragItemPosition.x;
//		transform.localPosition.y = ItemManager.instance.beginDragItemPosition.y;

		
		eventData.pointerDrag.transform.SetParent(transform);
		eventData.pointerDrag.transform.SetAsLastSibling();
		
		

		ItemManager itemManager = ItemManager.instance;
		itemManager.SyncUi();
	}
	public void OnPointerExit(PointerEventData eventData)
	{
		if(eventData.pointerDrag == null) return;
	}
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

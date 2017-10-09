using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragFreedom : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
	private GameObject canvas;
	// Drag開始位置
	private Vector3 beginDragVector3;
	void Start () {
		gameObject.AddComponent<CanvasGroup>();
		canvas = GameObject.FindWithTag("CanvasFreedom");
	}

	public void OnBeginDrag(PointerEventData eventData)
	{
		
		transform.SetParent(canvas.transform);
		transform.SetAsLastSibling();
		transform.localScale = Vector3.one;
		CanvasGroup canvasGroup = gameObject.GetComponent<CanvasGroup>();
		canvasGroup.blocksRaycasts = false;

		beginDragVector3 = new Vector3(transform.position.x, transform.position.y);
	}
	

	public void OnDrag(PointerEventData eventData)
	{
		//ワールド座標変換で座標を操作
		transform.position = ScreenToWorld(eventData.position.x,eventData.position.y);
	}

	private Vector3 ScreenToWorld(float screenX, float screenY)
	{
		Vector3 selfScreenPosition = Camera.main.WorldToScreenPoint(transform.position);
		Vector3 pointInScreen = new Vector3(screenX,screenY, selfScreenPosition.z);
		return Camera.main.ScreenToWorldPoint(pointInScreen);
	}
	public void OnEndDrag(PointerEventData eventData)
	{
		//ドラッグを離したときに元の座標に戻す
		if (IsOutOfArea(eventData.position.x, eventData.position.y))
		{
			transform.position = beginDragVector3;
		}
	
		CanvasGroup canvasGroup = gameObject.GetComponent<CanvasGroup>();
		canvasGroup.blocksRaycasts = true;
	}

	private Boolean IsOutOfArea(float postionX, float postionY)
	{
		ItemManager itemManger = ItemManager.instance;
		RectTransform imageBagRectTransform = itemManger.imageBag.GetComponent<RectTransform>();
		//canvasの横幅、縦幅
		float imageBagWidth = imageBagRectTransform.sizeDelta.x;
		float imageBagHeight = imageBagRectTransform.sizeDelta.y;
		
		//ステータスエリアに侵入した場合は許可しない
		if (postionX > imageBagWidth) return true;
		
		//画面範囲外に行った場合は許可しない
		if (postionX < 0) return true;
		if (postionY < 0) return true;
		if (postionY > imageBagHeight) return true;
		
		return false;
	}
}

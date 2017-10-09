using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour {
	public static ItemManager instance;
	//ImageBagのオブジェクトを関連付けさせます
	public GameObject imageBag;
	//imageEqptのオブジェクトを関連付けさせます
	public GameObject imageEqpt;
	//TextBagNumberのオブジェクトを関連付けさせます
	public Text textBagNumber;
	//TextEqptNumberのオブジェクトを関連付けさせます
	public Text textEqptNumber;
	//Bagに入っているitemの数です
	private int bagItemNumber = 0;
	//Eqptに入っているitemの数です。
	private int eqptItemNumber = 0;
	void Awake ()
	{
		if (instance == null)
		{
			instance = this;
		}
		else if (instance != this)
		{
			Destroy (gameObject);
		}
	}
	void Start ()
	{
		SyncUi();
	}

	public void SyncUi()
	{
		Image[] bagImages = imageBag.GetComponentsInChildren<Image>();
		int bagIndex = 0;
		foreach (Image image in bagImages)
		{
			if (imageBag.name == image.name) continue;
			bagIndex++;
		}
		bagItemNumber = bagIndex;
		textBagNumber.text = bagItemNumber.ToString();
		if (imageEqpt == null) return;
		Image[] eqptImages = imageEqpt.GetComponentsInChildren<Image>();
		int eqptIndex = 0;
		foreach (Image image in eqptImages)
		{
			if (imageEqpt.name == image.name) continue;
			eqptIndex++;
		}
		eqptItemNumber = eqptIndex;
		textEqptNumber.text = eqptItemNumber.ToString();
	}		
}



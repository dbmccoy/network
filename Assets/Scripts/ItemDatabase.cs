﻿using UnityEngine;
using System.Collections;
using LitJson;
using System.Collections.Generic;
using System.IO;

public class ItemDatabase : MonoBehaviour {
	private List<Item> database = new List<Item>();
	private JsonData itemData;

	void Start(){
		itemData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/StreamingAssets/Items.json"));
		ConstructItemDatabase();
		Debug.Log(FetchItemByID(0).Title);
	}



	void ConstructItemDatabase(){
		for (int i = 0; i < itemData.Count; i++) {
			database.Add(new Item((int)itemData[i]["id"]
								, itemData[i]["title"].ToString()
								, (int)itemData[i]["size"]
								, (bool)itemData[i]["stackable"]
								, itemData[i]["slug"].ToString()));
		}
	}

	public Item FetchItemByID(int id){
		for (int i = 0; i < database.Count; i++) {
			if(database[i].ID == id){
				return database[i];
			}
		}
		return null;
	}

	public Item FetchItemBySlug(string slug){
		for (int i = 0; i < database.Count; i++) {
			if(database[i].Slug == slug){
				return database[i];
			}
		}
		return null;
	}
}

public class Item {
	public int ID {get; set;}
	public string Title {get; set;}
	public int Size {get; set;}
	public bool Stackable {get; set;}
	public string Slug {get; set;}
	public Sprite Sprite {get; set;}

	public Item(){
		this.ID = -1;
	}

	public Item(int id, string title, int size, bool stackable, string slug){
		this.ID = id;
		this.Title = title;
		this.Size = size;
		this.Stackable = stackable;
		this.Slug = slug;
		this.Sprite = Resources.Load<Sprite>("Sprites/Items/"+slug);
	}
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {
	GameObject inventoryPanel;
	GameObject slotPanel;
	ItemDatabase database;
	public GameObject inventorySlot;
	public GameObject inventoryItem;

	int slotAmount;
	public List<Item> items = new List<Item>();
	public List<GameObject> slots = new List<GameObject>();

	void Start(){
		slotAmount = 20;
		inventoryPanel = transform.FindChild("UI").FindChild("Inventory").gameObject;
		slotPanel = inventoryPanel.transform.FindChild("slot_panel").gameObject;
		database = GameObject.Find("GameController").GetComponent<ItemDatabase>();

		for (int i = 0; i < slotAmount; i++) {
			items.Add(new Item());
			slots.Add(Instantiate(inventorySlot));
			slots[i].transform.SetParent(slotPanel.transform);
			slots[i].GetComponent<slot>().id = i;
		}

		AddItem(0);
		AddItem(1);
		AddItem(1);
		AddItem(1);
		AddItem(1);
		AddItem(1);
		AddItem(1);
	}

	public void AddItem(int id){
		Item itemToAdd = database.FetchItemByID(id);

		if(itemToAdd.Stackable && CheckIfItemInInventory(itemToAdd)){
			for (int i = 0; i < items.Count; i++) {
				if(items[i].ID == id){
					ItemData data = slots[i].transform.GetChild(0).GetComponent<ItemData>();
					data.amount++;
					data.transform.GetChild(0).GetComponent<Text>().text = data.amount.ToString();
					break;
				}
			}
		}
		else{
		for (int i = 0; i < items.Count; i++) {
			if(items[i].ID == -1){
				items[i] = itemToAdd;
				GameObject itemObject = Instantiate(inventoryItem);
				itemObject.GetComponent<ItemData>().item = itemToAdd;
				itemObject.GetComponent<ItemData>().slot = i;
				itemObject.transform.SetParent(slots[i].transform);
				itemObject.transform.position = Vector2.zero;
				itemObject.GetComponent<Image>().sprite = itemToAdd.Sprite;
				itemObject.name = itemToAdd.Title;
				Debug.Log("added "+itemToAdd.Title);
				return;
			}
		}
		}
	}

	public void OpenInv(){}

	bool CheckIfItemInInventory(Item item){
		for (int i = 0; i < items.Count; i++) {
			if(items[i].ID == item.ID){
				return true;
			}
		}
		return false;
	}
}

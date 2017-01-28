using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class slot : MonoBehaviour, IDropHandler {
	public int id;
	private Inventory inv;

	void Start(){
		inv = GameObject.Find("Inventory").GetComponent<Inventory>();
	}

	public void OnDrop(PointerEventData eventData){
		ItemData droppedItem = eventData.pointerDrag.GetComponent<ItemData>();
		if(inv.items[id].ID == -1){
			droppedItem.transform.SetParent(this.transform);
			droppedItem.transform.position = this.transform.position;
		}
	}
}

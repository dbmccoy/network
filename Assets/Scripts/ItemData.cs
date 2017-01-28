using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class ItemData : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler{
	public Item item;
	public int amount;
	public int slot;
	private Inventory inv;

	Transform original_parent;
	Vector2 offset;

	void Start(){
		inv = transform.parent.parent.parent.GetComponent<Inventory>();
	}

	public void OnBeginDrag(PointerEventData eventData){
		if(item != null){
			original_parent = this.transform.parent;
			offset = eventData.position - new Vector2(this.transform.position.x,this.transform.position.y);
			this.transform.SetParent(this.transform.parent.parent);
			this.transform.position = eventData.position - offset;
			GetComponent<CanvasGroup>().blocksRaycasts = false;
		}
	}

	public void OnDrag(PointerEventData eventData){
		if(item != null){
			this.transform.position = eventData.position - offset;
		}
	}

	public void OnEndDrag(PointerEventData eventData){
		if(item != null){
			this.transform.SetParent(original_parent);
			this.transform.position = original_parent.position;
			GetComponent<CanvasGroup>().blocksRaycasts = true;

		}
	}
}

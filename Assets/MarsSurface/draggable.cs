using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

	public static GameObject itemDragged = null;
	public GameObject MegaStructure;
	public GameObject MegaStructurePrefab;

	public void OnBeginDrag (PointerEventData eventData)
	{
		print ("BeginDrag");
		MegaStructure = Instantiate (MegaStructurePrefab, gameObject.transform.position, gameObject.transform.rotation) as GameObject;
		draggable.itemDragged = MegaStructure;
		//draggable.itemDragged = gameObject;
	}
	public void OnDrag (PointerEventData eventData)
	{
		MegaStructure.transform.position = eventData.position;
	}
	public void OnEndDrag (PointerEventData eventData)
	{
		draggable.itemDragged = null;
	}
}


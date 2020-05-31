using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ChangeForm : MonoBehaviour
{
	public List<GameObject> ObjectList;

	public bool isDisguised;
	public UnityEvent OnDisguisedAction, OnReveledAction;
	public Transform player;
	public float changeDistance = 2;

	float curDistanceFromPlayer { get { return Vector3.Distance(player.transform.position, transform.position); } }
	GameObject spawnedObject;

	void Update()
    {
		if (curDistanceFromPlayer < changeDistance && isDisguised)
		{
			OnReveledAction.Invoke();
		}
    }

	public void Disguise()
	{
		OnDisguisedAction.Invoke();
		isDisguised = true;
	}

	public void Reveal()
	{
		OnReveledAction.Invoke();
		isDisguised = false;
	}

	public void ChooseAndSpawnObject()
	{
		int randomNumber = Random.Range(0, ObjectList.Count);
		spawnedObject = Instantiate(ObjectList[randomNumber], transform);
		spawnedObject.transform.localPosition = Vector3.zero;
		spawnedObject.transform.localRotation = Quaternion.identity;
	}

	public void DespawnObject()
	{
		if (spawnedObject != null)
		{
			Destroy(spawnedObject);
		}
	}

	public void SetRevealed(bool isRevealed)
	{
		isDisguised = !isRevealed;
	}
}

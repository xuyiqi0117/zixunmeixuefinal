using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour {

	[SerializeField] private GameObject[] items;
	[SerializeField] private GameObject[] itemGeneratePoints;
	private int numberOfItemsGenerate;

	private bool isGenerated = false;

	void Awake () {
		isGenerated = false;
		numberOfItemsGenerate = Random.Range (0, itemGeneratePoints.Length);
	}

	public void OnTriggerEnter(Collider other) {
		if (! isGenerated && other.CompareTag ("Player")) {
			HandleItemGeneration ();
		}
	}

	private void HandleItemGeneration () {
		numberOfItemsGenerate = Random.Range (0, itemGeneratePoints.Length);	
		for (int i = 0; i < numberOfItemsGenerate; i++) {
			//what item we should generate
			int itemType = Random.Range(0, items.Length);
			GameObject item = items[itemType];
			//generate item from generate point 0
			Instantiate (item, itemGeneratePoints[i].transform.position, Quaternion.Euler(new Vector3(0 ,90, 0)));
		}
		isGenerated = true;
	}
}

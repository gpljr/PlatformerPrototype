using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {
	[SerializeField] Sprite openDoor;
	[SerializeField] AudioClip clip;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerStay2D(Collider2D other){
		if(other!= null && other.gameObject.tag=="Player")
		{
			gameObject.GetComponent<SpriteRenderer>().sprite=openDoor;
			AudioSource.PlayClipAtPoint(clip, transform.position);
			StartCoroutine( WaitForOpenDoor());
		}
	}
	IEnumerator WaitForOpenDoor()
	{
		yield return new WaitForSeconds(0.7f);
		Application.LoadLevel(Application.loadedLevel+1);
	}
}

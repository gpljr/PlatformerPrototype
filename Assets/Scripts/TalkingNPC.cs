using UnityEngine;
using System.Collections;

public class TalkingNPC : MonoBehaviour {
	[SerializeField] GameObject Hi;
	// Use this for initialization
	void Start () {
		Hi.SetActive(false);
	}
	
	void OnTriggerEnter2D(Collider2D other){
		if(other!=null && other.gameObject.tag=="Player")
		{
			Hi.SetActive(true);
		}
	}
	void OnTriggerExit2D(Collider2D other){
		if(other!=null && other.gameObject.tag=="Player")
		{
			Hi.SetActive(false);
		}
	}
	
}

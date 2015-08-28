using UnityEngine;
using System.Collections;

public class CutTree : MonoBehaviour {
    [SerializeField] bool canCutTree;
    [SerializeField] Sprite normal;
    [SerializeField] Sprite cutting;
    GameObject target;
    // Use this for initialization
    void Start () {
	
    }
	
    // Update is called once per frame
    void Update () {
        if (canCutTree) {
            gameObject.GetComponent<SpriteRenderer>().sprite = cutting;
            if (Input.GetKeyDown(KeyCode.Return)) {
                target.GetComponent<Tree>().CutDown();
                print("cut");
            }
        } else {
            gameObject.GetComponent<SpriteRenderer>().sprite = normal;
        }
    }
    void OnTriggerEnter2D (Collider2D other) {
        if (other != null && other.gameObject.tag == "Tree") {
        	var Tree = other.gameObject.GetComponent<Tree>();
            if (Tree!=null && !Tree.isCutDown) {
                canCutTree = true;
                target = other.gameObject;
            }
        } 
    }
    void OnTriggerStay2D (Collider2D other) {
        if (other != null && other.gameObject.tag == "Tree") {
        	var Tree = other.gameObject.GetComponent<Tree>();
            if (Tree!=null && !Tree.isCutDown) {
                canCutTree = true;
                target = other.gameObject;
            }else{
            	canCutTree=false;
            	target=null;
            }
        } 
    }
    void OnTriggerExit2D (Collider2D other) {
        if (other != null && other.gameObject.tag == "Tree") {
            canCutTree = false;
            target = null;
        } 
    }
}

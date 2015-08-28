using UnityEngine;
using System.Collections;

public class Tree : MonoBehaviour {
    public bool isCutDown;

    [SerializeField] GameObject normal;
    [SerializeField] GameObject cutdown;
    [SerializeField] int TreeID;

    [SerializeField] AudioClip clip;
    // Use this for initialization
    void Start () {
        if ((LevelManager.g.Tree1Cut && TreeID == 1) || (LevelManager.g.Tree2Cut && TreeID == 2)) {
            cutdown.SetActive(true);
            normal.SetActive(false);
            isCutDown=true;
        } else {
            cutdown.SetActive(false);
            normal.SetActive(true);
            isCutDown=false;
        }
		
    }
	
    // Update is called once per frame
    void Update () {
	
    }
    public void CutDown () {
        cutdown.SetActive(true);
        normal.SetActive(false);
        isCutDown=true;
        Events.g.Raise(new CutTreeEvents(TreeID, true));
        AudioSource.PlayClipAtPoint(clip, transform.position);
    }
}

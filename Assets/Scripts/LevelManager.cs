using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

    public static LevelManager g;
    public bool Tree1Cut, Tree2Cut;
    // Use this for initialization
    void Start () {
        if (g != null) {
            Destroy(this.gameObject);
            Destroy(this);
        } else {
            g = this;
        }
        DontDestroyOnLoad(gameObject);
    }
	
    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.N)) {
            Application.LoadLevel(Application.loadedLevel + 1);
        }
        if (Input.GetKeyDown(KeyCode.Escape)) {
        	Tree1Cut=false;
        	Tree2Cut=false;
            Application.LoadLevel(0);
        }
    }

    void OnEnable () {
        Events.g.AddListener<CutTreeEvents>(TreeCutRecord);
    }
    void OnDisable () {
        Events.g.RemoveListener<CutTreeEvents>(TreeCutRecord);
    }
    void TreeCutRecord (CutTreeEvents e) {	
        switch (e.TreeID) {
            case 1:
                Tree1Cut = e.isCut;
                break;
            case 2:
                Tree2Cut = e.isCut;
                break;
        }
    }
}

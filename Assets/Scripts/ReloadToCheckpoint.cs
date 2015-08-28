using UnityEngine;
using System.Collections;

public class ReloadToCheckpoint : MonoBehaviour {

    [SerializeField]
    private Checkpoint[] orderedCheckpoints;
    GameObject box;
    [SerializeField] GameObject boxPrefab;
    void Start () {
        box = GameObject.FindWithTag("Box");
    }

    public void Reload () {
        Checkpoint lastPassed = null;
        foreach (Checkpoint c in orderedCheckpoints) {
            if (c.passed)
                lastPassed = c;
        }

        GameObject.FindGameObjectWithTag("Player").transform.position = lastPassed.SpawnPosition;
        if (Application.loadedLevel == 0) {
            Destroy(box);
            box = (GameObject)Instantiate(boxPrefab, new Vector3(0, 0, 0), new Quaternion());
        }
    }
    void Update () {
        if (Input.GetKeyDown(KeyCode.Backspace)) {
            Reload();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsPlaygroundScript : MonoBehaviour {

    [SerializeField] private GameObject[] cubeCopies;
    [SerializeField] private Camera arCamera;
    [SerializeField] private Transform spawnLocation;
    [SerializeField] private float y_offSet = 0.0f;

    private List<GameObject> activeObjects = new List<GameObject>();

    // Use this for initialization
    void Start () {
        EventBroadcaster.Instance.AddObserver(EventNames.Personal.ON_RESET_SCENE, this.ResetScene);
	}

    private void Update()
    {
        
        if(Input.GetMouseButtonDown(0))
        {
            SpawnObject();
        }
    }

    private void OnDestroy()
    {
        EventBroadcaster.Instance.RemoveObserver(EventNames.Personal.ON_RESET_SCENE);
    }

    private void SpawnObject()
    {
        Ray ray = arCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray.origin, ray.direction, out hit))
        {

            if (hit.point != Vector3.zero) { 
                GameObject newCube = Instantiate(cubeCopies[Random.Range(0, 3)], spawnLocation);
                Vector3 position = new Vector3(hit.point.x, 
                                               hit.point.y + y_offSet, 
                                               hit.point.z);

                newCube.transform.position = position;
                newCube.SetActive(true);

                activeObjects.Add(newCube);
            }

        }
        
    }

    private void ResetScene()
    {
        for(int i = 0; i < activeObjects.Count; i++)
        {
            Destroy(activeObjects[i]);
        }

        activeObjects.Clear();
    }
}

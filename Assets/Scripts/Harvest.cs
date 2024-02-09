using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Harvest : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private NavMeshAgent harvestAgent;
    private BoxCollider harvestCollider;
    // Start is called before the first frame update
    void Start()
    {
        harvestCollider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        HarvestMove();
    }

    public void HarvestCrop()
    {

    }

    private void HarvestMove()
    {
        if (Input.GetMouseButton(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                harvestAgent.SetDestination(hit.point);
            }
        }
    }
}

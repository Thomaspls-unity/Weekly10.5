using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Machines : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private NavMeshAgent harvestAgent;
    [SerializeField] private NavMeshAgent plantAgent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlantMove();

        HarvestMove();
    }

    private void PlantMove()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                plantAgent.SetDestination(hit.point);
            }
        }
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

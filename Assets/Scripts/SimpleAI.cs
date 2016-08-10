using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
[RequireComponent (typeof(NavMeshAgent))]
public class SimpleAI : MonoBehaviour {

  private NavMeshAgent navmesh;
  private GameObject cam;
  public float routeSpeed;
  public Transform[] waypoints;

  public float minWaypointDist = .2f;

  private int currentWaypoint = 0;
  private int maxWaypoint;

  private void Awake() {
    navmesh = GetComponent<NavMeshAgent>();
    maxWaypoint = waypoints.Length - 1;
    cam = GameObject.FindGameObjectWithTag("SecondaryCamera");
    cam.SetActive(false);
  }

  private void Update() {
    Debug.DrawRay(transform.position, transform.forward * 5);
    RaycastHit hit;
    if (Physics.Raycast(transform.position, transform.forward*5f, out hit)) {
      Debug.Log(hit.collider.tag);
      if (hit.collider.tag == "Player") {
        cam.SetActive(true);
        Destroy(hit.collider.gameObject);
        SceneManager.LoadScene("WaypointSystem");
      }
      
    }
    Route();
  }

  private void Route() {
    navmesh.speed = routeSpeed;

    Vector3 tempLocalPos;
    Vector3 tempWaypointPos;

    tempLocalPos = transform.position;
    tempLocalPos.y = 0;

    tempWaypointPos = waypoints[currentWaypoint].position;
    tempWaypointPos.y = 0;

    if (Vector3.Distance(tempLocalPos, tempWaypointPos) <= minWaypointDist) {
      if (currentWaypoint == maxWaypoint) {
        currentWaypoint = 0;
      } else {
        currentWaypoint++;
      }
    }

    navmesh.SetDestination(waypoints[currentWaypoint].position);
  }


}

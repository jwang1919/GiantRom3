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
  private AudioSource source;


  private void Awake() {
    navmesh = GetComponent<NavMeshAgent>();
    maxWaypoint = waypoints.Length - 1;
    source = GetComponent<AudioSource>();

  }

  private void FixedUpdate() {
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

    Debug.DrawRay(transform.position, transform.forward * 30f,Color.red);
    RaycastHit hit;
    if (Physics.Raycast(transform.position, transform.forward, out hit, 30f)) {
      
      Debug.Log(hit.collider.tag);
      if (hit.collider.tag == "Player") {
        Debug.Log("Who's there?");
        source.Play();
        navmesh.SetDestination(hit.transform.position);
        transform.LookAt(hit.transform);
        
        Debug.DrawRay(transform.position, transform.forward * 5f);
        if (Physics.Raycast(transform.position, transform.forward, out hit, 5f)) {
          if (hit.collider.tag == "Player") {
            GameObject.FindGameObjectWithTag("SecondaryCamera").SetActive(true);
            Destroy(hit.collider.gameObject);
            SceneManager.LoadScene("WaypointSystem");
          }
        }
      } else {
        navmesh.SetDestination(waypoints[currentWaypoint].position);
      }

    } else {
      navmesh.SetDestination(waypoints[currentWaypoint].position);
    }
      
   
  }


}

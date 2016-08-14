using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
[RequireComponent (typeof(NavMeshAgent))]
public class SimpleAI : MonoBehaviour {

  private NavMeshAgent navmesh;
  private GameObject cam;
  public float routeSpeed;
  public Transform[] waypoints;
  public string sceneToLoad = "SiloScene";

  public float minWaypointDist = .2f;
  public float viewDistance = 30f;
  public float lengthToCapture = 5f;
  public float offset = 1f; 
  public AudioClip spottedClip;

  private int currentWaypoint = 0;
  private int maxWaypoint;
  private AudioSource source;
  private bool spotted = false;


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

    Debug.DrawRay(transform.position+transform.up*offset, transform.forward * viewDistance,Color.red);
    RaycastHit hit;
    if (Physics.Raycast(transform.position +transform.up * offset, transform.forward, out hit, viewDistance)) {
      
      Debug.Log(hit.collider.tag);
      if (hit.collider.tag == "Player") {
        if (spotted == false && source != null) {
          Debug.Log("Who's there?");
          source.PlayOneShot(spottedClip);
          spotted = true;
        }
        navmesh.SetDestination(hit.transform.position);
        transform.LookAt(hit.transform);
        
        Debug.DrawRay(transform.position, transform.forward * lengthToCapture);
        if (Physics.Raycast(transform.position, transform.forward, out hit, lengthToCapture)) {
          if (hit.collider.tag == "Player") {
            GameObject.FindGameObjectWithTag("SecondaryCamera").SetActive(true);
            Destroy(hit.collider.gameObject);
            SceneManager.LoadScene(sceneToLoad);
          }
        }
      } else {
        navmesh.SetDestination(waypoints[currentWaypoint].position);
        spotted = false;
      }

    } else {
      navmesh.SetDestination(waypoints[currentWaypoint].position);
      spotted = false;
    }

    
  }


}

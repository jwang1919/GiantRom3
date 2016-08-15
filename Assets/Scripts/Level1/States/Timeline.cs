using UnityEngine;

public class Timeline : MonoBehaviour {

    public enum TimelineState {
        PlayInstructions,
        CustomersArrived,
        PlaySiren,
        PlayEncouragment,
        PlayFarExplosion,
        PlayCloseExplosion,
        Done
    }
    
    public TimelineState currentState;
    public TimelineState nextState;

    public TimelineState[] stateOrder;
    
    private int order = 0;
    private float currentTime;

    private AirRaidState arState;
    private InstructionsState iState;
    private CustomersArrivedState caState;
    private EncouragementState eState;
    private FarExplosionsState feState;
    private CloseExplosionsState ceState;
    private DoneState dState;

    private int numberStatesUsed;

    private AudioSource audioSource;

    // Use this for initialization
    void Start() {
        if (stateOrder == null || stateOrder.Length == 0) {
            throw new System.Exception("At least one state must be defined!");
        }
        
        nextState = stateOrder[0];
        numberStatesUsed = stateOrder.Length;

        audioSource = GetComponent<AudioSource>();
        arState = GetComponent<AirRaidState>();
        iState = GetComponent<InstructionsState>();
        caState = GetComponent<CustomersArrivedState>();
        eState = GetComponent<EncouragementState>();
        feState = GetComponent<FarExplosionsState>();
        ceState = GetComponent<CloseExplosionsState>();
        dState = GetComponent<DoneState>();
    }
	
	// Update is called once per frame
	void Update () {
        switch(nextState) {
            case TimelineState.PlayInstructions:
                iState.Run(this, audioSource);
                break;
            case TimelineState.PlaySiren:
                arState.Run(this, audioSource);
                break;
            case TimelineState.CustomersArrived:
                caState.Run(this, audioSource);
                break;
            case TimelineState.PlayEncouragment:
                eState.Run(this, audioSource);
                break;
            case TimelineState.PlayFarExplosion:
                feState.Run(this, audioSource);
                break;
            case TimelineState.PlayCloseExplosion:
                ceState.Run(this, audioSource);
                break;
            case TimelineState.Done:
                dState.Run(this);
                break;
        }

        if (order > numberStatesUsed - 1) {
            nextState = TimelineState.Done;
            currentState = TimelineState.Done;
        } else {
            if (order > 1)
            {
                currentState = stateOrder[order - 1];
            }
            nextState = stateOrder[order];
        }

        currentTime += Time.deltaTime;
    }

    public void AddOrder()
    {
        order++;
    }

    public float GetCurrentTime()
    {
        return currentTime;
    }

}

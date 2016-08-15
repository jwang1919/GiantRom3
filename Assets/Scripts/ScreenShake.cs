using UnityEngine;
using System.Collections;

public class ScreenShake : MonoBehaviour {

    public float shakeAmount = 0.7F;
    public float decreaseFactor = 1F;

    public KeyCode shakeScreenKey = KeyCode.P;
    private bool flag = false;

    private float initialShakeAmount;
    private float initialDecreaseFactor;
    private float initialShake;

	// Use this for initialization
	void Start () {
        initialShakeAmount = shakeAmount;
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(shakeScreenKey)) {
            flag = true;
        }

        if (flag) {
            if (shakeAmount > 0F) {
                float currentY = Camera.main.transform.localPosition.y;
                Camera.main.transform.localPosition = new Vector3(Random.value * shakeAmount, currentY, Random.value * shakeAmount);
                shakeAmount -= Time.deltaTime * decreaseFactor;
            }
            else {
                flag = false;
                shakeAmount = initialShakeAmount;
            }
        }
    }

    public void Shake()
    {
        flag = true;
    }
}

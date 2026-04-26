using UnityEngine;

public class TurnOFFAfterTime : MonoBehaviour
{
    public float turnOffTimer;
    public float turnOffTimerReset;

    // Update is called once per frame
    void Update()
    {
        turnOffTimer -= Time.deltaTime * 10;
        if( turnOffTimer < 0 )
        {
            turnOffTimer = turnOffTimerReset;
            gameObject.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.TopDownEngine;
using MoreMountains.Tools;
using TMPro;

public class OnCustomerDeath : MonoBehaviour, MMEventListener<MMGameEvent>
{
    public TMP_Text ScoreText;

    void OnEnable()
    {
        this.MMEventStartListening<MMGameEvent>();
    }

    void OnDisable()
    {
        this.MMEventStopListening<MMGameEvent>();
    }

    public virtual void OnMMEvent(MMGameEvent gameEvent)
    {
        Debug.Log(gameEvent.EventName);
        // If customer killed
        if (gameEvent.EventName == "Customer Killed")
        {
            Debug.Log("here");
            // Get current game manager
            GameManager gm = this.GetComponent<GameManager>();
            
            // Increase Score
            gm.AddPoints(1);

            // Update HUD
            ScoreText.text = gm.Points.ToString() + " / 3 Deliveries Completed";
        }
    }
}

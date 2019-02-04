using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetScript : MonoBehaviour {

    public void onResetClicked()
    {
        EventBroadcaster.Instance.PostEvent(EventNames.Personal.ON_RESET_SCENE);
    }
}

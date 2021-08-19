﻿
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using UdonToolkit;

namespace InariUdon.Trigger
{

    [HelpMessage("Trigger by Enable/Disable Component and GameObject")]
    public class EnabledTrigger : UdonSharpBehaviour
    {
        [ListView("Enabled Events")] public UdonSharpBehaviour[] enabledEventTargets = {};
        [ListView("Enabled Events"), Popup("behaviour", "@enabledEventTargets", true)] public string[] enabledEvents = {};
        [ListView("Disabled Events")] public UdonSharpBehaviour[] disabledEventTargets = {};
        [ListView("Disabled Events"), Popup("behaviour", "@disabledEventTargets", true)] public string[] disabledEvents = {};

        private void SendCustomEventToTargets(UdonSharpBehaviour[] targets, string[] eventNames)
        {
            if (targets == null || eventNames == null) return;
            var length = Mathf.Min(targets.Length, eventNames.Length);
            for (int i = 0; i < length; i++)
            {
                if (targets != null) targets[i].SendCustomEvent(eventNames[i]);
            }
        }

        private void OnEnable()
        {
            SendCustomEventToTargets(enabledEventTargets, enabledEvents);
        }

        private void OnDisable()
        {
            SendCustomEventToTargets(disabledEventTargets, disabledEvents);
        }
    }
}

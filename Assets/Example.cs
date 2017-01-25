using UnityEngine;
using System.Collections;
using PubNubAPI;
using System.Collections.Generic;

public class Example : MonoBehaviour {

	// Use this for initialization
	void Start () {
        PNConfiguration pnConfiguration = new PNConfiguration ();
        PubNub pubnub = new PubNub (pnConfiguration);
        List<string> listChannelGroups = new List<string> (){"channelGroup1", "channelGroup2"};
        List<string> listChannels = new List<string> (){"channel1", "channel2"};
        pubnub.Subscribe ().SetChannelGroups (listChannelGroups).SetChannels(listChannels).Execute();
        //pubnub.Subscribe ().Async<string> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

﻿/*
 *
 *	Adventure Creator
 *	by Chris Burton, 2013-2020
 *	
 *	"RememberTimeline.cs"
 * 
 *	This script is attached to PlayableDirector objects in the scene
 *	we wish to save (Unity 2017+ only).
 * 
 */

using UnityEngine;
#if !ACIgnoreTimeline
using UnityEngine.Timeline;
#endif
using UnityEngine.Playables;

namespace AC
{

	/**
	 * Attach this script to PlayableDirector objects you wish to save.
	 */
	[RequireComponent (typeof (PlayableDirector))]
	[AddComponentMenu("Adventure Creator/Save system/Remember Timeline")]
	[HelpURL("https://www.adventurecreator.org/scripting-guide/class_a_c_1_1_remember_timeline.html")]
	public class RememberTimeline : Remember
	{

		/** If True, the GameObjects bound to the Timeline will be stored in save game files */
		public bool saveBindings;
		/** If True, the Timeline asset assigned in the PlayableDirector's Timeline field will be stored in save game files. */
		public bool saveTimelineAsset;
		/** If True, and the Timeline was not playing when it was saved, it will be evaluated at its playback point - causing the effects of it running at that single frame to be restored */
		public bool evaluateWhenStopped;


		/**
		 * <summary>Serialises appropriate GameObject values into a string.</summary>
		 * <returns>The data, serialised as a string</returns>
		 */
		public override string SaveData ()
		{
			TimelineData timelineData = new TimelineData ();
			timelineData.objectID = constantID;
			timelineData.savePrevented = savePrevented;

			PlayableDirector director = GetComponent <PlayableDirector>();
			timelineData.isPlaying = (director.state == PlayState.Playing);
			timelineData.currentTime = director.time;
			timelineData.trackObjectData = string.Empty;
			timelineData.timelineAssetID = string.Empty;

			if (director.playableAsset)
			{
				#if !ACIgnoreTimeline
				TimelineAsset timeline = (TimelineAsset) director.playableAsset;

				if (timeline)
				{
					if (saveTimelineAsset)
					{
						timelineData.timelineAssetID = AssetLoader.GetAssetInstanceID (timeline);
					}

					if (saveBindings)
					{
						int[] bindingIDs = new int[timeline.outputTrackCount];
						for (int i=0; i<bindingIDs.Length; i++)
						{
							TrackAsset trackAsset = timeline.GetOutputTrack (i);
							GameObject trackObject = director.GetGenericBinding (trackAsset) as GameObject;
							bindingIDs[i] = 0;
							if (trackObject)
							{
								ConstantID cIDComponent = trackObject.GetComponent <ConstantID>();
								if (cIDComponent)
								{
									bindingIDs[i] = cIDComponent.constantID;
								}
							}
						}

						for (int i=0; i<bindingIDs.Length; i++)
						{
							timelineData.trackObjectData += bindingIDs[i].ToString ();
							if (i < (bindingIDs.Length - 1))
							{
								timelineData.trackObjectData += ",";
							}
						}
					}
				}
				#endif
			}

			return Serializer.SaveScriptData <TimelineData> (timelineData);
		}
		

		public override void LoadData (string stringData)
		{
			TimelineData data = Serializer.LoadScriptData <TimelineData> (stringData);
			if (data == null) return;
			SavePrevented = data.savePrevented; if (savePrevented) return;

			PlayableDirector director = GetComponent <PlayableDirector>();

			#if !ACIgnoreTimeline
			if (director && director.playableAsset)
			{
				TimelineAsset timeline = (TimelineAsset) director.playableAsset;

				if (timeline)
				{
					if (saveTimelineAsset)
					{
						TimelineAsset _timeline = AssetLoader.RetrieveAsset (timeline, data.timelineAssetID);
						if (_timeline)
						{
							director.playableAsset = _timeline;
							timeline = _timeline;
						}
					}

					if (saveBindings && !string.IsNullOrEmpty (data.trackObjectData))
					{
						string[] bindingIDs = data.trackObjectData.Split (","[0]);

						for (int i=0; i<bindingIDs.Length; i++)
						{
							int bindingID = 0;
							if (int.TryParse (bindingIDs[i], out bindingID))
							{
								if (bindingID != 0)
								{
									var track = timeline.GetOutputTrack (i);
									if (track)
									{
										ConstantID savedObject = ConstantID.GetComponent (bindingID, gameObject.scene, true);
										if (savedObject)
										{
											director.SetGenericBinding (track, savedObject.gameObject);
										}
									}
				                }
				              }
						}
					}
				}
			}
			#endif

			director.time = data.currentTime;
			if (data.isPlaying)
			{
				director.Play ();
			}
			else
			{
				director.Stop ();

				if (evaluateWhenStopped)
				{
					director.Evaluate ();
				}
			}
		}
		
	}
	

	/**
	 * A data container used by the RememberTimeline script.
	 */
	[System.Serializable]
	public class TimelineData : RememberData
	{

		/** True if the Timline is playing */
		public bool isPlaying;
		/** The current time along the Timeline */
		public double currentTime;
		/** Which objects are loaded into the tracks */
		public string trackObjectData;
		/** The Instance ID of the current Timeline asset */
		public string timelineAssetID;

		
		/**
		 * The default Constructor.
		 */
		public TimelineData () { }

	}
	
}
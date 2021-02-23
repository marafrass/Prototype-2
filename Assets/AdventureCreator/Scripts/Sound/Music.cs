﻿/*
 *
 *	Adventure Creator
 *	by Chris Burton, 2013-2020
 *	
 *	"Music.cs"
 * 
 *	This script handles the playback of Music when played using the 'Sound: Play music' Action.
 * 
 */

using UnityEngine;
using System.Collections.Generic;

namespace AC
{

	/**
	 * This script handles the playback of Music when played using the 'Sound: Play music' Action.
	 */
	[HelpURL("https://www.adventurecreator.org/scripting-guide/class_a_c_1_1_music.html")]
	public class Music : Soundtrack
	{

		#region UnityStandards

		protected new void Awake ()
		{
			soundType = SoundType.Music;
			playWhilePaused = KickStarter.settingsManager.playMusicWhilePaused;
			base.Awake ();
		}

		#endregion


		#region PublicFunctions

		public override MainData SaveMainData (MainData mainData)
		{
			mainData.lastMusicQueueData = CreateLastSoundtrackString ();
			mainData.musicQueueData = CreateTimesampleString ();

			mainData.musicTimeSamples = 0;
			mainData.lastMusicTimeSamples = LastTimeSamples;

			if (GetCurrentTrackID () >= 0)
			{
				MusicStorage musicStorage = GetSoundtrack (GetCurrentTrackID ());
				if (musicStorage != null && musicStorage.audioClip != null && audioSource.clip == musicStorage.audioClip && IsPlaying ())
				{
					mainData.musicTimeSamples = audioSource.timeSamples;
				}
			}

			mainData.oldMusicTimeSamples = CreateOldTimesampleString ();

			return mainData;
		}


		public override void LoadMainData (MainData mainData)
		{
			LoadMainData (mainData.musicTimeSamples, mainData.oldMusicTimeSamples, mainData.lastMusicTimeSamples, mainData.lastMusicQueueData, mainData.musicQueueData);
		}

		#endregion


		#region ProtectedFunctions

		protected override bool EndsOthers ()
		{
			return KickStarter.settingsManager.autoEndOtherMusicWhenPlayed;
		}

		#endregion


		#region GetSet

		protected override bool IsMusic
		{
			get
			{
				return true;
			}
		}


		protected override List<MusicStorage> Storages
		{
			get
			{
				return KickStarter.settingsManager.musicStorages;
			}
		}


		protected override float LoadFadeTime
		{
			get
			{
				return KickStarter.settingsManager.loadMusicFadeTime;
			}
		}


		protected override bool CrossfadeWhenLoading
		{
			get
			{
				return KickStarter.settingsManager.crossfadeMusicWhenLoading;
			}
		}


		protected override bool RestartTrackWhenLoading
		{
			get
			{
				return KickStarter.settingsManager.restartMusicTrackWhenLoading;
			}
		}

		#endregion

	}

}
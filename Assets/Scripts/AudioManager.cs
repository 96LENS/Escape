using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
	
	public AudioSource Main, SE;
	public AudioClip Music, GameOver, Appear, Button, OnPc, Switch, Open, Get;
	public float volume;
	private bool bappear, btv, bpc, bonpc, bon, boff, bopen, gameover;

	public void PlayTvButton() {
		if (btv) {
			SE.PlayOneShot (Button, volume);
			btv = false;
		}
	}

	public void PlayPcButton() {
		if (bpc) {
			SE.PlayOneShot (Button, volume);
			bpc = false;
		}
	}

	public void PlayAppear() {
		if (bappear) {
			SE.PlayOneShot (Appear, volume);
			bappear = false;
		}
	}

	public void PlayOnPc() {
		if (bonpc) {
			SE.PlayOneShot (OnPc, volume);
			bonpc = false;
		}
	}

	public void PlayOnSwitch() {
		if (bon) {
			SE.PlayOneShot (Switch, volume);
			bon = false;
			boff = true;
		} 
	}

	public void PlayOffSwitch(){
		if (boff) {
			SE.PlayOneShot (Switch, volume);
			bon = true;
			boff = false;
		}
	}

	public void PlayOpen() {
		if (bopen) {
			SE.PlayOneShot (Open, volume);
			bopen = false;
		}
	}

	public void PlayGet(){
		SE.PlayOneShot (Get, volume);
	}

	public void PlayGameOver(){
		if (gameover) {
			SE.PlayOneShot (GameOver, volume);
			gameover = false;
		}
	}
		
	public void InitAudio(){
		btv = true;
		bappear = true;
		bpc = true;
		bonpc = true;
		bon = true;
		boff = false;
		bopen = true;
		gameover = true;
	}
}

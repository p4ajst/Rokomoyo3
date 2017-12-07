using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutIn : MonoBehaviour
{
    Text text;
    public void Show(MusicList.MusicData data)
    {
        text.text = data.musicName + "   /   " + data.composerName;
    }
    public void Stop()
    {
        text.text = "                   ";
    }

    private void Awake()
    {
        text = GetComponent<Text>();
    }

    // Use this for initialization
    void Start ()
    {
        SoundManager.Instance.Startmusic = Show;
        SoundManager.Instance.Stopsmusic = Stop;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}

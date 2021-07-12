using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using System.Linq;
using B83.Win32;


public class FileDragAndDrop : MonoBehaviour
{
    List<string> log = new List<string>();

    public GameObject[] clipVideoPlayers = new GameObject[6];
    //public GameObject clipVideoPlayer1;
    //public GameObject clipVideoPlayer2;
    void OnEnable ()
    {
        // must be installed on the main thread to get the right thread id.
        UnityDragAndDropHook.InstallHook();
        UnityDragAndDropHook.OnDroppedFiles += OnFiles;
    }
    void OnDisable()
    {
        UnityDragAndDropHook.UninstallHook();
    }

    void OnFiles(List<string> aFiles, POINT aPos)
    {
        // do something with the dropped file names. aPos will contain the 
        // mouse position within the window where the files has been dropped.

        string URL = aFiles.Aggregate((a, b) => a + "\n\t" + b);

        string str = "Dropped " + aFiles.Count + " files at: " + aPos + "\n\t" + URL;
        
        Debug.Log(str);

        float hx = 192 / 2;
        float hy = 108 / 2;

        //clipVideoPlayer1.GetComponent<VideoPlayer>().url = "file:///" + URL;

        // clipVideoPlayers[1].GetComponent<VideoPlayer>().url = "file:///" + URL;
        // clipVideoPlayers[2].GetComponent<VideoPlayer>().url = "file:///" + URL;
        // clipVideoPlayers[3].GetComponent<VideoPlayer>().url = "file:///" + URL;
        // clipVideoPlayers[4].GetComponent<VideoPlayer>().url = "file:///" + URL;
        // clipVideoPlayers[5].GetComponent<VideoPlayer>().url = "file:///" + URL;


        if(IsInRange(aPos.x, aPos.y, 1197-hx, 575-hy, 1197+hx, 575+hy)) {

            clipVideoPlayers[0].GetComponent<VideoPlayer>().url = "file:///" + URL;

        } else if(IsInRange(aPos.x, aPos.y, 1485-hx, 575-hy, 1485+hx, 575+hy)) {

            clipVideoPlayers[1].GetComponent<VideoPlayer>().url = "file:///" + URL;

        } else if(IsInRange(aPos.x, aPos.y, 1773-hx, 575-hy, 1773+hx, 575+hy)) {

            clipVideoPlayers[2].GetComponent<VideoPlayer>().url = "file:///" + URL;

        } else if(IsInRange(aPos.x, aPos.y, 1197-hx, 700-hy, 1197+hx, 700+hy)) {

            clipVideoPlayers[3].GetComponent<VideoPlayer>().url = "file:///" + URL;

        } else if(IsInRange(aPos.x, aPos.y, 1485-hx, 700-hy, 1485+hx, 700+hy)) {

            clipVideoPlayers[4].GetComponent<VideoPlayer>().url = "file:///" + URL;

        } else if(IsInRange(aPos.x, aPos.y, 1773-hx, 700-hy, 1773+hx, 700+hy)) {
                        
            clipVideoPlayers[5].GetComponent<VideoPlayer>().url = "file:///" + URL;

        }

        log.Add(str);
    }

    private void OnGUI()
    {
        if (GUILayout.Button("clear log"))
            log.Clear();
        foreach (var s in log)
            GUILayout.Label(s);
    }

    bool IsInRange(float x, float y, float minX, float minY, float maxX, float maxY) {

        if(minX <= x && x <= maxX && minY <= y && y <= maxY) {

            return true;

        } else {

            return false;

        }
    
    }

}

//using System;
//using System.IO;
//using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
//using UnityEngine.Networking;

public class Videos : MonoBehaviour
{
    public GameObject screen;
    //[SerializeField] private string primaryPath = @"C:\Users\cintec\Desktop\Unity Projects\IT Expo\Assets\Videos\Primary School";
    //[SerializeField] private string secondaryPath = @"C:\Users\cintec\Desktop\Unity Projects\IT Expo\Assets\Videos\Secondary School";
    public List<string> videoUrls;
    public List<string> videoNames;
    public List<string> primaryVideos;
    public List<string> secondaryVideos;
    private VideoPlayer videoPlayer;
    private Text screenName;
    //private List<string> encodedUrls;
    //private string group;
    //private string videoName;

    void Awake()
    {
        videoPlayer = screen.GetComponent<VideoPlayer>();
        screenName = screen.GetComponentInChildren<Text>();
        //GetFilePaths();
        InitVideos(primaryVideos, videoUrls);
        InitVideos(secondaryVideos, videoUrls);
        //encodeUrls(primaryVideos, videoUrls);
        //encodeUrls(secondaryVideos, videoUrls);
        //AddNames(primaryVideos, videoUrls);
        //AddNames(secondaryVideos, videoUrls);
        //group = "小學組";
        //videoName = "P01 - 海怡寶血小學 - 海怡寶血.mp4";
        //TestEncoding(group, videoName);
    }

    //void TestEncoding(string group, string videoName)
    //{
    //    print(group);
    //    string newName = videoName.Replace(" ", "%20");
    //    print(newName);
    //    string url = "http://innocarnival2022.cintec.cuhk.edu.hk";
    //    string encodedString = url + "/" + UnityWebRequest.EscapeURL(group) + "/" + UnityWebRequest.EscapeURL(newName);
    //    print(encodedString);
    //    print(UnityWebRequest.UnEscapeURL("http://innocarnival2022.cintec.cuhk.edu.hk/%E5%B0%8F%E5%AD%B8%E7%B5%84%2FP01%20-%20%E6%B5%B7%E6%80%A1%E5%AF%B6%E8%A1%80%E5%B0%8F%E5%AD%B8%20-%20%E6%B5%B7%E6%80%A1%E5%AF%B6%E8%A1%80.mp4"));
    //}

    //void encodeUrls(List<string> absoluteUrl, List<string> urls)
    //{
    //    foreach (string path in absoluteUrl)
    //    {
    //        string encodedUrl = UnityWebRequest.EscapeURL(path);
    //        print(encodedUrl);
    //    }
    //}

    //void AddNames(List<string> videoPaths, List<string> names)
    //{
    //    foreach (string path in videoPaths)
    //    {
    //        string videoName = Path.GetFileNameWithoutExtension(path);
    //        videoNames.Add(videoName);
    //    }
    //}

    //void GetFilePaths()
    //{
    //    //file.EndsWith("mov", StringComparison.OrdinalIgnoreCase) -> Search files with .mov endings
    //    primaryVideos =
    //        Directory.EnumerateFiles(primaryPath, "*.*").
    //        Where(file => file.ToLower().EndsWith("mp4") || file.EndsWith("mov", StringComparison.OrdinalIgnoreCase) ||
    //        file.EndsWith("m4v", StringComparison.OrdinalIgnoreCase)).ToList();
    //    secondaryVideos =
    //        Directory.EnumerateFiles(secondaryPath, "*.*").
    //        Where(file => file.ToLower().EndsWith("mp4") || file.EndsWith("mov", StringComparison.OrdinalIgnoreCase) ||
    //        file.EndsWith("m4v", StringComparison.OrdinalIgnoreCase) || file.EndsWith("webm", StringComparison.OrdinalIgnoreCase)).ToList();
    //}

    void InitVideos(List<string> videoPaths, List<string> urls)
    {
        foreach (var item in videoPaths) { urls.Add(item); }
    }

    public void SetVideo(int index) { videoPlayer.url = videoUrls[index-1]; }

    public void SetVideoName(int index) { screenName.text = videoNames[index - 1]; }
}

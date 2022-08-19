using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Videos : MonoBehaviour
{
    public GameObject screen;
    [SerializeField] private string primaryPath = @"C:\Users\cintec\Desktop\Unity Projects\IT Expo\Assets\Videos\Primary School";
    [SerializeField] private string secondaryPath = @"C:\Users\cintec\Desktop\Unity Projects\IT Expo\Assets\Videos\Secondary School";
    public List<string> videoPrimaryUrls;
    public List<string> videoSecondaryUrls;
    private List<string> secondaryVideos;
    private List<string> primaryVideos;
    private VideoPlayer videoPlayer;

    void Awake()
    {
        videoPlayer = screen.GetComponent<VideoPlayer>();
        GetFilePaths();
        InitVideos(primaryVideos, videoPrimaryUrls);
        InitVideos(secondaryVideos, videoSecondaryUrls);
    }

    void GetFilePaths()
    {
        //file.EndsWith("mov", StringComparison.OrdinalIgnoreCase) -> Search files with .mov endings
        primaryVideos =
            Directory.EnumerateFiles(primaryPath, "*.*").
            Where(file => file.ToLower().EndsWith("mp4") || file.EndsWith("mov", StringComparison.OrdinalIgnoreCase) ||
            file.EndsWith("m4v", StringComparison.OrdinalIgnoreCase)).ToList();
        secondaryVideos =
            Directory.EnumerateFiles(secondaryPath, "*.*").
            Where(file => file.ToLower().EndsWith("mp4") || file.EndsWith("mov", StringComparison.OrdinalIgnoreCase) ||
            file.EndsWith("m4v", StringComparison.OrdinalIgnoreCase) || file.EndsWith("webm", StringComparison.OrdinalIgnoreCase)).ToList();
    }

    void InitVideos(List<string> videoPaths, List<string> urls)
    {
        foreach (var item in videoPaths) { urls.Add(item); }
    }

    public void SetVideo(int index) { videoPlayer.url = videoPrimaryUrls[index-1]; }
}

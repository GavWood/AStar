using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

[InitializeOnLoad]
public class BWRefreshOnPlay
{
    /*
     * The default behaviour for Unity is to autorefresh the script assemblies.
     * This happens when you change a script and refocus on the Unity window.
     * However, when we change multiple files and flick between windows
     * this wastes a lot of time (*N files changed).
     *
     * Instead we can make a note of what files are changed.
     * These can then be compiled together on play.
     * To set this up
     * 1 Use this script
     * 2 Set Edit->Prferences->Asset Pipeline->Auto Refresh to Disabled
     */
    private static FileSystemWatcher fileSystemWatcher;
    private static bool haveAssetsChanged = false;
    private static HashSet<string> stringSet;

    static BWRefreshOnPlay()
    {
        stringSet = new HashSet<string>();

        // FileSystemWatcher needs to be disposed after its work is done, so we disposing it before assembly reloads
        AssemblyReloadEvents.beforeAssemblyReload += CleanUp;
        EditorApplication.playModeStateChanged += OnPlayModeChanged;

        // Capture script all changes
        fileSystemWatcher = new FileSystemWatcher(Path.GetFullPath(Application.dataPath));
        fileSystemWatcher.Filter = "*.cs";
        fileSystemWatcher.Created += OnAssetsChanged;
        fileSystemWatcher.Changed += OnAssetsChanged;
        fileSystemWatcher.Renamed += OnAssetsChanged;
        fileSystemWatcher.Deleted += OnAssetsChanged;
        fileSystemWatcher.EnableRaisingEvents = true;
        fileSystemWatcher.IncludeSubdirectories = true;
    }

    private static void OnAssetsChanged(object sender, FileSystemEventArgs e)
    {
        Debug.Log("Asset changed: " + e.Name);

        // Flag that our assets have changed
        haveAssetsChanged = true;
        stringSet.Add(e.Name);
    }

    private static void OnPlayModeChanged(PlayModeStateChange state)
    {
        // Debug.Log("OnPlayModeChanged");
        switch (state)
        {
            case PlayModeStateChange.ExitingEditMode:
                OnPlayModeEntered();
                break;
        }
    }

    private static void CleanUp()
    {
        if (fileSystemWatcher != null)
        {
            fileSystemWatcher.Dispose();
        }
    }

    private static void OnPlayModeEntered()
    {
        if (haveAssetsChanged)
        {
            Debug.Log("The following files changed:");
            foreach (string str in stringSet)
            {
                Debug.Log(str);
            }
            Debug.Log("Refreshing the asset database");
            haveAssetsChanged = false;
            stringSet.Clear();
            AssetDatabase.Refresh();
        }
    }
}

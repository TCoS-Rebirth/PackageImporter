using System.Collections.Generic;
using System.IO;
using Framework;
using Framework.PackageExtractor;
using TCosReborn;
using UnityEditor;
using UnityEngine;

public class UnitySBPackageLoader : MonoBehaviour
{

    [SerializeField] string lastDirectory;

    [ContextMenu("Load")]
    void LoadPkgs()
    {
        if (string.IsNullOrEmpty(lastDirectory)) lastDirectory = EditorUtility.OpenFolderPanel("", "", "");
        var loader = new SBFileLoader(lastDirectory);
        List<SBResourcePackage> pkgs;
        var start = Time.realtimeSinceStartup;
        if (loader.LoadGameplayPackages(out pkgs))
        {
            Debug.Log("Loading took: " + (Time.realtimeSinceStartup - start));

        }
    }

    [ContextMenu("Load Async")]
    void LoadPkgsAsync()
    {
        if (string.IsNullOrEmpty(lastDirectory)) lastDirectory = EditorUtility.OpenFolderPanel("", "", "");
        var loader = new SBFileLoader(lastDirectory);
        List<SBResourcePackage> pkgs;
        var start = Time.realtimeSinceStartup;
        if (loader.LoadGameplayPackagesAsync(out pkgs))
        {
            Debug.Log("Loading took: " + (Time.realtimeSinceStartup - start));

        }
    }

    [ContextMenu("Load custom")]
    void LoadSerialized()
    {
        using (var f = File.OpenRead(EditorUtility.OpenFilePanel("", "", "bin")))
        {
            var start = Time.realtimeSinceStartup;
            Debug.Log("Loading took: " + (Time.realtimeSinceStartup - start));
        }
    }
}

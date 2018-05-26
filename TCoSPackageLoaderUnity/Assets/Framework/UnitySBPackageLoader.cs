using System.Collections.Generic;
using System.IO;
using Framework.PackageExtractor;
using TCosReborn;
using UnityEditor;
using UnityEngine;

public class UnitySBPackageLoader : MonoBehaviour
{

    [SerializeField] string lastDirectory;
    [SerializeField] bool loadMaps;

    [SerializeField] string findObject;
    Dictionary<string, object> exportedObjects;
    List<SBResourcePackage> pkgs;

    [ContextMenu("Find Object")]
    void FindObject()
    {
        Debug.Log(exportedObjects.ContainsKey(findObject));
    }

    [ContextMenu("Verify Objects")]
    void VerifyObjects()
    {
        for (int i = 0; i < pkgs.Count; i++)
        {
            foreach (var key in pkgs[i].Resources.Keys)
            {
                if (!exportedObjects.ContainsKey(key)) Debug.Log(string.Format("Missing: {0}", key));
            }
        }
    }

    [ContextMenu("Load")]
    void LoadPkgs()
    {
        if (string.IsNullOrEmpty(lastDirectory)) lastDirectory = EditorUtility.OpenFolderPanel("", "", "");
        var loader = new SBFileLoader(lastDirectory);
        List<SBResourcePackage> maps;
        var start = Time.realtimeSinceStartup;
        if (loader.LoadGameplayPackages(out pkgs, out exportedObjects))
        {
            if (loadMaps) loader.LoadMaps(ref exportedObjects, out maps);
            Debug.Log("Loading took: " + (Time.realtimeSinceStartup - start));

        }
    }

    [ContextMenu("Load Async")]
    void LoadPkgsAsync()
    {
        if (string.IsNullOrEmpty(lastDirectory)) lastDirectory = EditorUtility.OpenFolderPanel("", "", "");
        var loader = new SBFileLoader(lastDirectory);
        List<SBResourcePackage> maps;
        var start = Time.realtimeSinceStartup;
        if (loader.LoadGameplayPackagesAsync(out pkgs, out exportedObjects))
        {
            if (loadMaps) loader.LoadMapsAsync(ref exportedObjects, out maps);
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

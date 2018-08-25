using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class ReferenceTracer
{

    Dictionary<Component, SerializedObject> sOs = new Dictionary<Component, SerializedObject>();

    public void RebuildSceneCache(Scene scene)
    {
        sOs.Clear();
        var sceneComponents = GetAllSceneComponents(scene);
        for (var i = 0; i < sceneComponents.Length; i++)
        {
            if (sceneComponents[i] == null) continue;
            sOs[sceneComponents[i]] = new SerializedObject(sceneComponents[i]);
        }
    }

    static Component[] GetAllSceneComponents(Scene scene)
    {
        var rootObjects = scene
            .GetRootGameObjects();
        var result = new List<Component>();
        foreach (var rootObject in rootObjects)
        {
            result.AddRange(rootObject.GetComponentsInChildren<Component>(true));
        }
        return result.ToArray();
    }

    public void BacktraceSelection(Scene scene, Component selection, List<Component> referencingTargets)
    {
        if (sOs.Count == 0) RebuildSceneCache(scene);
        foreach (var serObj in sOs)
        {
            var prop = serObj.Value.GetIterator();
            while (prop.NextVisible(true))
            {
                var isObjectField = prop.propertyType == SerializedPropertyType.ObjectReference && prop.objectReferenceValue != null;
                if (isObjectField && prop.objectReferenceValue == selection)
                {
                    referencingTargets.Add(serObj.Key);
                }
            }
        }
    }

    public void BacktraceSelection(Scene scene, GameObject selection, List<Component> referencingTargets)
    {
        if (sOs.Count == 0) RebuildSceneCache(scene);
        foreach (var componentInTarget in selection.GetComponents(typeof(Component)))
        {
            BacktraceSelection(scene, componentInTarget, referencingTargets);
        }
    }
}
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEditor;

public class ReferenceTracer
{

    Dictionary<Component, SerializedObject> sOs = new Dictionary<Component, SerializedObject>();

    public void RebuildSceneCache()
    {
        sOs.Clear();
        var sceneComponents = GetAllSceneComponents();
        for (var i = 0; i < sceneComponents.Length; i++)
        {
            sOs[sceneComponents[i]] = new SerializedObject(sceneComponents[i]);
        }
    }

    static Component[] GetAllSceneComponents()
    {
        var rootObjects = UnityEngine.SceneManagement.SceneManager
            .GetActiveScene()
            .GetRootGameObjects();
        var result = new List<Component>();
        foreach (var rootObject in rootObjects)
        {
            result.AddRange(rootObject.GetComponentsInChildren<Component>(true));
        }
        return result.ToArray();
    }

    public void BacktraceSelection(Component selection, List<Component> referencingTargets)
    {
        if (sOs.Count == 0) RebuildSceneCache();
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

    public void BacktraceSelection(GameObject selection, List<Component> referencingTargets)
    {
        if (sOs.Count == 0) RebuildSceneCache();
        foreach (var componentInTarget in selection.GetComponents(typeof(Component)))
        {
            BacktraceSelection(componentInTarget, referencingTargets);
        }
    }
}
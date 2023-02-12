using System;
using System.Collections;
using System.Collections.Generic;
using MetaClass.UI.UnityReact.Scripts;
using UnityEngine;

public abstract class ScrollViewComponent : ComponentUI
{
    // Start is called before the first frame update

    [SerializeField] private GameObject content;
    public override void AddChildComponent(Type t, Vector3 position, float scale, params object[] initValues)
    {
        String prefabPath = FindPrefab(t);
        if (prefabPath == null)
        {
            GameObject emptyObject = Instantiate(new GameObject(), content.transform, false);
            emptyObject.AddComponent<CanvasRenderer>();
            ComponentUI componentUI = (ComponentUI)emptyObject.AddComponent(t);
            emptyObject.transform.localPosition = position;
            emptyObject.transform.localScale *= scale;
            componentUI.SetStateFromParent(StateHasChangedRequests, Enviroment, componentsContainer);
            componentsContainer.AddElement(componentUI);
            SubComponents.Add(componentUI);
            componentUI.OnCreation(initValues);
            return;
        }

        String resourcesPath = TransformPath(prefabPath);
        GameObject asset = Resources.Load<GameObject>(resourcesPath);
        if (asset == null)
        {
            throw new Exception($"la classe {t} ha il path {prefabPath} non corretto");
        }

        GameObject subComponent = Instantiate(asset, content.transform, false);

        if (subComponent.TryGetComponent(out ComponentUI component))
        {
            subComponent.transform.localPosition = position;
            subComponent.transform.localScale *= scale;
            component.SetStateFromParent(StateHasChangedRequests, Enviroment, componentsContainer);
            componentsContainer.AddElement(component);
            SubComponents.Add(component);
            component.OnCreation(initValues);
        }
        else
        {
            Destroy(subComponent);
        }
        
        
    }
}

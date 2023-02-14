using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using UnityEngine;

namespace MetaClass.UI.UnityReact.Scripts
{
    public abstract class ComponentUI : MonoBehaviour, Identifiable
    {
        // Start is called before the first frame update
        protected IList<ComponentUI> SubComponents;

        public event Action OnStateHasChanged;

        protected Queue<(int componentId, int stateId, object newValue)> StateHasChangedRequests;

        protected Dictionary<String, object> Enviroment;

        private bool topLevel = true;


        public virtual void Start()
        {
            Transform parent = transform.parent;
            while (parent != null)
            {
                if (parent.TryGetComponent(out ComponentUI componentUI))
                {
                    return;
                }

                parent = parent.parent;
            }

            Type t = this.GetType();
            if (FindPrefab(t) != null)
            {
                throw new Exception($"{t.Name} non può essere usata come interfaccia di primo livello");
            }
                
            OnCreation();
        }

        public void SetStateFromParent(Queue<(int componentId, int stateId, object newValue)> stateHasChangedRequests,
            Dictionary<string, object> enviroment, Container<ComponentUI> components)
        {
            StateHasChangedRequests = stateHasChangedRequests;
            Enviroment = enviroment;
            topLevel = false;
            componentsContainer = components;
        }


        public void StateHasChanged(int stateId, object newValue)
        {
            (int componentId, int stateId, object newValue) request = (Id, stateId, newValue);
            StateHasChangedRequests.Enqueue(request);
        }

        public void AddChildComponent<T>(Vector3 position, float scale,
            params object[] initValues) where T : ComponentUI
        {
            AddChildComponent(typeof(T), position, scale, initValues);
        }

        public virtual void AddChildComponent(Type t, Vector3 position, float scale,
            params object[] initValues)
        {
            String prefabPath = FindPrefab(t);
            if (prefabPath == null)
            {
                GameObject emptyObject = new GameObject();
                emptyObject.transform.parent = gameObject.transform;
                emptyObject.name = t.Name;
                emptyObject.transform.localScale = Vector3.one;
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

            GameObject subComponent = Instantiate(asset, gameObject.transform, false);
            subComponent.name = t.Name;

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

        protected String FindPrefab(Type t)
        {
            Attribute[] attrs = System.Attribute.GetCustomAttributes(t); // Reflection.  

            // Displaying output.  
            foreach (Attribute attr in attrs)
            {
                if (attr is PrefabPath path)
                {
                    return path.getPrefabPath();
                }

                
            }

            return null;

        }

        protected String TransformPath(String oldPath)
        {
            String partToRemove = "";
            foreach (String dir in oldPath.Split("/"))
            {
                partToRemove += $"{dir}/";
                if (dir.Equals("Resources"))
                {
                    break;
                }
            }

            String result = oldPath.Replace(partToRemove, "").Replace(".prefab", "");

            return result;
        }

        #region LifeCycleMethods

        public void OnCreation(params object[] initValues)
        {
            if (topLevel)
            {
                StateHasChangedRequests = new Queue<(int componentId, int stateId, object newValue)>();
                Enviroment = new Dictionary<string, object>();
                StartCoroutine(StateHasChangedRequestHandler());
                componentsContainer = new Container<ComponentUI>();
                componentsContainer.AddElement(this);
            }

            SubComponents = new List<ComponentUI>();
            states = new Container<IState>();
            Init(initValues);
            OnDraw();
        }

        public void OnDraw()
        {
            foreach (var subComponent in SubComponents)
            {
                componentsContainer.RemoveElement(subComponent);
                OnDestruction(subComponent);
            }

            SubComponents = new List<ComponentUI>();
            Draw();
        }

        public void OnDestruction(ComponentUI componentUI)
        {
            componentUI.Delete();
            Destroy(componentUI.gameObject);
        }

        public abstract void Init(params object[] initValues);

        public abstract void Draw();

        public virtual void Delete()
        {
        }

        #endregion


        protected virtual IEnumerator StateHasChangedRequestHandler()
        {
            while (true)
            {
                if (StateHasChangedRequests.TryDequeue(out (int componentId, int stateId, object newValue) request))
                {
                    ComponentUI component = componentsContainer.GetElement(request.componentId);
                    IState state = component.states.GetElement(request.stateId);
                    state.SetState(request.newValue);
                    component.InvokeStateChange();
                }

                yield return null;
            }
        }

        public void AddToEnviroment(String key, object element)
        {
            Enviroment.Add(key, element);
        }

        public T GetFromEnviroment<T>(String key)
        {
            return (T)Enviroment[key];
        }


        public virtual void OnEnable()
        {
            OnStateHasChanged += OnDraw;
        }

        public virtual void OnDisable()
        {
            OnStateHasChanged -= OnDraw;
        }

        public void InvokeStateChange()
        {
            OnStateHasChanged?.Invoke();
        }


        #region Identifiable

        public int Id { get; set; }

        #endregion

        protected Container<ComponentUI> componentsContainer;

        #region States

        public Container<IState> states;

        public void AddState(IState state)
        {
            states.AddElement(state);
        }

        #endregion
    }
}
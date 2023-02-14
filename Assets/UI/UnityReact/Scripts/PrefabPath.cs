using System;

namespace MetaClass.UI.UnityReact.Scripts
{
    [System.AttributeUsage(System.AttributeTargets.Class)]
    public class PrefabPath : Attribute
    {
        private String prefabPath;

        public PrefabPath(string prefabPath)
        {
            this.prefabPath = prefabPath;
        }

        public String getPrefabPath()
        {
            return prefabPath;
        }
    }
}
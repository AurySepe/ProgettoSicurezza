using System;

namespace UI.UnityReact.Components
{
    [System.AttributeUsage(System.AttributeTargets.Class)]
    public class Route : Attribute
    {
        
        private String route;

        public Route(string route)
        {
            this.route = route;
        }

        public String getRoute()
        {
            return route;
        }
        
    }
}
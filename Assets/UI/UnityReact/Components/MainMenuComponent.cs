using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using MetaClass.UI.UnityReact.Scripts;
using UI.UnityReact.Components.Mostri;
using UI.UnityReact.Components.Utenti;
using UI.UnityReact.MonsterProject.Services;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI.UnityReact.Components
{
    public class MainMenuComponent : ComponentUI
    {
        private string Route;
        private object[] Params;

        private Stack<(string,object[])> stackPath;


        private Dictionary<string, Type> routes;

        public override void Init(params object[] initValues)
        {
            Route = "Home";
            Params = new object[0];

            stackPath = new Stack<(string,object[])>();

            Action<string,object[]> action = ChangeRoute;
            Enviroment["ChangeRoute"] = action;


            routes = new Dictionary<string, Type>();
            FindRoutes();
            SetServices();

        }

        public override void Draw()
        {
            
            AddChildComponent(RouteToType(Route),Vector3.zero, 1,Params);
            UnityAction indietroAction = GoBack;
            AddChildComponent<ButtonComponent>(new Vector3(-864.1f,450,0),1,"Indietro",Color.white,indietroAction);
            
            
        }


        private Type RouteToType(string route)
        {
            if (routes.ContainsKey(route))
            {
                return routes[route];
            }

            throw new Exception("route non trovata");
        }



        public void ChangeRoute(string route,params object[] values)
        {
            stackPath.Push((Route,Params));
            Route = route;
            Params = values;
            InvokeStateChange();

        }

        public void GoBack()
        {
            if (stackPath.Count == 0)
            {
                return;
            }
            (Route,Params) = stackPath.Pop();
            InvokeStateChange();
        }

        private void FindRoutes()
        {
            var type1Types =
                from type in Assembly.GetExecutingAssembly().GetTypes()
                where type.IsDefined(typeof(Route), false)
                
                select type;

            foreach (Type type in type1Types)
            {
                string route = type.GetCustomAttribute<Route>().getRoute();
                routes.Add(route,type);
            }
        }


        private void SetServices()
        {
            AddToEnviroment("TradeService",new TradeMonsterService());
        }
    }
}
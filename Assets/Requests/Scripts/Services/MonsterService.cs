﻿using System;
using Newtonsoft.Json;
using Scenes.TestScene.Scripts.Model;
using UnityEngine;

namespace Scenes.TestScene.Scripts.Services
{
    public class MonsterService
    {

        public void GetMonsterById(int id, Action<Monster> OnSuccess, Action<string> onFail)
        {
            Action<Response> responseAction = response =>
            {
                Debug.Log("Risposta ricevuta");
                if (!response.Ok)
                {
                    onFail(response.Result);
                    return;
                }

                MonsterTuple monsterTuple = JsonConvert.DeserializeObject<MonsterTuple>(response.Result);
                Sprite sprite = null;
                try
                {
                    sprite = StringToSprite(monsterTuple.ImageBase64);
                }
                catch (Exception e)
                {
                    onFail("sprite non valida");
                    return;
                }
                Monster monster = new Monster(sprite, id,monsterTuple.Nome);
                OnSuccess(monster);
            };


            RequestHandler.Instance.MakeRequest("/GetMonsterById",id,responseAction);
        }
        
        public void GetRandomMonsterById(Action<int> OnSuccess, Action<string> onFail)
        {
            Action<Response> responseAction = response =>
            {
                if (!response.Ok)
                {
                    onFail(response.Result);
                    return;
                }

                int result = JsonConvert.DeserializeObject<int>(response.Result);
                OnSuccess(result);
            };


            RequestHandler.Instance.MakeRequest("/EncounterMonster",null,responseAction);
        }
        
        
        
        
        private Sprite StringToSprite(string base64string)
        {
            byte[] pictureBytes = System.Convert.FromBase64String(base64string);

            Texture2D tex = new Texture2D( 2, 2 );
            tex.LoadImage( pictureBytes );
            tex.filterMode = FilterMode.Point;
            Sprite sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 16);
            return sprite;
        }
        
    }
}
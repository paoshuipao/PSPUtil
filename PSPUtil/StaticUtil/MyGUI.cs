using System;
using UnityEngine;

namespace PSPUtil.StaticUtil
{
    public static class MyGUI
    {
        public static void TextCenter(string text)
        {
            GUILayout.Label(text, "TextCenter");
        }


        public static void Text(string text)
        {
            GUILayout.Label(text);
        }

        public static void Text(Rect rect,string text)
        {
            GUI.Label(rect, text);
        }


        public static void Button(string text, Action onClick)
        {
            if (GUILayout.Button(text))
            {
                if (null != onClick)
                {
                    onClick();
                }
            }
        }
        public static void Button(string text,int width, Action onClick)
        {
            if (GUILayout.Button(text, GUILayout.Width(width)))
            {
                if (null != onClick)
                {
                    onClick();
                }
            }
        }

        public static void Button(Rect rect,string text, Action onClick)
        {
            if (GUI.Button(rect, text))
            {
                if (null != onClick)
                {
                    onClick();
                }
            }
        }

        public static void Button_OnlyText(string text, Action onClick)
        {
            if (GUILayout.Button(text, "Label"))
            {
                if (null != onClick)
                {
                    onClick();
                }
            }
        }

        public static void CreateScrollView(ref Vector2 position,  Action addMiddleContext)
        {
            position = GUILayout.BeginScrollView(position);
            if (null != addMiddleContext)
            {
                addMiddleContext();
            }
            GUILayout.EndScrollView();
        }


        public static void BuJu(float x, float y, float width, float height, Action action)
        {
            GUILayout.BeginArea(new Rect(x, y, width, height));
            if (null != action)
            {
                action();
            }
            GUILayout.EndArea();
        }


        public static void Heng(Action action)
        {
            GUILayout.BeginHorizontal();
            if (null != action)
            {
                action();
            }
            GUILayout.EndHorizontal();
        }



        public static void Shu(Action action)
        {
            GUILayout.BeginVertical();
            if (null != action)
            {
                action();
            }
            GUILayout.EndVertical();
        }


        public static void Box(Action action)
        {
            GUILayout.BeginVertical("HelpBox");
            if (null != action)
            {
                action();
            }
            GUILayout.EndVertical();
        }


        public static void AddSpace(float juLi)
        {
            GUILayout.Space(juLi);
        }

        public static void AddSpace()
        {
            GUILayout.FlexibleSpace();
        }


    }
}

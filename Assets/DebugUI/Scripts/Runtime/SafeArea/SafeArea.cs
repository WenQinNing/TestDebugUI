using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SafeArea : MonoBehaviour
{
    public enum Type
    {
        //适配竖屏，则预留上下两边安全区域
        Portrait,

        //适配横屏，则预留左右两边安全区域
        Landscape,

        //适配横屏左边，则只预留左边安全区域
        LandscapeLeft,

        //适配横屏右边，则只预留右边安全区域
        LandscapeRight
    }

    public Type type = Type.LandscapeLeft;
    private RectTransform _transform;
    private RenderBehindNotchSupport RBSupport;
    private AndroidSafeArea mAndroidSafeArea;


    public static bool HadGetRect = false;
    public static Rect ScreenRect;

    private void Awake()
    {
#if UNITY_ANDROID&&!UNITY_EDITOR
         RBSupport = gameObject.AddComponent<RenderBehindNotchSupport>();
            mAndroidSafeArea = gameObject.AddComponent<AndroidSafeArea>();
#endif
    }

    IEnumerator Start()
    {
        if (!HadGetRect)
        {
            yield return null;
        }

        _transform = transform as RectTransform;
        Rect rect = GetSafeAreaRect();
        // Debug.LogError(rect.ToString());
        if (type == Type.Landscape)
        {
            _transform.offsetMin = new Vector2(rect.x, 0);
            _transform.offsetMax = new Vector2(rect.xMax - Screen.width, 0);
        }
        else if (type == Type.LandscapeLeft)
        {
            _transform.offsetMin = new Vector2(rect.x, 0);
            _transform.offsetMax = Vector2.zero;
        }
        else if (type == Type.LandscapeRight)
        {
            _transform.offsetMin = Vector2.zero;
            _transform.offsetMax = new Vector2(rect.xMax - Screen.width, 0);
        }
        else
        {
            _transform.offsetMin = new Vector2(0, rect.y);
            _transform.offsetMax = new Vector2(0, rect.yMax - Screen.height);
        }
    }

    public static Rect GetSafeAreaRect()
    {
        if (!HadGetRect)
        {
            HadGetRect = true;
#if UNITY_ANDROID&&!UNITY_EDITOR
           ScreenRect = AndroidSafeArea.safeArea;
#else
            ScreenRect = Screen.safeArea;
#endif
        }

        return ScreenRect;
    }

    // private void Update()
    // {
        //Debug.LogError(GetSafeAreaRect().ToString()+"  "+Screen.fullScreen);
    // }
}
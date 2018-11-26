﻿using UnityEngine;
using XUUI;

public class App : MonoBehaviour
{
    Context context = null;

    void Start()
    {
        context = new Context(@"
            return {
                name  = 'myapp', 
                modules = {'module1', 'module2'}, -- 定义了modules就是使用app模式，module1模块将会以类似require 'myapp.module1'的方式加载
           }
        ");

        context.AddCommand("module2.cscmd", this, "CSCmd");
        context.AddCommand("reload_module1", this, "ReloadModule1");
        context.AddCommand("reload_module2", this, "ReloadModule2");
        context.Attach(gameObject);
    }

    void OnDestroy()
    {
        context.Dispose();
    }

    public void CSCmd(Interface2 data)
    {
        Debug.Log("data.select=" + data.select);
    }

    public void ReloadModule1()
    {
        context.ReloadModule("module1");
    }

    public void ReloadModule2()
    {
        context.ReloadModule("module2");
    }
}
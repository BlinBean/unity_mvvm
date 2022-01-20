using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class PropertyBinder<T> {
    private delegate void BindHandler(T viewmodel);
    private delegate void UnBindHandler(T viewmodel);

    private readonly List<BindHandler> _binders = new List<BindHandler>();
    private readonly List<UnBindHandler> _unbinders = new List<UnBindHandler>();

    //获取vm里公开的组件存储属性，并在组件里添加委托函数//T 和 TProperty还是有区别的
    public void Add<TProperty>(string name, BindableProperty<TProperty>.ValueChangedHandle valueChangedHandler){
        var fieldInfo = typeof(T).GetField(name, BindingFlags.Instance | BindingFlags.Public);//获取VM中指定类型存储属性(BindableProperty)
        if (fieldInfo == null)
        {
            throw new Exception(string.Format("Unable to find bindableproperty field '{0}.{1}'", typeof(T).Name, name));
        }

        _binders.Add(viewmodel =>
        {
            //绑定
            GetPropertyValue<TProperty>(name, viewmodel, fieldInfo).OnValueChanged += valueChangedHandler;
        });

        _unbinders.Add(viewModel =>
        {
            //解绑
            GetPropertyValue<TProperty>(name, viewModel, fieldInfo).OnValueChanged -= valueChangedHandler;
        });
    }

    
    private BindableProperty<TProperty> GetPropertyValue<TProperty>(string name, T viewModel, FieldInfo fieldInfo)
    {
        //反射获取对应的委托（BindableProperty）
        var value = fieldInfo.GetValue(viewModel);
        BindableProperty<TProperty> bindableProperty = value as BindableProperty<TProperty>;
        if (bindableProperty == null)
        {
            throw new Exception(string.Format("Illegal bindableproperty field '{0}.{1}' ", typeof(T).Name, name));
        }

        return bindableProperty;
    }
    //绑定所有
    public void Bind(T viewmodel)
    {
        for (int i = 0; i < _binders.Count; i++)
        {
            _binders[i](viewmodel);
        }
    }

    public void UnBind(T viewmodel)
    {
        for (int i = 0; i < _binders.Count; i++)
        {
            _unbinders[i](viewmodel);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//基类绑定VM
//定义为一个抽象类
public abstract class UnityGuiView<T> : MonoBehaviour, IView<T> where T:ViewModelBase
{
    bool _isInitialized;//是否初始化
    public bool destroyOnHide;//是否摧毁隐藏


    //当前view绑定的VM
    public readonly BindableProperty<T> ViewModelProperty = new BindableProperty<T>();
    protected readonly PropertyBinder<T> Binder = new PropertyBinder<T>();


    //显示之后的回调函数
    public Action RevealedAction { get; set; }
    //隐藏之后的回调函数
    public Action HiddenAction { get; set; }

    //实现接口
    public T BindingContext
    {
        get
        {
           return ViewModelProperty.Value;
        }

        set
        {
            //如果未初始化，调用初始化函数
            if (!_isInitialized)
            {
                OnInitialize();
                _isInitialized = true;
            }
            //赋值时触发BindableProperty里的委托函数
            ViewModelProperty.Value = value;
        }
    }

    //传入数据绑定类中的委托函数
    protected virtual void OnBindingContextChanged(ViewModelBase oldValue, ViewModelBase newValue)
    {

    }


    protected virtual void OnInitialize()
    {
        ViewModelProperty.OnValueChanged += OnBindingContextChanged;
    }

    //显示时的方法// 是否立刻显示？
    public void Reveal(bool immediate = false, Action action = null)
    {
        //加入的到显示的委托链中
        if (action != null)
        {
            RevealedAction += action;
        }
        //
    }

    //激活GO，设置部分bool
    public virtual void OnAppear()
    {
        gameObject.SetActive(true);
        BindingContext.OnStartReveal();//调用VM里的显示方法
    }
    public UnityGuiView()
    {


    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//基类绑定VM
public class UnityGuiView : MonoBehaviour, IView
{
    //当前view绑定的VM
    public readonly BindableProperty<ViewModelBase> ViewModelProperty = new BindableProperty<ViewModelBase>();

    //实现接口
    public ViewModelBase BindingContext
    {
        get
        {
           return ViewModelProperty.Value;
        }

        set
        {
            //赋值时触发BindableProperty里的委托函数
            ViewModelProperty.Value = value;
        }
    }

    //传入数据绑定类中的委托函数
    protected virtual void OnBindingContextChange(ViewModelBase oldValue, ViewModelBase newValue)
    {

    }

    //在构造函数里将OnBindingContextChange加入到BindableProperty的委托函数里
    public UnityGuiView()
    {
        ViewModelProperty.OnValueChanged += OnBindingContextChange;
    }
}

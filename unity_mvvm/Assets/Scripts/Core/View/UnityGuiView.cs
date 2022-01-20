using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//基类绑定VM
public class UnityGuiView<T> : MonoBehaviour, IView where T:ViewModelBase
{
    //当前view绑定的VM
    public readonly BindableProperty<ViewModelBase> ViewModelProperty = new BindableProperty<ViewModelBase>();
    protected readonly PropertyBinder<T> Binder = new PropertyBinder<T>();

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
    protected virtual void OnBindingContextChanged(ViewModelBase oldValue, ViewModelBase newValue)
    {

    }


    protected virtual void OnInitialize()
    {
        ViewModelProperty.OnValueChanged += OnBindingContextChanged;
    }


    public UnityGuiView()
    {


    }
}

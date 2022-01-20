using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//子类
public class SetupView : UnityGuiView<ViewModelBase>
{
    public InputField nameInputField;
    public Text nameMessageText;

    public InputField jobInputField;
    public Text jobMessageText;

    public InputField atkInputField;
    public Text atkMessageText;

    public Slider successRateSlider;
    public Text successRateMessageText;

    public Toggle joinToggle;
    public Button joinInButton;
    public Button waitButton;

    //返回基类中的BindingContext，(绑定的VM)
    public SetupViewModel ViewModel { get { return (SetupViewModel)BindingContext; } }


    //重写基类中的委托函数，VM发生改变时调用这个，更新VM中的各个组件
    protected override void OnBindingContextChanged(ViewModelBase oldValue, ViewModelBase newValue)
    {
    }

    protected override void OnInitialize()
    {
        base.OnInitialize();
        Binder.Add<string>("Color", OnColorPropertyValueChanged);
    }


    private void OnColorPropertyValueChanged(string oldValue, string newValue)
    {
        switch (newValue)
        {
            case "Red":
                Debug.LogError("红色");
                break;
            case "Yellow":
                Debug.LogError("黄色");
                break;
            default:
                break;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//子类
public class SetupView : UnityGuiView
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
    protected override void OnBindingContextChange(ViewModelBase oldValue, ViewModelBase newValue)
    {
        base.OnBindingContextChange(oldValue, newValue);

        SetupViewModel oldVM = oldValue as SetupViewModel;
        //oldValue.Name.OnValueChanged -= NameValueChanged;
        //改变VM中各个组件的数值
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SetupViewModel : ViewModelBase
{
    //统一去管理各个组件的数据
    public BindableProperty<string> Name = new BindableProperty<string>();
    public BindableProperty<string> Job = new BindableProperty<string>();
    public BindableProperty<int> ATK = new BindableProperty<int>();
    public BindableProperty<float> SuccessRate = new BindableProperty<float>();
}

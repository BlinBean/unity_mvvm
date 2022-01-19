using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//View基类要继承的接口
//
public interface IView
{
    //上下文属性
    ViewModelBase BindingContext { get; set; }
}

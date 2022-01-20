using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//View基类要继承的接口
//
public interface IView<T> where T : ViewModelBase
{
    //上下文属性
    T BindingContext { get; set; }
}

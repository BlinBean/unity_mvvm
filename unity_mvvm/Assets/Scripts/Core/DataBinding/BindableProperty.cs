using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 各个类型的数据绑定,算是整个mvvm的核心属性
// 数据更新时通知订阅者
// 可以理解为item数据，由VM统一管理(VM中的定义
// view中的定义则时管理(绑定)VM

//泛用型类
public class BindableProperty<T>  {

    //需要旧数据和新数据
    public delegate void ValueChangedHandle(T oldValue, T newValue);

    //可由外部传入数值时的更变的委托方法
    public ValueChangedHandle OnValueChanged;

    private T _value;

    public T Value {
        get {return _value; }
        set {
                T oldValue = _value;
                _value = value;
                ValueChanged(oldValue, _value);
         }
    }

    //外部传入的委托方法再封装一层，改变数据的时候去使用ValueChanged
    private void ValueChanged(T oldValue, T newValue)
    {
        //判断有没有委托函数，没有的话这个函数就没啥用
        if (OnValueChanged != null)
        {
            OnValueChanged(oldValue, newValue);
        }
    }

    public override string ToString()
    {
        return _value == null ? "null" : _value.ToString();
    }

}

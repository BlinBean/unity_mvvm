using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//消息要执行的方法
public delegate void MessageHandler<T>(object sender, MessageArgs<T> args);



//消息中介者，用于view和VM 、 VM和VM之间的解耦
//统一由这个进行转发消息，由key来区分
public class MessageAggregator<T>  {
    //存储字典
    private readonly Dictionary<string, MessageHandler<T>> _messages = new Dictionary<string, MessageHandler<T>>();
    
    // 唯一类
    public static readonly MessageAggregator<T> Instance = new MessageAggregator<T>();

    //构造函数
    private MessageAggregator()
    {

    }

    // 将处理方法存入字典中(委托链中)
    public void Subscribe(string name, MessageHandler<T> handler)
    {

        if (!_messages.ContainsKey(name))
        {
            _messages.Add(name, handler);
        }
        else
        {
            _messages[name] += handler;
        }

    }

    //调用字典里的函数
    public void Publish(string name, object sender, MessageArgs<T> args)
    {
        if (_messages.ContainsKey(name) && _messages[name] != null)
        {
            //转发
            _messages[name](sender, args);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://nyama41.hatenablog.com/entry/singleton_inheritance
// シングルトン(過剰使用厳禁)
// 上記サイトから引用
namespace System
{
    public abstract class Singleton<SingletonType>
       : System.IDisposable
       where SingletonType : Singleton<SingletonType>, new()
    {
        private static SingletonType m_Instance;

        public static SingletonType Instance
        {
            get
            {
                return GetOrCreateInstance<SingletonType>();
            }
        }

        protected static InheritSingletonType GetOrCreateInstance<InheritSingletonType>()
            where InheritSingletonType : class, SingletonType, new()
        {
            if (IsCreated)
            {
                // 基底クラスから呼ばれた後に継承先から呼ばれるとエラーになる。先に継承先から呼ぶ
                if (!typeof(InheritSingletonType).IsAssignableFrom(m_Instance.GetType()))
                {
                    UnityEngine.Debug.LogErrorFormat(
                        "{1}が{0}を継承していません",
                        typeof(InheritSingletonType),
                        m_Instance.GetType()
                    );
                }
            }
            else
            {
                m_Instance = new InheritSingletonType();
            }
            return m_Instance as InheritSingletonType;
        }

        public static bool IsCreated
        {
            get { return m_Instance != null; }
        }

        public virtual void Dispose()
        {
            m_Instance = default;
        }

        /// <summary>
        /// コンストラクタ（外部からの呼び出し禁止）
        /// </summary>
        protected Singleton() { }
    }
}
using System.Collections;
using System.Collections.Concurrent;
using GameFrameX.Runtime;
using UnityEngine;

namespace GameFrameX.Coroutine.Runtime
{
    /// <summary>
    /// 协程组件。对 Unity 原生协程 API 的封装和跟踪。
    /// 注意：使用 new 关键字隐藏基类方法，必须通过 CoroutineComponent 类型引用调用，以确保协程被正确跟踪。
    /// </summary>
    [DisallowMultipleComponent]
    [AddComponentMenu("Game Framework/Coroutine")]
    public class CoroutineComponent : GameFrameworkComponent
    {
        /// <summary>
        /// 执行过的迭代器。
        /// 注意：IEnumerator 作为 key 使用引用相等性，StopCoroutine 必须传入与 StartCoroutine 相同的 IEnumerator 实例。
        /// </summary>
        private readonly ConcurrentDictionary<IEnumerator, UnityEngine.Coroutine> m_CoroutineMap = new ConcurrentDictionary<IEnumerator, UnityEngine.Coroutine>();

        /// <summary>
        /// 开启一个协程
        /// </summary>
        /// <param name="enumerator"></param>
        /// <returns></returns>
        public new UnityEngine.Coroutine StartCoroutine(IEnumerator enumerator)
        {
            var ret = base.StartCoroutine(enumerator);
            m_CoroutineMap[enumerator] = ret;
            return ret;
        }

        /// <summary>
        /// 终止一个协程
        /// </summary>
        /// <param name="enumerator"></param>
        public new void StopCoroutine(IEnumerator enumerator)
        {
            if (m_CoroutineMap.TryGetValue(enumerator, out var coroutine))
            {
                base.StopCoroutine(coroutine);
                m_CoroutineMap.TryRemove(enumerator, out _);
            }
            else
            {
                base.StopCoroutine(enumerator);
            }
        }

        /// <summary>
        /// 终止一个协程
        /// </summary>
        /// <param name="coroutine"></param>
        public new void StopCoroutine(UnityEngine.Coroutine coroutine)
        {
            base.StopCoroutine(coroutine);
            foreach (var item in m_CoroutineMap)
            {
                if (item.Value == coroutine)
                {
                    m_CoroutineMap.TryRemove(item.Key, out _);
                    break;
                }
            }
        }

        /// <summary>
        /// 终止全部协程
        /// </summary>
        public new void StopAllCoroutines()
        {
            // 先逐个停止已跟踪的协程，再清理字典，最后调用 base 清理所有未跟踪的协程
            foreach (var coroutine in m_CoroutineMap.Values)
            {
                base.StopCoroutine(coroutine);
            }

            m_CoroutineMap.Clear();
            base.StopAllCoroutines();
        }

        private readonly WaitForEndOfFrame _waitForEndOfFrame = new WaitForEndOfFrame();

        /// <summary>
        /// 等待当前帧结束
        /// </summary>
        /// <returns></returns>
        private IEnumerator WaitForEndOfFrameFinishInternal(System.Action callback)
        {
            yield return _waitForEndOfFrame;
            callback?.Invoke();
        }

        /// <summary>
        /// 等待当前帧结束。
        /// 注意：如果在回调触发前通过 StopCoroutine/StopAllCoroutines 停止该协程，callback 将不会被执行。
        /// </summary>
        /// <param name="callback"></param>
        public void WaitForEndOfFrameFinish(System.Action callback)
        {
            StartCoroutine(WaitForEndOfFrameFinishInternal(callback));
        }

        protected override void Awake()
        {
            IsAutoRegister = false;
            base.Awake();
        }
    }
}
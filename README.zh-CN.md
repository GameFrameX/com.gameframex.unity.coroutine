<div align="center">

<img src="https://download.alianblank.com/gameframex/gameframex_logo_320.png" alt="Game Frame X Logo" width="160" />

# Game Frame X Coroutine

[![GitHub release](https://img.shields.io/github/v/release/GameFrameX/com.gameframex.unity.coroutine?style=flat-square)](https://github.com/GameFrameX/com.gameframex.unity.coroutine/releases)
[![License](https://img.shields.io/github/license/GameFrameX/com.gameframex.unity.coroutine?style=flat-square)](https://github.com/GameFrameX/com.gameframex.unity.coroutine/blob/main/LICENSE.md)
[![Documentation](https://img.shields.io/badge/Documentation-Online-blue?style=flat-square)](https://gameframex.doc.alianblank.com)

**独立游戏前后端一体化解决方案 · 独立游戏开发者的圆梦大使**

[文档](https://gameframex.doc.alianblank.com) · [快速开始](#快速开始) · [QQ群](https://qm.qq.com/q/5s5e1e6e6e)

**语言**: [English](README.md) | **简体中文** | [繁體中文](README.zh-TW.md) | [日本語](README.ja.md) | [한국어](README.ko.md)


</div>

---

## 项目简介

Game Frame X Coroutine 是一个基于 GameFrameX 框架的 Unity 协程管理包，扩展了 Unity 的内建协程管理功能。

**Coroutine 协程组件 (Coroutine Component)** - 提供扩展了 Unity 的内建协程管理功能的接口。

## 功能特性

1. **启动协程**: 使用 `StartCoroutine(IEnumerator enumerator)` 方法来启动一个协程。迭代器和 Unity 的协程对象存储在并发字典中，确保可以随时访问和管理。

2. **停止协程**: 通过 `StopCoroutine(IEnumerator enumerator)` 或 `StopCoroutine(UnityEngine.Coroutine coroutine)` 方法停止单个协程。同时从 Unity 和内部字典中移除协程，防止内存泄漏。

3. **停止所有协程**: 通过 `StopAllCoroutines()` 方法停止所有正在运行的协程，确保干净停止并清空内部跟踪字典。

4. **帧结束时回调**: `WaitForEndOfFrameFinish(System.Action callback)` 方法允许在当前帧渲染结束后执行回调。

## 快速开始

### 系统要求

- Unity 2017.1 或更高版本

### 安装

任选以下方式之一：

1. 直接在 `manifest.json` 的文件中的 `dependencies` 节点下添加以下内容：
   ```json
   {"com.gameframex.unity.coroutine": "https://github.com/AlianBlank/com.gameframex.unity.coroutine.git"}
   ```

2. 在 Unity 的 `Packages Manager` 中使用 `Git URL` 的方式添加库，地址为：
   ```
   https://github.com/AlianBlank/com.gameframex.unity.coroutine.git
   ```

3. 直接下载仓库放置到 Unity 项目的 `Packages` 目录下，会自动加载识别。

## 使用示例

### 启动一个协程

```csharp
IEnumerator YourCoroutine()
{
    // 协程执行的内容
    yield return null;
}

CoroutineComponent coroutineComponent = gameObject.AddComponent<CoroutineComponent>();
coroutineComponent.StartCoroutine(YourCoroutine());
```

### 停止一个协程

```csharp
IEnumerator yourCoroutine = YourCoroutine();
coroutineComponent.StopCoroutine(yourCoroutine);
```

### 停止所有协程

```csharp
coroutineComponent.StopAllCoroutines();
```

### 帧结束时执行回调

```csharp
void YourCallback()
{
    // 回调执行的内容
}

coroutineComponent.WaitForEndOfFrameFinish(YourCallback);
```

请注意，在添加 `CoroutineComponent` 到游戏对象时，确保场景中没有其他相同类型的组件，因为该类使用了 `[DisallowMultipleComponent]` 属性。

## 文档与资源

- 文档地址: https://gameframex.doc.alianblank.com
- 仓库地址: https://github.com/GameFrameX/com.gameframex.unity.coroutine
- 问题反馈: https://github.com/GameFrameX/com.gameframex.unity.coroutine/issues

## 开源协议

详细信息请查看 [LICENSE](LICENSE.md) 文件。

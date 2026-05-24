<div align="center">
  <img src="https://download.alianblank.com/gameframex/gameframex_logo_320.png" alt="Game Frame X Logo" width="160" />
</div>

# Game Frame X Coroutine

[![GitHub release](https://img.shields.io/github/v/release/GameFrameX/com.gameframex.unity.coroutine?style=flat-square)](https://github.com/GameFrameX/com.gameframex.unity.coroutine/releases)
[![License](https://img.shields.io/github/license/GameFrameX/com.gameframex.unity.coroutine?style=flat-square)](https://github.com/GameFrameX/com.gameframex.unity.coroutine/blob/main/LICENSE.md)
[![Documentation](https://img.shields.io/badge/Documentation-Online-blue?style=flat-square)](https://gameframex.doc.alianblank.com)

**All-in-One Solution for Indie Game Development · Empowering Indie Developers' Dreams**

[Documentation](https://gameframex.doc.alianblank.com) · [Quick Start](#quick-start) · [QQ Group](https://qm.qq.com/q/5s5e1e6e6e)

**Language**: **English** | [简体中文](README.zh-CN.md) | [繁體中文](README.zh-TW.md) | [日本語](README.ja.md) | [한국어](README.ko.md)

---

## Project Overview

Game Frame X Coroutine is a Unity coroutine management package based on the GameFrameX framework, extending Unity's built-in coroutine management functionality.

**Coroutine Component** - Provides interfaces that extend Unity's built-in coroutine management capabilities.

## Features

1. **Start Coroutine**: Use `StartCoroutine(IEnumerator enumerator)` to start a coroutine. Iterators and Unity coroutine objects are stored in a concurrent dictionary for easy access and management.

2. **Stop Coroutine**: Stop individual coroutines via `StopCoroutine(IEnumerator enumerator)` or `StopCoroutine(UnityEngine.Coroutine coroutine)`. These methods ensure coroutines are removed from both Unity and the internal dictionary, preventing memory leaks.

3. **Stop All Coroutines**: Stop all running coroutines via `StopAllCoroutines()`. This method ensures clean stopping of all coroutines and clears the internal tracking dictionary.

4. **End of Frame Callback**: The `WaitForEndOfFrameFinish(System.Action callback)` method allows executing a callback after the current frame's rendering is complete.

## Quick Start

### System Requirements

- Unity 2017.1 or higher

### Installation

Choose one of the following methods:

1. Add the following to the `dependencies` section in your project's `manifest.json`:
   ```json
   {"com.gameframex.unity.coroutine": "https://github.com/AlianBlank/com.gameframex.unity.coroutine.git"}
   ```

2. Use `Git URL` in Unity's Package Manager:
   ```
   https://github.com/AlianBlank/com.gameframex.unity.coroutine.git
   ```

3. Download the repository and place it in your Unity project's `Packages` directory. It will be loaded automatically.

## Usage Examples

### Start a Coroutine

```csharp
IEnumerator YourCoroutine()
{
    // Coroutine execution content
    yield return null;
}

CoroutineComponent coroutineComponent = gameObject.AddComponent<CoroutineComponent>();
coroutineComponent.StartCoroutine(YourCoroutine());
```

### Stop a Coroutine

```csharp
IEnumerator yourCoroutine = YourCoroutine();
coroutineComponent.StopCoroutine(yourCoroutine);
```

### Stop All Coroutines

```csharp
coroutineComponent.StopAllCoroutines();
```

### End of Frame Callback

```csharp
void YourCallback()
{
    // Callback execution content
}

coroutineComponent.WaitForEndOfFrameFinish(YourCallback);
```

Note: When adding `CoroutineComponent` to a GameObject, ensure there are no other components of the same type in your scene, as the class uses the `[DisallowMultipleComponent]` attribute.

## Documentation & Resources

- Documentation: https://gameframex.doc.alianblank.com
- Repository: https://github.com/GameFrameX/com.gameframex.unity.coroutine
- Issues: https://github.com/GameFrameX/com.gameframex.unity.coroutine/issues

## License

See [LICENSE](LICENSE.md) for details.

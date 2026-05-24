<div align="center">
  <img src="https://download.alianblank.com/gameframex/gameframex_logo_320.png" alt="Game Frame X Logo" width="160" />
</div>

# Game Frame X Coroutine

[![GitHub release](https://img.shields.io/github/v/release/GameFrameX/com.gameframex.unity.coroutine?style=flat-square)](https://github.com/GameFrameX/com.gameframex.unity.coroutine/releases)
[![License](https://img.shields.io/github/license/GameFrameX/com.gameframex.unity.coroutine?style=flat-square)](https://github.com/GameFrameX/com.gameframex.unity.coroutine/blob/main/LICENSE.md)
[![Documentation](https://img.shields.io/badge/Documentation-Online-blue?style=flat-square)](https://gameframex.doc.alianblank.com)

**獨立遊戲前後端一體化解決方案 · 獨立遊戲開發者的圓夢大使**

[文檔](https://gameframex.doc.alianblank.com) · [快速開始](#快速開始) · [QQ群](https://qm.qq.com/q/5s5e1e6e6e)

**語言**: [English](README.md) | [简体中文](README.zh-CN.md) | **繁體中文** | [日本語](README.ja.md) | [한국어](README.ko.md)

---

## 項目簡介

Game Frame X Coroutine 是一個基於 GameFrameX 框架的 Unity 協程管理包，擴展了 Unity 的內建協程管理功能。

**Coroutine 協程元件 (Coroutine Component)** - 提供擴展了 Unity 的內建協程管理功能的介面。

## 功能特性

1. **啟動協程**: 使用 `StartCoroutine(IEnumerator enumerator)` 方法來啟動一個協程。迭代器和 Unity 的協程物件儲存在並行字典中，確保可以隨時存取和管理。

2. **停止協程**: 透過 `StopCoroutine(IEnumerator enumerator)` 或 `StopCoroutine(UnityEngine.Coroutine coroutine)` 方法停停單個協程。同時從 Unity 和內部字典中移除協程，防止記憶體洩漏。

3. **停止所有協程**: 透過 `StopAllCoroutines()` 方法停止所有正在執行的協程，確保乾淨停止並清空內部追蹤字典。

4. **幀結束時回呼**: `WaitForEndOfFrameFinish(System.Action callback)` 方法允許在當前幀渲染結束後執行回呼。

## 快速開始

### 系統需求

- Unity 2017.1 或更高版本

### 安裝

任選以下方式之一：

1. 直接在 `manifest.json` 的檔案中的 `dependencies` 節點下添加以下內容：
   ```json
   {"com.gameframex.unity.coroutine": "https://github.com/AlianBlank/com.gameframex.unity.coroutine.git"}
   ```

2. 在 Unity 的 `Packages Manager` 中使用 `Git URL` 的方式添加庫，地址為：
   ```
   https://github.com/AlianBlank/com.gameframex.unity.coroutine.git
   ```

3. 直接下載倉庫放置到 Unity 專案的 `Packages` 目錄下，會自動載入識別。

## 使用範例

### 啟動一個協程

```csharp
IEnumerator YourCoroutine()
{
    // 協程執行的內容
    yield return null;
}

CoroutineComponent coroutineComponent = gameObject.AddComponent<CoroutineComponent>();
coroutineComponent.StartCoroutine(YourCoroutine());
```

### 停止一個協程

```csharp
IEnumerator yourCoroutine = YourCoroutine();
coroutineComponent.StopCoroutine(yourCoroutine);
```

### 停止所有協程

```csharp
coroutineComponent.StopAllCoroutines();
```

### 幀結束時執行回呼

```csharp
void YourCallback()
{
    // 回呼執行的內容
}

coroutineComponent.WaitForEndOfFrameFinish(YourCallback);
```

請注意，在添加 `CoroutineComponent` 到遊戲物件時，確保場景中沒有其他相同類型的元件，因為該類別使用了 `[DisallowMultipleComponent]` 屬性。

## 文檔與資源

- 文檔地址: https://gameframex.doc.alianblank.com
- 倉庫地址: https://github.com/GameFrameX/com.gameframex.unity.coroutine
- 問題回報: https://github.com/GameFrameX/com.gameframex.unity.coroutine/issues

## 開源協議

詳細資訊請查看 [LICENSE](LICENSE.md) 檔案。

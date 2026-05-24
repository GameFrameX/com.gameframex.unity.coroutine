<div align="center">
  <img src="https://download.alianblank.com/gameframex/gameframex_logo_320.png" alt="Game Frame X Logo" width="160" />
</div>

# Game Frame X Coroutine

[![GitHub release](https://img.shields.io/github/v/release/GameFrameX/com.gameframex.unity.coroutine?style=flat-square)](https://github.com/GameFrameX/com.gameframex.unity.coroutine/releases)
[![License](https://img.shields.io/github/license/GameFrameX/com.gameframex.unity.coroutine?style=flat-square)](https://github.com/GameFrameX/com.gameframex.unity.coroutine/blob/main/LICENSE.md)
[![Documentation](https://img.shields.io/badge/Documentation-Online-blue?style=flat-square)](https://gameframex.doc.alianblank.com)

**インディゲーム開発者向けオールインワンソリューション · インディ開発者の夢を支援**

[ドキュメント](https://gameframex.doc.alianblank.com) · [クイックスタート](#クイックスタート) · [QQグループ](https://qm.qq.com/q/5s5e1e6e6e)

**言語**: [English](README.md) | [简体中文](README.zh-CN.md) | [繁體中文](README.zh-TW.md) | **日本語** | [한국어](README.ko.md)

---

## プロジェクト概要

Game Frame X Coroutine は、GameFrameX フレームワークに基づく Unity コルーチン管理パッケージで、Unity の組み込みコルーチン管理機能を拡張します。

**Coroutine コンポーネント (Coroutine Component)** - Unity の組み込みコルーチン管理機能を拡張するインターフェースを提供します。

## 機能

1. **コルーチンの開始**: `StartCoroutine(IEnumerator enumerator)` メソッドでコルーチンを開始。イテレータと Unity コルーチンオブジェクトは並行ディクショナリに保存され、いつでもアクセス・管理可能。

2. **コルーチンの停止**: `StopCoroutine(IEnumerator enumerator)` または `StopCoroutine(UnityEngine.Coroutine coroutine)` で個別のコルーチンを停止。Unity と内部ディクショナリの両方から削除し、メモリリークを防止。

3. **全コルーチンの停止**: `StopAllCoroutines()` メソッドで実行中の全コルーチンを停止。クリーンな停止と内部追跡ディクショナリのクリアを保証。

4. **フレーム終了時コールバック**: `WaitForEndOfFrameFinish(System.Action callback)` メソッドで現在のフレームのレンダリング完了後にコールバックを実行。

## クイックスタート

### 動作環境

- Unity 2017.1 以上

### インストール

以下のいずれかの方法を選択してください：

1. プロジェクトの `manifest.json` の `dependencies` セクションに以下を追加：
   ```json
   {"com.gameframex.unity.coroutine": "https://github.com/AlianBlank/com.gameframex.unity.coroutine.git"}
   ```

2. Unity の Package Manager で `Git URL` を使用：
   ```
   https://github.com/AlianBlank/com.gameframex.unity.coroutine.git
   ```

3. リポジトリをダウンロードして Unity プロジェクトの `Packages` ディレクトリに配置。自動的にロードされます。

## 使用例

### コルーチンの開始

```csharp
IEnumerator YourCoroutine()
{
    // コルーチンの実行内容
    yield return null;
}

CoroutineComponent coroutineComponent = gameObject.AddComponent<CoroutineComponent>();
coroutineComponent.StartCoroutine(YourCoroutine());
```

### コルーチンの停止

```csharp
IEnumerator yourCoroutine = YourCoroutine();
coroutineComponent.StopCoroutine(yourCoroutine);
```

### 全コルーチンの停止

```csharp
coroutineComponent.StopAllCoroutines();
```

### フレーム終了時コールバック

```csharp
void YourCallback()
{
    // コールバックの実行内容
}

coroutineComponent.WaitForEndOfFrameFinish(YourCallback);
```

注：`CoroutineComponent` を GameObject に追加する際、同じタイプのコンポーネントが他にないことを確認してください。このクラスは `[DisallowMultipleComponent]` 属性を使用しています。

## ドキュメントとリソース

- ドキュメント: https://gameframex.doc.alianblank.com
- リポジトリ: https://github.com/GameFrameX/com.gameframex.unity.coroutine
- イシュー: https://github.com/GameFrameX/com.gameframex.unity.coroutine/issues

## ライセンス

詳細は [LICENSE](LICENSE.md) をご覧ください。

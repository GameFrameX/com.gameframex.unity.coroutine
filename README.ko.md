<div align="center">

<img src="https://download.alianblank.com/gameframex/gameframex_logo_320.png" alt="Game Frame X Logo" width="160" />

# Game Frame X Coroutine

[![GitHub release](https://img.shields.io/github/v/release/GameFrameX/com.gameframex.unity.coroutine?style=flat-square)](https://github.com/GameFrameX/com.gameframex.unity.coroutine/releases)
[![License](https://img.shields.io/github/license/GameFrameX/com.gameframex.unity.coroutine?style=flat-square)](https://github.com/GameFrameX/com.gameframex.unity.coroutine/blob/main/LICENSE.md)
[![Documentation](https://img.shields.io/badge/Documentation-Online-blue?style=flat-square)](https://gameframex.doc.alianblank.com)

**인디 게임 개발자를 위한 올인원 솔루션 · 인디 개발자의 꿈을 실현**

[문서](https://gameframex.doc.alianblank.com) · [빠른 시작](#빠른-시작) · [QQ 그룹](https://qm.qq.com/q/5s5e1e6e6e)

**언어**: [English](README.md) | [简体中文](README.zh-CN.md) | [繁體中文](README.zh-TW.md) | [日本語](README.ja.md) | **한국어**


</div>

---

## 프로젝트 개요

Game Frame X Coroutine은 GameFrameX 프레임워크 기반의 Unity 코루틴 관리 패키지로, Unity의 내장 코루틴 관리 기능을 확장합니다.

**Coroutine 컴포넌트 (Coroutine Component)** - Unity의 내장 코루틴 관리 기능을 확장하는 인터페이스를 제공합니다.

## 기능

1. **코루틴 시작**: `StartCoroutine(IEnumerator enumerator)` 메서드로 코루틴을 시작합니다. 이터레이터와 Unity 코루틴 객체는 동시성 딕셔너리에 저장되어 언제든 접근하고 관리할 수 있습니다.

2. **코루틴 중지**: `StopCoroutine(IEnumerator enumerator)` 또는 `StopCoroutine(UnityEngine.Coroutine coroutine)`으로 개별 코루틴을 중지합니다. Unity와 내부 딕셔너리 모두에서 제거하여 메모리 누수를 방지합니다.

3. **모든 코루틴 중지**: `StopAllCoroutines()` 메서드로 실행 중인 모든 코루틴을 중지하고 내부 추적 딕셔너리를 비웁니다.

4. **프레임 종료 시 콜백**: `WaitForEndOfFrameFinish(System.Action callback)` 메서드로 현재 프레임 렌더링 완료 후 콜백을 실행합니다.

## 빠른 시작

### 시스템 요구 사항

- Unity 2017.1 이상

### 설치

다음 방법 중 하나를 선택하세요:

1. 프로젝트의 `manifest.json` 파일의 `dependencies` 섹션에 다음 내용을 추가:
   ```json
   {"com.gameframex.unity.coroutine": "https://github.com/AlianBlank/com.gameframex.unity.coroutine.git"}
   ```

2. Unity의 Package Manager에서 `Git URL`을 사용하여 추가:
   ```
   https://github.com/AlianBlank/com.gameframex.unity.coroutine.git
   ```

3. 저장소를 다운로드하여 Unity 프로젝트의 `Packages` 디렉토리에 배치하면 자동으로 로드됩니다.

## 사용 예시

### 코루틴 시작

```csharp
IEnumerator YourCoroutine()
{
    // 코루틴 실행 내용
    yield return null;
}

CoroutineComponent coroutineComponent = gameObject.AddComponent<CoroutineComponent>();
coroutineComponent.StartCoroutine(YourCoroutine());
```

### 코루틴 중지

```csharp
IEnumerator yourCoroutine = YourCoroutine();
coroutineComponent.StopCoroutine(yourCoroutine);
```

### 모든 코루틴 중지

```csharp
coroutineComponent.StopAllCoroutines();
```

### 프레임 종료 시 콜백 실행

```csharp
void YourCallback()
{
    // 콜백 실행 내용
}

coroutineComponent.WaitForEndOfFrameFinish(YourCallback);
```

참고: `CoroutineComponent`를 GameObject에 추가할 때, 같은 타입의 다른 컴포넌트가 없는지 확인하세요. 이 클래스는 `[DisallowMultipleComponent]` 속성을 사용합니다.

## 문서 및 자료

- 문서: https://gameframex.doc.alianblank.com
- 저장소: https://github.com/GameFrameX/com.gameframex.unity.coroutine
- 이슈: https://github.com/GameFrameX/com.gameframex.unity.coroutine/issues

## 라이선스

자세한 내용은 [LICENSE](LICENSE.md)를 참조하세요.

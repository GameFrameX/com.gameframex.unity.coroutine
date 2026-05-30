using NUnit.Framework;

namespace GameFrameX.Coroutine.Tests
{
    internal class UnitTests
    {
        [Test]
        public void TestPlaceholder()
        {
            // Coroutine 模块依赖 Unity 运行时（MonoBehaviour、StartCoroutine），
            // 无法在纯 NUnit 环境中直接测试协程逻辑。
            // 协程相关的集成测试应在 Unity PlayMode 测试中编写。
            Assert.Pass("Coroutine module requires Unity runtime for testing.");
        }
    }
}

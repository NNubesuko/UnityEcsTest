using System;
using NUnit.Framework;
using Utility.Authoring;

namespace Tests.EditMode.Authoring
{
    [Description("移動速度のテスト")]
    public class MoveSpeedTest
    {
        [Test]
        [TestCase(0f)]
        [TestCase(50f)]
        [TestCase(100f)]
        [Description("[正常] 渡された値が最小値以上最大値以下である場合に、値が正常に格納されること")]
        public void ValidMoveSpeed(float value)
        {
            MoveSpeed moveSpeed = MoveSpeed.Of(value);
            Assert.That(moveSpeed, Is.EqualTo(MoveSpeed.Of(value)));
        }

        [Test]
        [TestCase(float.MinValue)]
        [TestCase(-1f)]
        [TestCase(101f)]
        [TestCase(float.MaxValue)]
        [Description("[異常] 渡された数値が最小値より小さいか最大値より大きい場合に、スローが投げられること")]
        public void InvalidMoveSpeed(float value)
        {
            Assert.That(
                () =>
                {
                    MoveSpeed moveSpeed = MoveSpeed.Of(value);
                },
                Throws.TypeOf<ArgumentException>());
        }
    }
}
using System;
using Feature.MovingPaths.Authoring;
using NUnit.Framework;

namespace Tests.EditMode.Authoring
{
    [System.ComponentModel.Description("移動経路のインデックスのテスト")]
    public class MovingPathsTableIndexTest
    {
        [Test]
        [TestCase(0)]
        [TestCase(10)]
        [TestCase(20)]
        [Description("[正常] 渡された値が最小値以上最大値以内である場合に、値が正常に格納されること")]
        public void ValidMovingPathsTableIndex(int value)
        {
            MovingPathsTableIndex movingPathsTableIndex = MovingPathsTableIndex.Of(value);
            Assert.That(movingPathsTableIndex, Is.EqualTo(MovingPathsTableIndex.Of(value)));
        }

        [Test]
        [TestCase(int.MinValue)]
        [TestCase(-1)]
        [TestCase(21)]
        [TestCase(int.MaxValue)]
        [Description("[異常] 渡された値が最小値より小さいか最大値より大きい場合に、スローが投げられること")]
        public void InvalidMovingPathsTableIndex(int value)
        {
            Assert.That(
                () =>
                {
                    MovingPathsTableIndex movingPathsTableIndex = MovingPathsTableIndex.Of(value);
                },
                Throws.TypeOf<ArgumentException>());
        }
    }
}
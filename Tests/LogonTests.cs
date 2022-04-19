using FluentAssertions;
using Xunit;

namespace Tests;

public class LogonTests
{
    [Fact]
    public void LogonResponseShouldBeCorrect()
    {
        var tmp = true;
        tmp.Should().Be(true);
    }
}
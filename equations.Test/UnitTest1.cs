namespace equations.Test;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestMethod1()
    {
        string result = equations.Program.Principal("x", "+", -3);
        Assert.AreEqual("x = 3", result);
    }

    [TestMethod]
    public void TestMethod2()
    {
        string result = equations.Program.Principal("x", "+", -2);
        Assert.AreEqual("x = 2", result);
    }
}
using PaymentContext.Domain.Entities;

namespace PaymentContext.Tests;

[TestClass]
public class StudentTests
{
    [TestMethod]
    public void TestMethod1()
    {
        var student = new Student("nome","sobrenome","123","a@a.c");
    }
}
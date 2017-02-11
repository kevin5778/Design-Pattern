using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Reference:https://zh.wikipedia.org/wiki/%E5%A7%94%E6%89%98%E6%A8%A1%E5%BC%8F
interface I
{
    void f();
    void g();
}
class A : I
{
    public void f()
    {
        Console.WriteLine("A: doing f()");
    }
    public void g()
    {
        Console.WriteLine("A: doing g()");
    }
}

class B : I
{
    public void f()
    {
        Console.WriteLine("B: doing f()");
    }
    public void g()
    {
        Console.WriteLine("B: doing g()");
    }
}

/// <summary>
/// Proxy
/// </summary>
class C : I
{
    // delegation
    I i = new A();

    public void f() { i.f(); }
    public void g() { i.g(); }

    // normal attributes
    public void toA() { i = new A(); }
    public void toB() { i = new B(); }
}
class Program
{
    static void Main(string[] args)
    {
        C c = new C();
        c.f();
        c.g();
        c.toB();
        c.f();
        c.g();
        Console.ReadLine();
    }
}

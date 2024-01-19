namespace PL;

public class A : B
{
    public new string MetodoA()
    {
        return base.MetodoA() + " - Termine mi prueba";
    }
}

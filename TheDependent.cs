namespace dotnetwebapi;

public class TheDependent
{
    public TheDependent(TheDependency t)
    {
        t.ItWorks();
    }
}
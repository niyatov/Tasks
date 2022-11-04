namespace Identity_Task2;

public class Option
{
    public readonly string path;
    public Option(IConfiguration configuration)
    {
        path = configuration["PathJsonFile"];
    }
}

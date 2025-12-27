public class Singleton{
  public int Value {get;set;}
  private static Singleton instance = new Singleton();
  private Singleton(){}
  public static Singleton GetInstance()
  {
    return instance;
  }
};

public class Program
{
  public static void Main(string[] args)
  {
    var instance = Singleton.GetInstance();
    var instance2 = Singleton.GetInstance();
    instance2.Value = 3;
    instance.Value = 1;
    Console.WriteLine($"Value: {instance2.Value}");
  }
}

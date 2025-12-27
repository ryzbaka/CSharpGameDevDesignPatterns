public interface IObserver<T>
{
  void Update(T value);
};

public interface IObservable<T>
{
  void NotifyObservers(T value);
  void AddObserver(IObserver<T> o);
}

public class Enemy: IObserver<string>
{
  public void Update(string value)
  {
    switch (value)
    {
      case "player said hi":
        Console.WriteLine("Enemy says hello");
        break;
      default:
        break;
    }
  }
}

public class Player:IObservable<string>
{
  private List<IObserver<string>> _observers = new List<IObserver<string>>();
  private static Player instance = new Player();
  //making constructor private -> see singleton
  private Player(){}
  public void NotifyObservers(string value)
  {
    foreach (var observer in _observers)
    {
       observer.Update(value); 
    }
  }
  public void AddObserver(IObserver <string> o)
  {
    _observers.Add(o);
  }
  public static Player GetInstance() // see singleton
  {
    return instance;
  }
  public void SayHello()
  {
    Console.WriteLine("Hi");
    NotifyObservers("player said hi");
  }
}

public class Program{
  public static void Main(string[] args)
  {
    var player = Player.GetInstance();
    var enemy = new Enemy();
    player.AddObserver(enemy);
    player.SayHello();
  }
}

public class Entity{
  public string name{get; set;}
  public Entity(string n)
  {
    name = n;
  }
  public virtual void Interact(string subject)
  {
    Console.WriteLine($"Entity <{name}> interacted wtih {subject}.");
  }
}

public class Player: Entity
{
  public int Value{get;set;}
  private static Player instance = new Player();
  private Player():base("Player"){} //need to call base Entity contructol before the Player (inheritor) constructor
  
  public static Player GetInstance(){
    return instance; 
  }
  public override void Interact(string subject)
  {
    Console.WriteLine($"Player interacted with {subject}");
  }
}

public class Program
{
  public static void Main(string[] args)
  {
    Entity stoneGolem = new Entity("Stone Golem");
    Player player = Player.GetInstance();

    stoneGolem.Interact("Door");
    player.Interact("Door");
  }
}

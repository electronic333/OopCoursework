namespace OopCoursework;

public class Creature: IEquatable<Creature> {
  public int X { get; set; }
  public int Y { get; set; }

  public bool Equals (Creature? another) {
    return another != null && X == another.X && Y == another.Y;
  }
}

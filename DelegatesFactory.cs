namespace OopCoursework;

#nullable disable

public static class DelegatesFactory {
  private static readonly Random Rnd = new();

  public static Func<Creature> UniqueCreatureInBordersGenerator (
    IEnumerable<Creature> creatures,
    int height,
    int width
  ) {
    int x = 0, y = 0;
    Creature creature = null;
    return () => {
      do {
        x = Rnd.Next(width);
        y = Rnd.Next(height);
        creature = new Creature() { X = x, Y = y };
      } while (creatures.Contains(creature));
      return creature;
    };
  }
}

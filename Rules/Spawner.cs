namespace OopCoursework.Rules;

public class Spawner: IRule {
  private readonly IList<Creature> _creatures;
  private readonly Func<Creature> _generator;

  public Spawner (IList<Creature> creatures, Func<Creature> generator) {
    _creatures = creatures;
    _generator = generator;
  }

  public void Apply () {
    _creatures.Add(_generator());
  }
}

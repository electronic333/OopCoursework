using System.Text;
using OopCoursework;
using OopCoursework.Rules;

var emptySymbol = '.';
var plantSymbol = 'P';
var herbivoreSymbol = 'H';
var carnivoreSymbol = 'C';

var printWidth = 10;
var printHeight = 10;

var delta = 400;

var printArray = new char[printHeight, printWidth];

var plants = new List<Creature>();
var herbivores = new List<Creature>();
var carnivores = new List<Creature>();

var rules = new IRule[] {
  new Spawner(plants, DelegatesFactory.UniqueCreatureInBordersGenerator(plants, printHeight, printWidth))
};

while (true) {
  Update(rules);
  Thread.Sleep(delta);
  WriteToArray(
    printArray, 
    emptySymbol, 
    (plants, plantSymbol), 
    (herbivores, herbivoreSymbol), 
    (carnivores, carnivoreSymbol)
  );
  Print(printArray);
}

static void Update (IEnumerable<IRule> rules) {
  foreach (var rule in rules) rule.Apply();
}

static void WriteToArray (
  char[,] printArray,
  char emptyCell,
  params (IEnumerable<Creature> creatures, char symbol)[] creatureLists
) {
  Fill(printArray, emptyCell);
  AddCreatures(printArray, creatureLists);
}

static void Fill (char[,] array, char symbol) {
  for (int i = 0; i < array.GetLength(0); i++) {
    for (int j = 0; j < array.GetLength(1); j++) {
      array[i, j] = symbol;
    }
  }
}

static void AddCreatures (char[,] array, (IEnumerable<Creature> creatures, char symbol)[] creatureLists) {
  foreach (var creatureList in creatureLists) {
    foreach (var creature in creatureList.creatures) {
      try {
        array[creature.Y, creature.X] = creatureList.symbol;
      }
      catch {
        continue;
      }
    }
  }
}

static void Print (char[,] array) {
  var height = array.GetLength(0);
  var width = array.GetLength(1);
  var builder = new StringBuilder(height * (width + 1));
  for (int i = 0; i < height; i++) {
    for (int j = 0; j < width; j++) {
      builder.Append(array[i, j]);
    }
    builder.Append('\n');
  }
  Console.Clear();
  Console.WriteLine(builder.ToString());
}

namespace Simulator
{
    public abstract class Creature
    {
        private string name = "Unknown";
        private int level = 1;
        public string Name
        {
            get { return name; }
            init => name = Validator.Shortener(value, 3, 25, '#');
        }
        public int Level
        {
            get { return level; }
            init => level = Validator.Limiter(value, 1, 10);
        }

        public Creature(string name, int level = 1)
        {
            Level = level;
            Name = name;
        }

        public Creature() { }

        public abstract void SayHi();

        public abstract string Info { get; }

        public void Upgrade()
        {
            this.level = this.level < 10 ? ++this.level : 10;
        }

        public void Go(Direction direction)
        {
            string directionLower = direction.ToString().ToLower();
            Console.WriteLine($"{name} goes to {directionLower}");
        }
        public void Go(Direction[] directions)
        {
            foreach (var direction in directions) Go(direction);
        }
        public void Go(string directions)
        {
            Direction[] directionParsed = DirectionParser.Parse(directions);
            Go(directionParsed);
        }

        public abstract int Power
        { get; }


    }
}
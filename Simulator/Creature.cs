namespace Simulator
{
    public class Creature
    {
        private string name = "Unknown";
        private int level = 1;
        public string Name
        {
            get { return name; }
            init
            {
                value = value.Trim();
                if (value.Length > 25)
                {
                    value = value.Substring(0, 25).TrimEnd();
                }
                if (value.Length < 3)
                {
                    value = value.PadRight(3, '#');
                }
                if (value.Length > 0 && char.IsLower(value[0]))
                {
                    value = char.ToUpper(value[0]) + value.Substring(1);
                }
                name = name.ToUpper()[0] + name[1..name.Length];
            }
        }
        public int Level
        {
            get { return level; }
            init
            {
                level = (value >= 1 && value <= 10) ? value : (value < 1 ? 1 : 10);
            }
        }

        public Creature(string name, int level = 1)
        {
            Level = level;
            Name = name;
        }

        public Creature() { }

        public void SayHi() => Console.WriteLine($"Hi, my name is {Name}, my level is {Level}");

        public string Info => $"{Name} - {Level}";

        public void Upgrade()
        {
            this.level = this.level < 10 ? ++this.level : 10;
        }

       
    }
}
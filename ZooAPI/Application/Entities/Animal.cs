using System.Diagnostics.Eventing.Reader;

namespace ZooAPI.Application.Entities
{
    public class Animal
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        private int _energy;
        public int Energy
        {
            get { return _energy; }
            set
            {
                if (value >= 100)
                {
                    {
                        _energy = 100;
                    }
                }
                else
                {
                    _energy = value;
                }
            }
        }

    }
}

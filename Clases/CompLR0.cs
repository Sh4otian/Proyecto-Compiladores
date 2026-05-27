using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Clases
{
    public class LR0Item
    {
        public Production Production { get; set; }

        public int DotPosition { get; set; }

        public LR0Item(
            Production production,
            int dotPosition)
        {
            Production = production;
            DotPosition = dotPosition;
        }

        public bool IsComplete =>
            DotPosition >= Production.Right.Count;

        public string SymbolAfterDot =>
            IsComplete
                ? null
                : Production.Right[DotPosition];

        public override bool Equals(object obj)
        {
            if (!(obj is LR0Item other))
                return false;

            return Production.Id ==
                   other.Production.Id
                && DotPosition ==
                   other.DotPosition;
        }

        public override int GetHashCode()
        {
            return (Production.Id, DotPosition)
                .GetHashCode();
        }

        public override string ToString()
        {
            var right =
                Production.Right.ToList();

            right.Insert(DotPosition, "·");

            return $"{Production.Left} -> " +
                   $"{string.Join(" ", right)}";
        }
    }

    public class LR0State
    {
        public int Id { get; set; }

        public HashSet<LR0Item> Items
            = new HashSet<LR0Item>();

        public Dictionary<string, int>
            Transitions
            = new Dictionary<string, int>();

        public override string ToString()
        {
            return $"I{Id}";
        }
    }

}

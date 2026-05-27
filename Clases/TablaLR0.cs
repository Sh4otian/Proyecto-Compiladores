using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Clases
{
    public class LR0ParsingTable
    {
        // ACTION[state, terminal]
        public Dictionary<(int, string), string>
            Action
            = new Dictionary<(int, string), string>();

        // GOTO[state, nonterminal]
        public Dictionary<(int, string), int>
            Goto
            = new Dictionary<(int, string), int>();

        public List<string> Conflicts
            = new List<string>();
    }
    public class LR0Builder
    {
        // =====================================================
        // CLOSURE
        // =====================================================

        public HashSet<LR0Item> Closure(
            Grammar grammar,
            HashSet<LR0Item> items)
        {
            var closure =
                new HashSet<LR0Item>(items);

            bool changed;

            do
            {
                changed = false;

                var current =
                    closure.ToList();

                foreach (var item in current)
                {
                    var symbol =
                        item.SymbolAfterDot;

                    if (symbol == null)
                        continue;

                    if (!grammar.IsNonTerminal(symbol))
                        continue;

                    var productions =
                        grammar.Productions
                            .Where(p => p.Left == symbol);

                    foreach (var production in productions)
                    {
                        var newItem =
                            new LR0Item(
                                production,
                                0);

                        if (closure.Add(newItem))
                            changed = true;
                    }
                }

            } while (changed);

            return closure;
        }

        // =====================================================
        // GOTO
        // =====================================================

        public HashSet<LR0Item> Goto(
            Grammar grammar,
            HashSet<LR0Item> items,
            string symbol)
        {
            var moved =
                new HashSet<LR0Item>();

            foreach (var item in items)
            {
                if (item.SymbolAfterDot == symbol)
                {
                    moved.Add(
                        new LR0Item(
                            item.Production,
                            item.DotPosition + 1));
                }
            }

            return Closure(grammar, moved);
        }

        // =====================================================
        // COLECCIÓN CANÓNICA
        // =====================================================

        public List<LR0State> BuildStates(
            Grammar grammar)
        {
            var states =
                new List<LR0State>();

            // item inicial
            var startItem =
                new LR0Item(
                    grammar.Productions[0],
                    0);

            var startClosure =
                Closure(
                    grammar,
                    new HashSet<LR0Item>
                    {
                        startItem
                    });
            Console.WriteLine("CLOSURE I0:");

            foreach (var item in startClosure)
            {
                Console.WriteLine(item);
            }
            var startState =
                new LR0State
                {
                    Id = 0,
                    Items = startClosure
                };

            states.Add(startState);

            var queue =
                new Queue<LR0State>();

            queue.Enqueue(startState);

            while (queue.Count > 0)
            {
                var state =
                    queue.Dequeue();

                var symbols =
                    state.Items
                        .Where(i =>
                            i.SymbolAfterDot != null)
                        .Select(i =>
                            i.SymbolAfterDot)
                        .Distinct()
                        .ToList();

                foreach (var symbol in symbols)
                {
                    var gotoSet =
                        Goto(
                            grammar,
                            state.Items,
                            symbol);

                    if (gotoSet.Count == 0)
                        continue;

                    var existing =
                        states.FirstOrDefault(s =>
                            s.Items.SetEquals(gotoSet));

                    if (existing == null)
                    {
                        existing =
                            new LR0State
                            {
                                Id = states.Count,
                                Items = gotoSet
                            };

                        states.Add(existing);

                        queue.Enqueue(existing);
                    }

                    state.Transitions[symbol]
                        = existing.Id;
                }
            }

            return states;
        }

        // =====================================================
        // TABLA LR(0)
        // =====================================================

        public LR0ParsingTable BuildParsingTable(
            Grammar grammar,
            List<LR0State> states)
        {
            var table = new LR0ParsingTable();

            foreach (var state in states)
            {
                // =========================
                // SHIFT + GOTO
                // =========================
                foreach (var transition in state.Transitions)
                {
                    var symbol = transition.Key;
                    var nextState = transition.Value;

                    if (grammar.IsTerminal(symbol))
                    {
                        AddAction(table, state.Id, symbol, $"d{nextState}");
                    }
                    else
                    {
                        table.Goto[(state.Id, symbol)] = nextState;
                    }
                }

                // =========================
                // REDUCE / ACCEPT (CORRECTO LR(0))
                // =========================
                foreach (var item in state.Items)
                {
                    if (!item.IsComplete)
                        continue;

                    // ACCEPT
                    if (item.Production.Id == 0)
                    {
                        AddAction(table, state.Id, "$", "acc");
                        continue;
                    }

                    // REDUCE LR(0): en TODOS los terminales
                    foreach (var terminal in grammar.Terminals)
                    {
                        AddAction(table, state.Id, terminal, $"r{item.Production.Id}");
                    }
                }
            }

            return table;
        }
        // =====================================================
        // ADD ACTION
        // =====================================================

        private void AddAction(
            LR0ParsingTable table,
            int state,
            string terminal,
            string action)
        {
            var key =
                (state, terminal);

            if (table.Action.ContainsKey(key))
            {
                table.Conflicts.Add(
                    $"Conflicto en ACTION[{state}, {terminal}]");
            }
            else
            {
                table.Action[key] = action;
            }
        }
    }
}

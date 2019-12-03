using System;
using System.Linq;

namespace Day2
{
    public class IntCodeInterpreter
    {
        private int[] _memory;

        public string[] Output => _memory.Select(i => i.ToString()).ToArray();
         

        public IntCodeInterpreter(string[] input)
        {
            _memory = input.Select(int.Parse).ToArray();
        }

        public void Run()
        {
            for (var ip = 0; ip < _memory.Length; ip += 4)
            {
                var end = ip + Math.Min(4, _memory.Length - ip);
                var instruction = ParseInstruction(_memory[ip..end]);
                
                if (instruction is HaltInstruction) break;
                
                _memory = instruction.Execute();
            }
        }

        private IInstruction ParseInstruction(int[] instruction)
        {
            return instruction[0] switch
            {
                1 => (IInstruction)new AddInstruction(instruction[1], instruction[2], instruction[3], _memory),
                2 => new MultiplyInstruction(instruction[1], instruction[2], instruction[3], _memory),
                99 => new HaltInstruction(_memory),
                _ => throw new InvalidOperationException("Do not understand instruction")
            };
        }
    }
}
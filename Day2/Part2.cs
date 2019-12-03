using System.IO;

namespace Day2
{
    class Part2 : IDayPart
    {
        private readonly string[] _input;
        public string Result { get; private set; }
        public Part2(string filename)
        {
            _input = File.ReadAllText(filename).Split(',');
        }
        public void Solve()
        {
            for (var noun = 0; noun < 100; noun++)
            for (var verb = 0; verb < 100; verb++)
            {
                _input[1] = noun.ToString();
                _input[2] = verb.ToString();
                var interpreter = new IntCodeInterpreter(_input);
                interpreter.Run();
                if (interpreter.Output[0] == "19690720")
                {
                    Result = (100 * noun + verb).ToString();
                    break;
                }
            }
        }
    }
}
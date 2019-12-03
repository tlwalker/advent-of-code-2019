using System.IO;

namespace Day2
{
    class Part1 : IDayPart
    {

        public string Result { get; private set; }

        private readonly string[] _input;
        public Part1(string filename)
        {
            _input = File.ReadAllText(filename).Split(',');
        }
        public void Solve()
        {
            _input[1] = "12";
            _input[2] = "2";
            var interpreter = new IntCodeInterpreter(_input);
            interpreter.Run();
            Result = interpreter.Output[0];
        }
    }
}
namespace Day2
{
    class HaltInstruction : IInstruction
    {
        private readonly int[] _memory;

        public HaltInstruction(int[] memory)
        {
            _memory = memory;
        }

        public int[] Execute()
        {
            return _memory;
        }
    }
}
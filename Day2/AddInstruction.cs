namespace Day2
{
    class AddInstruction : IInstruction
    {
        private readonly int _address1;
        private readonly int _address2;
        private readonly int _resultPtr;
        private readonly int[] _memory;

        public AddInstruction(int address1, int address2, int resultPtr, int[] memory)
        {
            _address1 = address1;
            _address2 = address2;
            _resultPtr = resultPtr;
            _memory = memory;
        }

        public int[] Execute()
        {
            _memory[_resultPtr] = _memory[_address1] + _memory[_address2];

            return _memory;
        }
    }
}
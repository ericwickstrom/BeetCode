namespace BeetCode.Framework
{
    public class TestCase
    {
        public string Name { get; set; }
        public object[] Input { get; set; }
        public object Expected { get; set; }

        public TestCase(string name, object[] input, object expected)
        {
            Name = name;
            Input = input;
            Expected = expected;
        }
    }
}
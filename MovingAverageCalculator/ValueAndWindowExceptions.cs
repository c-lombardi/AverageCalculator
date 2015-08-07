using System;

namespace MovingAverageCalculator
{
    public class ValueCountLessThanWindowException : Exception
    {
        public ValueCountLessThanWindowException() { }
        public ValueCountLessThanWindowException(string message) { }
        public ValueCountLessThanWindowException(string message, System.Exception exception) { }
    }
    public class BadWindowException : Exception
    {
        public BadWindowException() { }
        public BadWindowException(string message) { }
        public BadWindowException(string message, System.Exception exception) { }
    }
    public class ValuesCountException : Exception
    {
        public ValuesCountException() { }
        public ValuesCountException(string message) { }
        public ValuesCountException(string message, System.Exception exception) { }
    }
}

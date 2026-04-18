using System;
public class GameRuleException : Exception
{
    public GameRuleException(string message) : base(message){}
}
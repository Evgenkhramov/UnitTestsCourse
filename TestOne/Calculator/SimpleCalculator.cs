﻿namespace Calculator;

public class SimpleCalculator
{
    public int Add(int a, int b) => a+b;

    public decimal Add(decimal a, decimal b) => Math.Round(a + b, 2);
    public int Subtract(int a, int b) => a - b;
    public int Multiply(int a, int b) => a * b;
    public int Divide(int a, int b)
    {
        if (b == 0)
            throw new DivideByZeroException("Cannot divide by zero");
        return a / b;
    }
}

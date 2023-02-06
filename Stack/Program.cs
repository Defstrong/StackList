using Stack.Stack;

var stack = new CustomStack<int>();

stack.Push(1);

if (stack.IsEmpty())
    Console.WriteLine("Stack is empty");

foreach(var ii in stack)
    Console.WriteLine(ii);
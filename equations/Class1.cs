namespace equations;

public sealed class Equation
{
    public EquationNode Root {get; private set;}

    public Equation(EquationNode root)
    {
        Root = root ?? throw new ArgumentNullException(nameof(root));
    }
}

public abstract class EquationNode
{
    public abstract double Evaluate();
}

public sealed class ConstantNode: EquationNode
{
    public double Value {get;}

    public ConstantNode(double value)
    {
        Value = value;
    }

    public override double Evaluate()
    {
        return Value;
    }
}

public sealed class VariableNode : EquationNode
{
    public string Name {get;}

    public VariableNode(string name)
    {
        Name =  name;
    }

    public override double Evaluate()
    {
        throw new InvalidOperationException("No");
    }
}

public sealed class OperationNode : EquationNode
{
    public EquationNode Left {get;}
    public EquationNode Right {get;}
    public string Operation {get;}

    public OperationNode(string operation, EquationNode left, EquationNode right)
    {
        Operation = operation ?? throw new ArgumentNullException(nameof(operation));
        Left = left ?? throw new ArgumentNullException(nameof(left));
        Right = right ?? throw new ArgumentNullException(nameof(right));
    }

    public override double Evaluate()
    {
        switch (Operation)
        {
            case "+":
                return Left.Evaluate() + Right.Evaluate();
                
            case "-":
                return Left.Evaluate() - Right.Evaluate();

            default:
                throw new InvalidOperationException("No");
        }
    }
}

public class EquationSolver
{
    public double Solve(Equation equation)
    {
        var root = equation.Root as OperationNode;
        if (root == null || !(root.Left is VariableNode) || !(root.Right is ConstantNode))
        {
            throw new InvalidOperationException("no");
        }

            return -root.Right.Evaluate();
    }
}

public class Program
{
    public static string Principal (string variable, string operation, double constant)
    {
        var variableNode = new VariableNode(variable);
        var constantNode = new ConstantNode(constant);
        var rootNode = new OperationNode(operation, variableNode, constantNode);

        var equation = new Equation(rootNode);

        var solver = new EquationSolver();
        var result = solver.Solve(equation);

        return $"{variable} = {result}";
    }
}


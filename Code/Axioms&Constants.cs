using System.Numerics;

namespace EmlMath;

partial class Core
{
    /// <summary>
    /// Gets the complex number 1.
    /// </summary>
    public static Complex One => Complex.One;

    /// <summary>
    /// Gets the complex number 0, derived as <c>Ln(1)</c>.
    /// </summary>
    public static Complex Zero { get; }

    /// <summary>
    /// Gets the imaginary unit <c>i</c>, derived as <c>Sqrt(-1)</c>.
    /// </summary>
    public static Complex I { get; }

    /// <summary>
    /// Gets the mathematical constant π, derived as <c>-i * Ln(-1)</c>.
    /// </summary>
    public static Complex PI { get; }

    /// <summary>
    /// Gets the mathematical constant e, derived as <c>Exp(1)</c>.
    /// </summary>
    public static Complex E { get; }

    // Internal constants (used only for definitions)
    private static Complex NegativeOne { get; }
    private static Complex Two { get; }
    private static Complex Three { get; }
    private static Complex TwoI { get; }
    private static Complex IOverTwo { get; } // i/2
    private static Complex NegativeI { get; } // -i
    private static Complex Ten { get; }

    static Core()
    {
        E = Exp(One);
        Zero = Ln(One);
        NegativeOne = Neg(One);
        Two = Add(One, One);
        Three = Add(Two, One);
        Ten = Add(Mul(Three, Three), One);
        I = Sqrt(NegativeOne);
        PI = Mul(Neg(I), Ln(NegativeOne));
        TwoI = Add(I, I);
        IOverTwo = Div(I, Two);
        NegativeI = Neg(I);
    }
}

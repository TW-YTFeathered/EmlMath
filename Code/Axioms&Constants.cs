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
    public static Complex Zero => Ln(One);

    /// <summary>
    /// Gets the imaginary unit <c>i</c>, derived as <c>Sqrt(-1)</c>.
    /// </summary>
    public static Complex I => Sqrt(NegativeOne);

    /// <summary>
    /// Gets the mathematical constant π, derived as <c>-i * Ln(-1)</c>.
    /// </summary>
    public static Complex PI => Mul(Neg(I), Ln(NegativeOne));

    // Internal constants (used only for definitions)
    private static Complex NegativeOne => Neg(One);
    private static Complex Two => Add(One, One);
    private static Complex TwoI => Add(I, I);
}

using System.Numerics;

namespace EmlMath;

partial class Core
{
    /// <summary>
    /// Computes the exponential function <c>e^x</c>.
    /// </summary>
    /// <param name="x">The exponent.</param>
    /// <returns><c>e</c> raised to the power <paramref name="x"/>.</returns>
    public static Complex Exp(Complex x) => Eml(x, One);

    /// <summary>
    /// Computes the natural logarithm (base <c>e</c>) of a complex number.
    /// </summary>
    /// <param name="x">The argument.</param>
    /// <returns>The principal value of <c>ln(x)</c>.</returns>
    /// <remarks>
    /// The implementation uses Eml(0,1) - Eml(0,x) as a branchless approach to safely handle x=0 without generating NaN.
    /// </remarks>
    public static Complex Ln(Complex x) => Eml(One, One) - Eml(One, x); // Avoiding branch cutting ambiguity
}

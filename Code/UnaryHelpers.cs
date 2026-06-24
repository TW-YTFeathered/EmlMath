using System.Numerics;

namespace EmlMath;

partial class Core
{
    /// <summary>
    /// Negates a complex number.
    /// </summary>
    /// <param name="y">The number to negate.</param>
    /// <returns><c>-y</c>.</returns>
    public static Complex Neg(Complex y) => Sub(Zero, y);

    /// <summary>
    /// Computes the multiplicative inverse (reciprocal) of a complex number.
    /// </summary>
    /// <param name="y">The number (must not be zero).</param>
    /// <returns><c>1 / y</c>.</returns>
    public static Complex Inv(Complex y) => Exp(Neg(Ln(y)));
}

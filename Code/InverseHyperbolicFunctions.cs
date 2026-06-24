using System.Numerics;

namespace EmlMath;

partial class Core
{
    /// <summary>
    /// Computes the inverse hyperbolic sine (asinh) of a complex number.
    /// </summary>
    /// <param name="x">The argument.</param>
    /// <returns>The principal value of <c>asinh(x)</c>.</returns>
    public static Complex Asinh(Complex x) => Ln(Add(x, Sqrt(Add(Mul(x, x), One))));

    /// <summary>
    /// Computes the inverse hyperbolic cosine (acosh) of a complex number.
    /// </summary>
    /// <param name="x">The argument.</param>
    /// <returns>The principal value of <c>acosh(x)</c>.</returns>
    public static Complex Acosh(Complex x) => Ln(Add(x, Sqrt(Sub(Mul(x, x), One))));

    /// <summary>
    /// Computes the inverse hyperbolic tangent (atanh) of a complex number.
    /// </summary>
    /// <param name="x">The argument.</param>
    /// <returns>The principal value of <c>atanh(x)</c>.</returns>
    public static Complex Atanh(Complex x) => Div(Ln(Div(Add(One, x), Sub(One, x))), Two);
}

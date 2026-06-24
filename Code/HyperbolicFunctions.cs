using System.Numerics;

namespace EmlMath;

partial class Core
{
    /// <summary>
    /// Computes the hyperbolic sine of a complex number.
    /// </summary>
    /// <param name="x">The argument.</param>
    /// <returns><c>sinh(x)</c>.</returns>
    public static Complex Sinh(Complex x) => Div(Sub(Exp(x), Exp(Neg(x))), Two);

    /// <summary>
    /// Computes the hyperbolic cosine of a complex number.
    /// </summary>
    /// <param name="x">The argument.</param>
    /// <returns><c>cosh(x)</c>.</returns>
    public static Complex Cosh(Complex x) => Div(Add(Exp(x), Exp(Neg(x))), Two);

    /// <summary>
    /// Computes the hyperbolic tangent of a complex number.
    /// </summary>
    /// <param name="x">The argument.</param>
    /// <returns><c>tanh(z)</c>.</returns>
    public static Complex Tanh(Complex x) => Div(Sinh(x), Cosh(x));
}

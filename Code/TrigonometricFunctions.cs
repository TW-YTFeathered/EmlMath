using System.Numerics;

namespace EmlMath;

partial class Core
{
    /// <summary>
    /// Computes the sine of a complex number.
    /// </summary>
    /// <param name="x">The angle in radians.</param>
    /// <returns><c>sin(x)</c>.</returns>
    public static Complex Sin(Complex x) => Div(Sub(Exp(Mul(I, x)), Exp(Mul(Neg(I), x))), TwoI);

    /// <summary>
    /// Computes the cosine of a complex number.
    /// </summary>
    /// <param name="x">The angle in radians.</param>
    /// <returns><c>cos(x)</c>.</returns>
    public static Complex Cos(Complex x) => Div(Add(Exp(Mul(I, x)), Exp(Mul(Neg(I), x))), Two);

    /// <summary>
    /// Computes the tangent of a complex number.
    /// </summary>
    /// <param name="x">The angle in radians.</param>
    /// <returns><c>tan(x)</c>.</returns>s
    public static Complex Tan(Complex x) => Div(Sub(Exp(Mul(TwoI, x)), One), Mul(I, Add(Exp(Mul(TwoI, x)), One)));
}

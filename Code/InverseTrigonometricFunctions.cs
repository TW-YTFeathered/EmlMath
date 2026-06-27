using System.Numerics;

namespace EmlMath;

partial class Core
{
    /// <summary>
    /// Computes the inverse sine (arcsine) of a complex number.
    /// </summary>
    /// <param name="x">The value whose arcsine is to be returned.</param>
    /// <returns>The principal value of <c>asin(x)</c>.</returns>
    public static Complex Asin(Complex x) => Mul(NegativeI, Ln(Add(Mul(I, x), Sqrt(Sub(One, Mul(x, x))))));

    /// <summary>
    /// Computes the inverse cosine (arccosine) of a complex number.
    /// </summary>
    /// <param name="x">The value whose arccosine is to be returned.</param>
    /// <returns>The principal value of <c>acos(x)</c>.</returns>
    public static Complex Acos(Complex x) => Mul(NegativeI, Ln(Add(x, Sqrt(Sub(Mul(x, x), One)))));

    /// <summary>
    /// Computes the inverse tangent (arctangent) of a complex number.
    /// </summary>
    /// <param name="x">The value whose arctangent is to be returned.</param>
    /// <returns>The principal value of <c>atan(x)</c>.</returns>
    public static Complex Atan(Complex x) => Mul(IOverTwo, Ln(Div(Add(I, x), Sub(I, x))));
}

using System.Numerics;

namespace EmlMath;

partial class Core
{
    /// <summary>
    /// Subtracts one complex number from another.
    /// </summary>
    /// <param name="x">The minuend.</param>
    /// <param name="y">The subtrahend.</param>
    /// <returns><c>x - y</c>.</returns>
    public static Complex Sub(Complex x, Complex y) => Eml(Ln(x), Exp(y));

    /// <summary>
    /// Adds two complex numbers.
    /// </summary>
    /// <param name="x">The first addend.</param>
    /// <param name="y">The second addend.</param>
    /// <returns><c>x + y</c>.</returns>
    public static Complex Add(Complex x, Complex y) => Sub(x, Neg(y));

    /// <summary>
    /// Multiplies two complex numbers.
    /// <summary>
    /// Multiplies two complex numbers.
    /// </summary>
    /// <param name="x">The first factor.</param>
    /// <param name="y">The second factor.</param>
    /// <returns><c>x * y</c>.</returns>
    /// <remarks>
    /// <para>
    /// The direct definition <c>Exp(Add(Ln(x), Ln(y)))</c> would fail when <c>x</c> or <c>y</c> is zero,
    /// because <c>Ln(0)</c> is undefined. This implementation uses an auxiliary function
    /// <see cref="AssistMul"/> that is derived from the <c>eml</c> operator to avoid the
    /// problematic logarithm, ensuring the product is well‑defined for all finite complex numbers.
    /// </para>
    /// <para>
    /// The formula used is: <c>Eml(AssistMul(x) + AssistMul(y), 1) - x - y - 1</c>,
    /// where <c>AssistMul(z) = 1 - Eml(0, z + 1)</c>.
    /// </para>
    /// </remarks>
    public static Complex Mul(Complex x, Complex y) => Sub(Sub(Sub(Eml(Add(AssistMul(x), AssistMul(y)), One), x), y), One);

    /// <summary>
    /// Divides one complex number by another.
    /// </summary>
    /// <param name="x">The dividend.</param>
    /// <param name="y">The divisor (must not be zero).</param>
    /// <returns><c>x / y</c>.</returns>
    public static Complex Div(Complex x, Complex y) => Mul(x, Inv(y));

    /// <summary>
    /// Auxiliary function used by <see cref="Mul"/> to avoid logarithms of zero.
    /// </summary>
    /// <param name="x">The input value.</param>
    /// <returns><c>1 - Eml(0, x + 1)</c>.</returns>
    /// <remarks>
    /// This helper is part of the construction that eliminates the need to compute <c>Ln(0)</c>
    /// when multiplying by zero. It is not intended for direct external use.
    /// </remarks>
    private static Complex AssistMul(Complex x) => Sub(One, Eml(Zero, Add(x, One)));
}

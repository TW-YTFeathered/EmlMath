using System.Numerics;

namespace EmlMath;

partial class Core
{
    /// <summary>
    /// Computes the logarithm of a complex number with a specified base.
    /// </summary>
    /// <param name="x">The argument.</param>
    /// <param name="baseValue">The base.</param>
    /// <returns><c>log_{baseValue}(x)</c>.</returns>
    public static Complex LogN(Complex x, Complex baseValue) => Div(Ln(x), Ln(baseValue));

    /// <summary>
    /// Computes the common (base‑10) logarithm of a complex number.
    /// </summary>
    /// <param name="x">The argument.</param>
    /// <returns><c>log10(x)</c>.</returns>
    public static Complex Log10(Complex x) => LogN(x, 10);

    /// <summary>
    /// Computes the binary (base‑2) logarithm of a complex number.
    /// </summary>
    /// <param name="x">The argument.</param>
    /// <returns><c>log2(x)</c>.</returns>
    public static Complex Log2(Complex x) => LogN(x, 2);
}

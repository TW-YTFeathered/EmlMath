using System.Numerics;

namespace EmlMath;

partial class Core
{
    /// <summary>
    /// Raises a complex number to a complex power.
    /// </summary>
    /// <param name="x">The base.</param>
    /// <param name="y">The exponent.</param>
    /// <returns><c>x^y</c> (principal value).</returns>
    public static Complex Pow(Complex x, Complex y) => Exp(Mul(y, Ln(x)));

    /// <summary>
    /// Computes the n‑th root of a complex number.
    /// </summary>
    /// <param name="x">The radicand.</param>
    /// <param name="n">The degree of the root.</param>
    /// <returns>The principal n‑th root of <paramref name="x"/>.</returns>
    public static Complex Root(Complex x, Complex n) => Pow(x, Inv(n));

    /// <summary>
    /// Computes the square root of a complex number.
    /// </summary>
    /// <param name="x">The radicand.</param>
    /// <returns>The principal square root of <paramref name="x"/>.</returns>
    public static Complex Sqrt(Complex x) => Root(x, Two);

    /// <summary>
    /// Computes the cube root of a complex number.
    /// </summary>
    /// <param name="x">The radicand.</param>
    /// <returns>The principal cube root of <paramref name="x"/>.</returns>
    public static Complex Cbrt(Complex x) => Root(x, Three);

    /// <summary>
    /// Computes the Euclidean norm (hypotenuse) of two complex numbers.
    /// </summary>
    /// <param name="x">First component.</param>
    /// <param name="y">Second component.</param>
    /// <returns><c>sqrt(x² + y²)</c>.</returns>
    public static Complex Hypot(Complex x, Complex y) => Sqrt(Add(Mul(x, x), Mul(y, y)));
}

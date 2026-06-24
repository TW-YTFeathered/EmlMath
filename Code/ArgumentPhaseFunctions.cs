using System.Numerics;

namespace EmlMath;

partial class Core
{
    /// <summary>
    /// Returns the phase (argument) of a complex number.
    /// </summary>
    /// <param name="x">The complex number.</param>
    /// <returns>The angle in radians, ranging from <c>-π</c> to <c>π</c>.</returns>
    public static double Arg(Complex x) => Ln(x).Imaginary;

    /// <summary>
    /// Computes the four‑quadrant arctangent of <c>y / x</c> as a <see cref="double"/> value.
    /// </summary>
    /// <param name="x">The x‑coordinate.</param>
    /// <param name="y">The y‑coordinate.</param>
    /// <returns>The angle whose tangent is <c>y/x</c>, taking both signs into account.</returns>
    public static double Atan2(Complex x, Complex y) => Arg(Add(y, Mul(I, x)));

    /// <summary>
    /// Computes the four‑quadrant arctangent of <c>y / x</c> and returns it as a <see cref="Complex"/>.
    /// </summary>
    /// <param name="x">The x‑coordinate.</param>
    /// <param name="y">The y‑coordinate.</param>
    /// <returns>The same value as <see cref="Atan2"/>, but cast to <see cref="Complex"/>.</returns>
    public static Complex Atan2C(Complex x, Complex y) => Atan2(x, y);
}

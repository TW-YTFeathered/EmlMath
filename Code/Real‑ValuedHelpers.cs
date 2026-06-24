using System.Numerics;

namespace EmlMath;

partial class Core
{
    /// <summary>
    /// Computes the absolute value (modulus) of a <strong>real</strong> number represented as a complex.
    /// </summary>
    /// <param name="x">The input, which should be real (i.e., imaginary part zero).</param>
    /// <returns><c>|x|</c> if the input is real; otherwise, returns <c>x</c> (not the complex modulus).</returns>
    /// <remarks>
    /// This method is only intended for real inputs; using it with a general complex number
    /// will not produce the complex modulus.
    /// </remarks>
    public static Complex AbsReal(Complex x) => Sqrt(Mul(x, x));
}

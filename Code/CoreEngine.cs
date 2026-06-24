using System.Numerics;

namespace EmlMath;

/// <summary>
/// Provides complex arithmetic operations defined entirely in terms of the <see cref="Eml"/> function.
/// All operations follow the principal branch of the complex logarithm.
/// </summary>
public static partial class Core
{
    /// <summary>
    /// The fundamental binary operator from which all other functions are constructed.
    /// </summary>
    /// <param name="x">The exponent in the exponential term.</param>
    /// <param name="y">The argument of the natural logarithm.</param>
    /// <returns><c>exp(x) - log(y)</c> using the principal branch of the complex logarithm.</returns>
    /// <remarks>
    /// This operator is the only one that directly calls <see cref="System.Numerics.Complex.Exp"/> and
    /// <see cref="System.Numerics.Complex.Log"/>; all other methods are composed from this function.
    /// </remarks>
    public static Complex Eml(Complex x, Complex y) => Complex.Exp(x) - Complex.Log(y);
}

namespace EmlMath

open System.Numerics

/// <summary>
/// Provides complex arithmetic operations defined entirely in terms of the <see cref="Eml"/> function.
/// All operations follow the principal branch of the complex logarithm.
/// </summary>
module Core =
    let One = Complex.One
    /// eml(x, y) = exp(x) - ln(y)
    let Eml x y = Complex.Exp(x) - Complex.Log(y)
    /// exp(x) = eml(x, 1)
    let Exp x = Eml x One
    /// <summary>
    /// Computes ln(x) using a simplified EML expression: eml(1, 1) - eml(1, x).
    /// </summary>
    /// <remarks>
    /// algebraically equivalent to e - (e - ln(x)) = ln(x).
    /// This two-term subtraction avoids the deep operator nesting and exponential 
    /// overflow that causes NaN in the standard composition eml(1, eml(eml(1, x), 1)).
    /// </remarks>
    let Ln x = Eml One One - Eml One x
    /// 0 = ln(1)
    let Zero = Ln One
    /// sub(x, y) = x - y
    let Sub x y = Eml (Ln x) (Exp y)
    /// neg(x) = -x
    let Neg x = Sub Zero x
    /// inv(x) = 1/x
    let Inv x = Ln x |> Neg |> Exp
    /// add(x, y) = x + y
    let Add x y = Neg y |> Sub x
    let private AssistMul x = Add x One |> Eml Zero |> Sub One
    /// mul(x, y) = x * y
    let Mul x y =
        AssistMul x
        |> Add (AssistMul y)
        |> (fun f1 -> Eml f1 One)
        |> (fun f2 -> Sub f2 x)
        |> (fun f3 -> Sub f3 y)
        |> (fun f4 -> Sub f4 One)
    /// div(x, y) = x / y
    let Div x y = Inv y |> Mul x
    /// pow(x, y) = x^y
    let Pow x y = Ln x |> Mul y |> Exp
    /// root(x, y) = x^(1/y)
    let Root x y = Pow x (Inv y)
    let private Two = Add One One
    /// sqrt(x) = root(x, 2)
    let Sqrt x = Root x Two
    let private Three = Add Two One
    /// cbrt(x) = root(x, 3)
    let Cbrt x = Root x Three
    /// hypot(x, y) = sqrt(x^2 + y^2)
    let Hypot x y = Mul y y |> Add (Mul x x) |> Sqrt
    /// absreal(x) = sqrt(x^2)
    let AbsReal x = Sqrt (Mul x x)
    let private NegativeOne = Neg One
    /// i = sqrt(-1)
    let I = Sqrt NegativeOne
    let private TwoI = Add I I
    let private NegativeI = Neg I
    /// sin(x) = [e^(i * x) - e^(-i * x)] / (2 * i)
    let Sin x =
        Mul I x
        |> Exp
        |> fun f ->
            Mul NegativeI x
            |> Exp
            |> Sub f
        |> fun g -> Div g TwoI
    /// cos(x) = [e^(i * x) + e^(-i * x)] / 2
    let Cos x =
        Mul I x
        |> Exp
        |> fun f ->
            Mul NegativeI x
            |> Exp
            |> Add f
        |> fun g -> Div g Two
    /// tan(x) = {e^[(2 * i) * x] - 1} / (i * {e^[(2 * i) * x] + 1})
    let Tan x = Mul TwoI x |> Exp |> fun f -> Div (Sub f One) (Mul I (Add f One))
    let private Ten = Mul Three Three |> Add One
    /// logn(x, bv) = ln(x) / ln(bv)
    let LogN x bv = Ln bv |> Div (Ln x)
    /// log10(x) = logn(x, 10)
    let Log10 x = LogN x Ten
    /// log2(x) = logn(x, 2)
    let Log2 x = LogN x Two
    /// sinh(x) = (e^x - e^-x) / 2
    let Sinh x = Exp x |> fun f -> Exp (Neg x) |> fun g -> Div (Sub f g) Two
    /// cosh(x) = (e^x + e^-x) / 2
    let Cosh x = Exp x |> fun f -> Exp (Neg x) |> fun g -> Div (Add f g) Two
    /// tanh(x) = sinh(x) / cosh(x)
    let Tanh x = Sinh x |> fun f -> Cosh x |> fun g -> Div f g
    /// asinh(x) = ln(x + sqrt(x^2 + 1))
    let Asinh x = Mul x x |> Add One |> Sqrt |> Add x |> Ln
    /// acosh(x) = ln(x + sqrt(x^2 - 1))
    let Acosh x = Mul x x |> Sub One |> Sqrt |> Add x |> Ln
    /// atanh(x) = ln((1 + x) / (1 - x)) / 2
    let Atanh x = Sub One x |> Div (Add One x) |> Ln |> fun f -> Div f Two
    let private IOverTwo = Div I Two
    /// asin(x) = -i * ln(i * x + sqrt(1 - x^2))
    let Asin x = Mul x x |> Sub One |> Sqrt |> Add (Mul I x) |> Ln |> Mul NegativeI
    /// acos(x) = -i * ln(x + sqrt(1 - x^2))
    let Acos x = Mul x x |> Sub One |> Sqrt |> Add x |> Ln |> Mul NegativeI
    /// atan(x) = i/2 * ln((i + x) / (i - x))
    let Atan x = Sub I x |> Div (Add I x) |> Ln |> Mul IOverTwo
    /// π = -i * ln(-1)
    let PI = Mul NegativeI (Ln NegativeOne)
    /// e = e^1
    let E = Exp One
    /// arg(x) = im(ln(x))
    let Arg x = (Ln x).Imaginary
    /// atan2(y, x) = arg(x + i * y)
    let Atan2 y x = Mul I y |> Add x |> Arg
    /// atan2c(y, x) = atan2(y, x) + 0i
    let Atan2C y x = Complex(Atan2 y x, 0.0)

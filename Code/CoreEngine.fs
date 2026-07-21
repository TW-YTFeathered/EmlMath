namespace EmlMath

open System.Numerics

/// <summary>
/// Provides complex arithmetic operations defined entirely in terms of the <see cref="Eml"/> function.
/// All operations follow the principal branch of the complex logarithm.
/// </summary>
module Core =
    let One = Complex.One
    let Eml x y = Complex.Exp(x) - Complex.Log(y)
    let Exp x = Eml x One
    let Ln x = Eml One One - Eml One x
    let Zero = Ln One
    let Sub x y = Eml (Ln x) (Exp y)
    let Neg x = Sub Zero x
    let Inv x = Ln x |> Neg |> Exp
    let Add x y = Neg y |> Sub x
    let private AssistMul x = Add x One |> Eml Zero |> Sub One
    let Mul x y =
        AssistMul x
        |> Add (AssistMul y)
        |> (fun sum -> Eml sum One)
        |> (fun r -> Sub r x)
        |> (fun r -> Sub r y)
        |> (fun r -> Sub r One)
    let Div x y = Inv y |> Mul x
    let Pow x y = Ln x |> Mul y |> Exp
    let Root x y = Pow x (Inv y)
    let private Two = Add One One
    let Sqrt x = Root x Two
    let private Three = Add Two One
    let Cbrt x = Root x Three
    let Hypot x y = Mul y y |> Add (Mul x x) |> Sqrt
    let AbsReal x = Sqrt (Mul x x)
    let private NegativeOne = Neg One
    let I = Sqrt NegativeOne
    let private TwoI = Add I I
    let private NegativeI = Neg I
    let Sin x =
        Mul I x
        |> Exp
        |> fun e1 ->
            Mul NegativeI x
            |> Exp
            |> Sub e1
        |> fun diff -> Div diff TwoI
    let Cos x =
        Mul I x
        |> Exp
        |> fun ep ->
            Mul NegativeI x
            |> Exp
            |> Add ep
        |> fun sum -> Div sum Two
    let Tan x = Mul TwoI x |> Exp |> fun v -> Div (Sub v One) (Mul I (Add v One))
    let private Ten = Mul Three Three |> Add One
    let LogN x bv = Ln bv |> Div (Ln x)
    let Log10 x = LogN x Ten
    let Log2 x = LogN x Two
    let Sinh x = Exp x |> fun ex -> Exp (Neg x) |> fun enx -> Div (Sub ex enx) Two
    let Cosh x = Exp x |> fun ex -> Exp (Neg x) |> fun enx -> Div (Add ex enx) Two
    let Tanh x = Sinh x |> fun s -> Cosh x |> fun c -> Div s c
    let Asinh x = Mul x x |> Add One |> Sqrt |> Add x |> Ln
    let Acosh x = Mul x x |> Sub One |> Sqrt |> Add x |> Ln
    let Atanh x = Div (Ln (Div (Add One x) (Sub One x))) Two
    let private IOverTwo = Div I Two
    let Asin x = Mul x x |> Sub One |> Sqrt |> Add (Mul I x) |> Ln |> Mul NegativeI
    let Acos x = Mul x x |> Sub One |> Sqrt |> Add x |> Ln |> Mul NegativeI
    let Atan x = Mul IOverTwo (Ln (Div (Add I x) (Sub I x)))
    let PI = Mul NegativeI (Ln NegativeOne)
    let E = Exp One
    let Arg x = (Ln x).Imaginary
    let Atan2 y x = Mul I y |> Add x |> Arg
    let Atan2C y x = Complex(Atan2 y x, 0.0)

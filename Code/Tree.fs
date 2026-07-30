namespace EmlMath

open System.Numerics

type Expr =
    | Constant of Complex
    | EmlNode of Expr * Expr

module ExprBuilder = 
    let One = Constant Complex.One
    /// eml(x, y) = exp(x) - ln(y)
    let Eml x y = EmlNode (x, y)
    /// exp(x) = eml(x, 1)
    let Exp x = Eml x One
    /// ln(x) = eml(1, eml(eml(1, x), 1))
    let Ln x = 
        Eml One x
        |> fun f -> Eml f One
        |> Eml One
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
    /// mul(x, y) = x * y
    let Mul x y = Ln y |> Add (Ln x) |> Exp
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
    /// abs(x) = sqrt(x^2)
    let Abs x = Sqrt (Mul x x)
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

module Evaluator =
    let rec Eval expr = 
        match expr with
        | Constant c -> c
        | EmlNode (l, r) -> Core.Eml (Eval l) (Eval r)

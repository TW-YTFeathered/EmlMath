# EmlMath

A .NET 10.0 class library that implements complex arithmetic **entirely** in terms of the single operator `eml(x, y) = exp(x) - log(y)`.  

All elementary functions – from addition to trigonometry – are derived from this core, following the construction in the paper [“All elementary functions from a single binary operator”](https://arxiv.org/abs/2603.21852).

---

## 📦 Project Structure

The library consists of two complementary modules:

- **`Core`** – provides **numerical evaluation** of all functions using `System.Numerics.Complex`.  
  It is optimised for performance and numerical stability (e.g., `Ln` is implemented with a stable two‑term subtraction to avoid overflow).

- **`ExprBuilder`** – defines an **expression tree** type (`Expr`) with only two node kinds: `Constant` and `EmlNode`.  
  This lets you construct symbolic formulas that mirror the paper’s definitions, which can be evaluated lazily, transformed, or analysed.  
  **Note:** The evaluator (`Evaluator.Eval`) is provided for convenience, but because the tree uses the literal nested definitions (especially for `Ln`), numerical evaluation may be unstable for some inputs. **For production use, prefer `Core`.**

---

## ✨ Features

- **Single foundation** – every function is built from `Eml(x, y) = exp(x) - log(y)`.
- **Complex support** – works with `System.Numerics.Complex`, using the principal branch of the complex logarithm.
- **Complete function set** – arithmetic, exponentials, logarithms, trigonometry, hyperbolic functions, and their inverses.
- **Numerically robust** – the `Core` implementation of `Mul` avoids common pitfalls like `0 * 0` → `NaN` (it never calls `log(0)`).  
- **Expression trees** – allows you to build formulas without evaluating them immediately, giving you full control over the computation pipeline (though numeric evaluation may be unstable).

---

## 🚀 Quick Start

### ✅ Numeric evaluation (recommended)

```csharp
using static EmlMath.Core; // static import for direct numeric access

Complex result = Sin(PI / 2); // → (1, 0)
Complex e = Exp(1);           // → (2.71828, 0)
Complex ln = Ln(e);           // → (1, 0)
```

All methods accept and return `Complex`; implicit conversions from `double` are automatic.

### 🧪 Expression trees (exploratory only)

```csharp
using EmlMath;

// Build sin(π/2) as a tree – note that we cannot use '/' operator;
// we manually construct 2 = 1+1
var one = ExprBuilder.One;
var two = ExprBuilder.Add(one, one);
var halfPi = ExprBuilder.Div(ExprBuilder.PI, two);
var expr = ExprBuilder.Sin(halfPi);

// Evaluate – may produce NaN for some inputs due to deep nesting
var value = Evaluator.Eval(expr);
Console.WriteLine(value); // May be (1,0) or (NaN,NaN) depending on the expression
```

> **Warning:** The expression tree evaluator is **not numerically stable** for all inputs – especially for `Ln` and its derivatives, because it uses the literal nested `Eml` composition. For reliable numeric results, always use the `Core` module.

---

## 📖 Important Notes

### Principal branch and complex results
Because the entire system is built on `log(y)` (the principal branch of the complex logarithm), results for complex inputs may **differ from the standard analytic continuation** whenever an intermediate phase crosses the branch cut at ±π.  
This behaviour is deterministic and not random, but it is **not** guaranteed to match textbook definitions. For **real** inputs, all functions behave exactly as expected.

### Differences between `Core` and `ExprBuilder`
- **`Core.Ln`** uses an optimised form: `Eml(1,1) - Eml(1,x)` to avoid exponential overflow during construction.  
- **`ExprBuilder.Ln`** follows the literal composition: `Eml(1, Eml(Eml(1,x), 1))`. While algebraically equivalent, the expression tree is deeper and numerically fragile.  
- **`Core.Mul`** employs a helper that never calls `ln(0)`, ensuring `Mul(0,0) = 0` (and similarly for negative products).  
- **`ExprBuilder.Mul`** simply uses `ln(x) + ln(y)` – mathematically correct, but the tree may contain `ln(0)` if evaluated directly with zero; the evaluator will propagate the result correctly only if the underlying implementation of `ln` can handle it (which the nested version cannot for zeros). For numerical safety, **prefer `Core.Mul` for production code**.

### When to use which?
- Use **`Core`** for any numerical computation – it’s fast, stable, and thoroughly tested.
- Use **`ExprBuilder`** when you need to inspect, transform, or generate code from symbolic expressions – treat the evaluator as a debugging tool rather than a production solver.

---

## 📦 Installation (for .NET 10.0)

Clone the repository and add a project reference:

```bash
git clone https://github.com/TW-YTFeathered/EmlMath.git
cd EmlMath
dotnet add reference ./EmlMath.csproj
```

---

## 📚 Reference

The design is based on the paper:

> **One Operator to Rule Them All**  
> *arXiv:2603.21852*  
> [https://arxiv.org/abs/2603.21852](https://arxiv.org/abs/2603.21852)

---

## 🤖 AI Assistance

Documentation assisted by **DeepSeek**.

---

## 📄 License

MIT LICENSE

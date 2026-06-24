# EmlMath

A .NET class library that implements complex arithmetic entirely in terms of the **`eml(x, y) = exp(x) - log(y)`** operator. Following the construction outlined in the paper [“One Operator to Rule Them All”](https://arxiv.org/abs/2603.21852), all elementary functions are derived from this single core, without relying on direct multiplication, addition, or other built-in operations.

## ✨ Features

- **Single foundation** – every function is built from `Eml(x, y)`.
- **Complex support** – all operations work with `System.Numerics.Complex`, following the principal branch of the complex logarithm.
- **Full function set** – arithmetic, exponentials, logarithms, trigonometric, hyperbolic, and their inverses.
- **Robust design** – multiplication is carefully implemented to avoid `0 * 0` → `NaN` issues.

## 🚀 Quick Start

```csharp
using static EmlMath.Core; // static import for direct access

// Constants
Complex i = I;
Complex pi = PI;

// Arithmetic
Complex sum = Add(3, 4);         // 3 + 4i? No, just real addition; but works for complex too.
Complex product = Mul(2, 3);     // 6

// Transcendentals
Complex expVal = Exp(1);         // e
Complex lnVal = Ln(expVal);      // 1

// Trigonometry
Complex sinVal = Sin(PI / 2);    // 1
```

> 💡 All methods accept and return `Complex`. Implicit conversions from `double` are automatic.

## 📦 Installation

Clone the repository and reference the project directly.

```bash
git clone https://github.com/your-username/EmlMath.git
# then add a reference to the project
```

## 📖 Documentation

Full XML documentation is included in the source code. The core operator `Eml` is the only method that calls `System.Numerics.Complex.Exp` and `Complex.Log` directly; everything else is composed from it.

### Important Notes

- **Principal branch** – all multi-valued functions (log, root, inverse trig) return the principal value.
- **`AbsReal`** – intended **only for real inputs** (imaginary part zero). For general complex numbers, use `Complex.Magnitude`; `AbsReal` returns `x` (not the modulus) for non‑real inputs.
- **Multiplication** – implemented using a helper to avoid logarithms of zero, ensuring `Mul(0, 0) = 0` without exceptions.

## 📚 Reference

This implementation is inspired by the paper:

> **One Operator to Rule Them All**  
> *arXiv:2603.21852*  
> [https://arxiv.org/abs/2603.21852](https://arxiv.org/abs/2603.21852)

## 📄 License

[MIT](LICENSE).

# EmlMath

A .NET 10.0 class library that implements complex arithmetic **entirely** in terms of the single operator `eml(x, y) = exp(x) - log(y)`.  
All elementary functions – from addition to trigonometry – are derived from this core, following the construction in the paper [“All elementary functions from a single binary operator”](https://arxiv.org/abs/2603.21852).

## ✨ Features

- **Single foundation** – every function is built from `Eml(x, y)`.
- **Complex support** – works with `System.Numerics.Complex`, using the principal branch of the complex logarithm.
- **Complete function set** – arithmetic, exponentials, logarithms, trig, hyperbolic, and inverses.
- **Robust** – multiplication avoids `0 * 0` → `NaN` pitfalls.

## 🚀 Quick Start

```csharp
using static EmlMath.Core; // static import for direct access

Complex result = Sin(PI / 2); // → 1
Complex e = Exp(1);           // → e
Complex ln = Ln(e);           // → 1
```

All methods accept and return `Complex`; implicit conversions from `double` are automatic.

## 📦 Installation (for .NET 10.0)

Clone the repository and add a project reference:

```bash
git clone https://github.com/TW-YTFeathered/EmlMath.git
```

## 📖 Notes

- **Principal branch** – multi-valued functions return the principal value.
- **`AbsReal`** – intended **only for real inputs** (imaginary part zero); for general complex numbers, use `Complex.Magnitude`.
- **Multiplication** – implemented with a helper to avoid logarithms of zero, so `Mul(0, 0) = 0`.

## 📚 Reference

Based on the paper:

> **One Operator to Rule Them All**  
> *arXiv:2603.21852*  
> [https://arxiv.org/abs/2603.21852](https://arxiv.org/abs/2603.21852)

## 🤖 AI Assistance

Documentation assisted by **DeepSeek**.

## 📄 License

[MIT](LICENSE)

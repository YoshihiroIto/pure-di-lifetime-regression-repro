# Pure.DI Lifetime Regression Repro

This is a minimal console app for comparing the behavior of Pure.DI `2.3.3`, `2.3.4`, and `2.3.5-beta1`.

## Purpose

- A composition configured with `DefaultLifetime(Singleton)`
- A concrete class `MyDialog` that is not explicitly registered with `.Bind<MyDialog>()`
- Multiple resolutions through `Func<MyDialog>`

This verifies whether `MyDialog` is created on every resolution or whether the same instance is reused under those conditions.

## Version Comparison

```powershell
dotnet run --project 2.3.3/PureDiLifetimeRegression.csproj
dotnet run --project 2.3.4/PureDiLifetimeRegression.csproj
dotnet run --project 2.3.5.beta1/PureDiLifetimeRegression.csproj
```

Each version is placed in a separate folder to avoid sharing `obj/bin` outputs.

## Observed Results in the Current Environment

- `2.3.3`: `ReferenceEquals = False`
- `2.3.4`: `ReferenceEquals = True`
- `2.3.5-beta1`: `ReferenceEquals = True`

## Expected Usage

When attaching this to an issue, include the output differences across these versions as-is.

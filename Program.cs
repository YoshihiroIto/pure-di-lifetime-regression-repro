using Pure.DI;
using static Pure.DI.Lifetime;

DI.Setup(nameof(Composition))
    .DefaultLifetime(Singleton)
    .Bind<IDialogService>().To<DialogService>()
    .Root<Runner>("Root");

var composition = new Composition();
composition.Root.Run();

interface IDialogService
{
    MyDialog Create();
}

sealed class DialogService(Func<MyDialog> createDialog) : IDialogService
{
    public MyDialog Create() => createDialog();
}

sealed class Runner(IDialogService dialogService)
{
    public void Run()
    {
        var dialog1 = dialogService.Create();
        var dialog2 = dialogService.Create();

        Console.WriteLine($"Dialog1.Id = {dialog1.Id}");
        Console.WriteLine($"Dialog2.Id = {dialog2.Id}");
        Console.WriteLine($"ReferenceEquals = {ReferenceEquals(dialog1, dialog2)}");
    }
}

sealed class MyDialog
{
    public Guid Id { get; } = Guid.NewGuid();
}

partial class Composition;

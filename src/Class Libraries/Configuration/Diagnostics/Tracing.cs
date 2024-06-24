namespace WhenFresh.Utilities.Configuration.Diagnostics;

using System.Diagnostics;

internal static class Tracing
{
    internal static TraceSwitch Is => new("Cavity.Configuration", string.Empty);
}
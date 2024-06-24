namespace WhenFresh.Utilities.Configuration.Diagnostics;

using System.Diagnostics;

internal static class Tracing
{
    internal static TraceSwitch Is => new("WhenFresh.Utilities.Configuration", string.Empty);
}
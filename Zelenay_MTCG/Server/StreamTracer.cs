namespace MonsterCardGame.Server.HttpHandler;

internal class StreamTracer
{
    private StreamWriter streamWriter;

    public StreamTracer(StreamWriter streamWriter)
    {
        this.streamWriter = streamWriter;
    }

    internal void WriteLine(string x)
    {
        Console.WriteLine(x);
        streamWriter.WriteLine(x);
    }

    internal void WriteLine()
    {
        Console.WriteLine();
        streamWriter.WriteLine();
    }
}

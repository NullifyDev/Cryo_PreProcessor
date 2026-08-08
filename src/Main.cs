namespace Cryo.PreProcessor;

public class PreProcessor
{
    public Object GetObject(string src) 
        => this.GetMethod("CONSOLE_INPUT", src);

    public IEnumerable<Object> GetMethods(string file) {
        foreach (var line in File.ReadAllLines(file)) {
            var n = GetMethod(file, line);
            if (n is Cryo.PreProcessor.Method)
                yield return (n as Cryo.PreProcessor.Method)!;
        }
    }

    private Object GetMethod(string file, string src)
    {
        var o = new Converter(new Parser(new Lexer(file, src).Lex()).Parse().ToArray()).Convert().GetEnumerator();
        o.MoveNext();
        return o.Current;
    }
}
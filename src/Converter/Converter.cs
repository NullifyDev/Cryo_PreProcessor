using System.Linq.Expressions;

namespace Cryo.PreProcessor;

public class Converter
{
    private IEnumerator<Node> node;

    public Converter(IEnumerable<Node> nodes)
    {
        this.node = nodes.GetEnumerator();
    }

    public IEnumerable<Object> Convert()
    {
        List<Object> objs = new();

        while (node.MoveNext())
        {
            Node n = node.Current;
            if (n is Expression.Arrow)
                continue;

            Object no = ConvertOnce(n);
            
            if (no is Error) {
                var e = (no as Error);
                throw new Exception($"{e.Message}");
            }
            objs.Add(no);
        }
        yield return new Method(objs[objs.Count()-1], objs.Count > 1 ? objs.ToArray()[0..^1] : null);
    }

    private Object ConvertOnce(Node node)
        => node switch {
            Expression.Object   o => o.Obj,
            Expression.Register r => new Register(r.Id, new Data(r.Data!.Type)),
            Expression.Data     d => new Data(d.Type),
            Expression.Input    i => new Input(i.Data!),
                                _ => new Error(ErrorType.UnknownObject, $"Unknown Object: {node}")
        };
}
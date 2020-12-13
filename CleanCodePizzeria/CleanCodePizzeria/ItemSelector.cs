using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodePizzeria
{
    class ItemSelector<V>
    {
        //    public static V SelectItem(Dictionary<string, V> items)
        //    {
        //        var visitor = new PizzeriaVisitor();
        //        foreach (var item in items)
        //        {
        //            Console.WriteLine($"[{item.Key}]: {visitor.VisitItem(item.Value)}");
        //        }
        //        var input = Console.ReadLine();
        //        var success = int.TryParse(input, out int index);
        //        if (!success)
        //        {
        //            items.TryGetValue(input, out V value);
        //        }
        //        items.TryGetValue(index, out V value);
        //        return value;
        //    }

        //    public static V SelectItem(IEnumerable<V> items)
        //    {
        //        return SelectItem(
        //            items
        //                .Select((value, index) => (value, index))
        //                .ToDictionary(pair => pair.index, pair => pair.value));
        //    }
    }
}

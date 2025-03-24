using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoProject;

public class Autocompleter<T>
{
    private readonly INavigateService _navigateService;

    public string Query { get; set; }
    public List<T> Data { get; set; }
    public List<T> Suggestions { get; set; }
    public int? HighlightedIndex { get; set; }

    public Autocompleter(INavigateService navigateService)
    {
        _navigateService = navigateService;
    }

    public void Autocomplete()
    {
        if (Data == null)
        {
            throw new InvalidOperationException("No data!");
        }

        Suggestions = new List<T>();

        foreach (var item in Data)
        {
            var props = item.GetType().GetProperties();
            foreach (var prop in props)
            {
                var value = prop.GetValue(item) as string;

                if (value.Contains(Query, StringComparison.OrdinalIgnoreCase))
                {
                    Suggestions.Add(item);
                    break;
                }
            }
        }
    }

    public void Next()
    {
        if (Suggestions == null || !Suggestions.Any())
        {
            return;
        }

        // "high cohesion, low coupling"
        HighlightedIndex = _navigateService.Next(Suggestions, HighlightedIndex);
    }

}

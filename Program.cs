using System.Text;
using System.Text.Json;
using PersonDataGenerator;

Console.OutputEncoding = Encoding.UTF8;

int count = 1;
bool isMinified = false;

for (int i = 0; i < args.Length; i++)
{
    var arg = args[i].ToLowerInvariant();
    if (arg is "-n" or "--count" && i + 1 < args.Length && int.TryParse(args[i + 1], out var parsedCount))
    {
        count = Math.Max(1, parsedCount);
        i++;
    }
    else if (arg is "-m" or "--minified")
    {
        isMinified = true;
    }
}

if (count == 1)
{
    var person = PersonGenerator.Generate();
    var json = isMinified ? JsonSerializer.Serialize(person) : PersonGenerator.ToJson(person);
    Console.WriteLine(json);
}
else
{
    var people = Enumerable.Range(0, count).Select(_ => PersonGenerator.Generate()).ToList();
    var jsonOptions = new JsonSerializerOptions
    {
        WriteIndented = !isMinified,
        Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
    };
    Console.WriteLine(JsonSerializer.Serialize(people, jsonOptions));
}

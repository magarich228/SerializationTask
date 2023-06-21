using Newtonsoft.Json;
using SerializationTask;
using SerializationTask.Models;

var path = $"{Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)}\\Persons.json";

await WritePersons(path);

GC.Collect();

await ReadPersons(path);

///Задача на генерацию коллекции, сериализацию в json и запись в файл.
static async Task WritePersons(string path)
{
    var integerIdGenerator = new IntegerIdGenerator();
    var childGenerator = new ChildGenerator(integerIdGenerator);
    var personGenerator = new PersonGenerator(integerIdGenerator, childGenerator);

    var persons = personGenerator.GenerateNext(1000);
    var personsJson = JsonConvert.SerializeObject(persons, Formatting.Indented);

    using var sw = new StreamWriter(File.Create(path));

    await sw.WriteLineAsync(personsJson);
    await sw.FlushAsync();
}

///Чтение json из файла, десериализация, работа с данными Persons.
static async Task ReadPersons(string path)
{
    using var sr = new StreamReader(File.OpenRead(path));

    var personsJsonTask = sr.ReadToEndAsync();
    var persons = JsonConvert.DeserializeObject<IEnumerable<Person>>(await personsJsonTask)
        ?? throw new ApplicationException("No person read from the file.");

    await Console.Out.WriteLineAsync($"Persons count: {persons.Count()}");
    await Console.Out.WriteLineAsync($"Persons credit card count: {persons.SelectMany(p => p.CreditCardNumbers).Count()}");
    await Console.Out.WriteLineAsync($"Average child age: {persons.SelectMany(p => p.Children).Average(c => c.BirthDate)}");
}
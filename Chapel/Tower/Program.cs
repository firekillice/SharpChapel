using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using Tower;

var animalCol = new AnimalCollection();
animalCol.Add(new Animal(1, 1));
animalCol.All(x => x.Volume > 10);

var animmal = new Animal(1,1);
var namedAnimmal = new Animal(1, 1, "chicken");

ValidationContext context = new ValidationContext(namedAnimmal, null, null);
List<ValidationResult> validationResults = new List<ValidationResult>();
Validator.TryValidateObject(namedAnimmal, context, validationResults, true);

animmal.DelegateEntrance(Animal.AnimalDelegate);
Animal.AnotherMessageDelegate g = Animal.AnimalDelegate;
g(1, 1); 
g.Invoke(1, 2);
animmal.AddLife(30);

Action<int,long> f = Animal.AnimalDelegate;
Action<int, float> f3 = animmal.AnimalDelegate;
Func<int,int,int> f2 = Animal.AnimalDelegate;

Action<int> a1 = x => Console.WriteLine(x);
Func<int, int> fl = x => { return x * x; };

animmal.View(a1);
animmal.Equals(new Animal() { Volume = 30, Life = 40 }) ;
animmal.Equals(new() { Volume = 30, Life = 40 });
animmal.AddVolume(20);

//new Chick().AddVolume(30);

Animal.Add(animalCol);
Animal.Add<AnimalCollection>(animalCol);

Animal.Add(animmal);
Animal.Add<Animal>(animmal);

var l = new List<int>();
l.Add(1);

var tuple = new Tuple<Object, Object, Object, Object>(1,2,3,4);
var v = tuple.Item1;
int a = (int)v;

var dic = new Dictionary<int, int>() { { 1, 2 }, { 3, 4 } };

dic.Add( 45,5);

var c = new KeyValuePair<int, int>(3, 4);
Console.WriteLine(c.Key);

var d = new Object();

int i = 3;


int[] numbers = { 3, 4, 5, 6, 7 };
var result = numbers.Select(x => x - 1);
Console.WriteLine(string.Join(" ", result));

var sn = new { args = 3 };

List<Animal> animalList = new List<Animal>();
animalList.Add(new Animal(1, 32));
animalList.Add(new Animal(1, 33));
Animal[] animals = Array.Empty<Animal>();

if (animals is object && animals is Array && animals is { })
{
    Console.WriteLine("True");
}

var anonymousValue = new { Id = 3, Value = 4, Detail = new { SubId = 5, SubValue = 5 }};
Console.WriteLine(anonymousValue.Id);

var svcCollection = new MyServiceCollection();

Hosting.FirstView(new string[]{ });

Console.ReadKey();




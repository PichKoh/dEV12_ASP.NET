using Microsoft.Extensions.Hosting;
using System.Reflection.Metadata;
using ConsolApp12_1;

//https://learn.microsoft.com/en-us/ef/core/get-started/overview/first-app?tabs=visual-studio

using var db = new UserContext();

// Note: This sample requires the database to be created before running.
Console.WriteLine($"Database path: {db.DbPath}.");

// Create
Console.WriteLine("Inserting a new user");
var userFirst = new User
{
    FirstName = "Amina",
    LastName = "Holubieva",
    Age = 19
};
var userSecond = new User
{
    FirstName = "Ivan",
    LastName = "Rybakov",
    Age = 25
};
var userThird = new User
{
    FirstName = "Oleg",
    LastName = "Skyba",
    Age = 15
};

db.Add(userFirst);
db.Add(userSecond);
db.Add(userThird);
db.SaveChanges();

// Read
Console.WriteLine("Querying for a users");
var users = db.Users
    .OrderBy(b => b.Id);

Console.WriteLine("Num of users: ", users.Count<User>());
foreach (var u in users)
{
    Console.WriteLine(u.ToString());
}

Console.WriteLine("Getting first user");
var user = users.First();
Console.WriteLine(user.ToString());

// Update
Console.WriteLine("Updating user");
user.Age = 21;

db.SaveChanges();

var usersUpdated = db.Users
    .OrderBy(b => b.Id);

Console.WriteLine("Num of users: ", usersUpdated.Count<User>());
foreach (var u in usersUpdated)
{
    Console.WriteLine(u.ToString());
}

// Delete
Console.WriteLine("Delete user");
db.Remove(user);
db.SaveChanges();

var usersDeleted = db.Users
    .OrderBy(b => b.Id);

Console.WriteLine("Num of users: ", usersDeleted.Count<User>());
foreach (var u in usersUpdated)
{
    Console.WriteLine(u.ToString());
}
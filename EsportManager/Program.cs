using System;
using EsportManager;
using Microsoft.Data.Sqlite;


Console.WriteLine("hello world!");

bdd.connection();

bdd.mageReadAll();

bdd.closeConnection();
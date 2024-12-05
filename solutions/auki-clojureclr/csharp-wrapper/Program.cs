// Based on https://stackoverflow.com/a/4560660
using System;
using clojure.lang;

RT.load("aoc");
var main = RT.var("aoc","-main");
var output = main.invoke(args[0], args[1]);
Console.WriteLine(output);

using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Input;

namespace sorting_data
{
  public class Sort
  {
    private static string _whichArray;
    private static string[] _dataArray;
    private static string _filePath;


    public static void printStart()
    {
      Console.Clear();
      Console.WriteLine("==================================================");
      Console.WriteLine("-Welcome to Harry's seismic data sorting program!-");
      Console.WriteLine("==================================================\n");
    }

    static void Main(string[] args)
    {
      printStart();
      Console.WriteLine("Please choose an Array!");
      System.Threading.Thread.Sleep(100);
      Console.WriteLine("A : Year");
      System.Threading.Thread.Sleep(100);
      Console.WriteLine("B : Month");
      System.Threading.Thread.Sleep(100);
      Console.WriteLine("C : Day");
      System.Threading.Thread.Sleep(100);
      Console.WriteLine("D : Time (UTC)");
      System.Threading.Thread.Sleep(100);
      Console.WriteLine("E : Magnitude");
      System.Threading.Thread.Sleep(100);
      Console.WriteLine("F : Latitude");
      System.Threading.Thread.Sleep(100);
      Console.WriteLine("G : Longitude");
      System.Threading.Thread.Sleep(100);
      Console.WriteLine("H : Depth");
      System.Threading.Thread.Sleep(100);
      Console.WriteLine("I : Region");
      System.Threading.Thread.Sleep(100);
      Console.WriteLine("J : IRIS_ID");
      System.Threading.Thread.Sleep(100);
      Console.WriteLine("K : Timestamp\n");
      System.Threading.Thread.Sleep(100);


      Console.Write("Array letter: ");

      _whichArray = Console.ReadLine().ToLower();

      if (_whichArray == "a")
      {
        _filePath = @"sorting_files\Year_1.txt";
      }
      else if (_whichArray == "b")
      {
        _filePath = @"sorting_files\Month_1.txt";
      }
      else if (_whichArray == "c")
      {
        _filePath = @"sorting_files\Day_1.txt";
      }
      else if (_whichArray == "d")
      {
        _filePath = @"sorting_files\Time_1.txt";
      }
      else if (_whichArray == "e")
      {
        _filePath = @"sorting_files\Magnitude_1.txt";
      }
      else if (_whichArray == "f")
      {
        _filePath = @"sorting_files\Latitude_1.txt";
      }
      else if (_whichArray == "g")
      {
        _filePath = @"sorting_files\Longitude_1.txt";
      }
      else if (_whichArray == "h")
      {
        _filePath = @"sorting_files\Depth_1.txt";
      }
      else if (_whichArray == "i")
      {
        _filePath = @"sorting_files\Region_1.txt";
      }
      else if (_whichArray == "j")
      {
        _filePath = @"sorting_files\IRIS_ID_1.txt";
      }
      else if (_whichArray == "k")
      {
        _filePath = @"sorting_files\Timestamp_1.txt";
      }
      else
      {
        Console.WriteLine("Please enter a valid Array letter");
      }


      Console.WriteLine("\nImporting data from {0}...", _filePath);
      _dataArray = File.ReadAllLines(_filePath);

      foreach (string d in _dataArray)
      {
        Console.WriteLine(d);

      }

      Console.WriteLine("Please enter what you want to find");
      string userFind = Console.ReadLine();
      Seismic.load(_filePath, userFind);
      Seismic.printData();

    }

  }
  public class Seismic
  {
    private static Dictionary<string, string[]> _data = new Dictionary<string, string[]>();
    public static void load(string path, string series)
    {

      
        string[] year = File.ReadAllLines(@"sorting_files\Year_1.txt").ToArray();
      
        string[] month = File.ReadAllLines(@"sorting_files\Month_1.txt").ToArray();
      
        string[] day = File.ReadAllLines(@"sorting_files\Day_1.txt").ToArray();

        string[] time = File.ReadAllLines(@"sorting_files\Time_1.txt").ToArray();

        string[] magnitude = File.ReadAllLines(@"sorting_files\Magnitude_1.txt").ToArray();

        string[] latitude = File.ReadAllLines(@"sorting_files\Latitude_1.txt").ToArray();

        string[] longitude = File.ReadAllLines(@"sorting_files\Longitude_1.txt").ToArray();

        string[] depth = File.ReadAllLines(@"sorting_files\Depth_1.txt").ToArray();
      
        string[] region = File.ReadAllLines(@"sorting_files\Region_1.txt").ToArray();

        string[] iris = File.ReadAllLines(@"sorting_files\IRIS_ID_1.txt").ToArray();

        string[] timestamp = File.ReadAllLines(@"sorting_files\Timestamp_1.txt").ToArray();

      _data.Add("year", year);
      _data.Add("month", month);
      _data.Add("day", day);
      _data.Add("time", time);
      _data.Add("magnitude", magnitude);
      _data.Add("latitude", latitude);
      _data.Add("longitude", longitude);
      _data.Add("depth", depth);
      _data.Add("region", region);
      _data.Add("iris", iris);
      _data.Add("timestamp", timestamp); 

    }
    public static void printData()
    {
      string[] year = _data["year"];
      string[] month = _data["month"];
      string[] day = _data["day"];
      string[] time = _data["time"];
      string[] magnitude = _data["magnitude"];
      string[] latitude = _data["latitude"];
      string[] longitude = _data["longitude"];
      string[] depth = _data["depth"];
      string[] region = _data["region"];
      string[] iris = _data["iris"];
      string[] timestamp = _data["timestamp"];
      Console.WriteLine("|Year     |month        |day |time           |magnitude    |lat   |long    |depth    |region    |iris    |timestamp");
      string dataPrintOut;
      for(int i = 0; i < year.Length; i++)
      {
        dataPrintOut = string.Format("{0,-10}{1,-15}{2,-5}{3,-8}{4,-8}{5,-8}{6,-10}{7,-8}{8,-20}{9,-10}{10,-12}", year[i], month[i], day[i], time[i], magnitude[i], latitude[i], longitude[i], depth[i], region[i], iris[i], timestamp[i]);
        Console.WriteLine(dataPrintOut);
      }

    }
  }

}
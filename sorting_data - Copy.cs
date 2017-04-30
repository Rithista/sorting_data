using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Input;
using System.Text;
using System.Reflection;

namespace sorting_data
{
  public class Program
  {
    private static string _whichArray;
    private static List<Seismic> _dataList = new List<Seismic>();
    private static string whichData;
    private static string whatAnalysis;
    private static string whatSet;
    private static string ascDesc;

    /*private static void printField(int i)
    {
      if (_whichArray == "a")
      {
        Console.WriteLine("{0}", _dataList.ElementAt(i).year);
      }
      else if (_whichArray == "b")
      {
        Console.WriteLine("{0}", _dataList.ElementAt(i).month);
      }
      else if (_whichArray == "c")
      {
        Console.WriteLine("{0}", _dataList.ElementAt(i).day);
      }
      else if (_whichArray == "d")
      {
        Console.WriteLine("{0}", _dataList.ElementAt(i).time);
      }
      else if (_whichArray == "e")
      {
        Console.WriteLine("{0}", _dataList.ElementAt(i).magnitude);
      }
      else if (_whichArray == "f")
      {
        Console.WriteLine("{0}", _dataList.ElementAt(i).latitude);
      }
      else if (_whichArray == "g")
      {
        Console.WriteLine("{0}", _dataList.ElementAt(i).longitude);
      }
      else if (_whichArray == "h")
      {
        Console.WriteLine("{0}", _dataList.ElementAt(i).depth);
      }
      else if (_whichArray == "i")
      {
        Console.WriteLine("{0}", _dataList.ElementAt(i).region);
      }
      else if (_whichArray == "j")
      {
        Console.WriteLine("{0}", _dataList.ElementAt(i).iris);
      }
      else if (_whichArray == "k")
      {
        Console.WriteLine("{0}", _dataList.ElementAt(i).timestamp);
      }
    }*/
    private static string getData(int i)
    {
      if (_whichArray == "a")
      {
        return _dataList.ElementAt(i).syear;
      }
      else if (_whichArray == "b")
      {
        return _dataList.ElementAt(i).month;
      }
      else if (_whichArray == "c")
      {
       return _dataList.ElementAt(i).sday;
      }
      else if (_whichArray == "d")
      {
        return _dataList.ElementAt(i).time;
      }
      else if (_whichArray == "e")
      {
        return _dataList.ElementAt(i).smagnitude;
      }
      else if (_whichArray == "f")
      {
       return _dataList.ElementAt(i).slatitude;
      }
      else if (_whichArray == "g")
      {
        return _dataList.ElementAt(i).slongitude;
      }
      else if (_whichArray == "h")
      {
        return _dataList.ElementAt(i).sdepth;
      }
      else if (_whichArray == "i")
      {
        return _dataList.ElementAt(i).region;
      }
      else if (_whichArray == "j")
      {
       return _dataList.ElementAt(i).siris;
      }
      else if (_whichArray == "k")
      {
        return _dataList.ElementAt(i).stimestamp;
      }
      else
      {
        return "";
      }
    }
    private static void inputFiles(string j)
    {
      string fileName = string.Format(@"sorting_files\Year_{0}.txt", j);


      for (int i = 0; i < File.ReadAllLines(fileName).Length; i++)
      {
        fileName = string.Format(@"sorting_files\Year_{0}.txt", j);
        string year = File.ReadLines(fileName).Skip(i).Take(1).First();
        fileName = string.Format(@"sorting_files\Month_{0}.txt", j);
        string month = File.ReadLines(fileName).Skip(i).Take(1).First();
        fileName = string.Format(@"sorting_files\Day_{0}.txt", j);
        string day = File.ReadLines(fileName).Skip(i).Take(1).First();
        fileName = string.Format(@"sorting_files\Time_{0}.txt", j);
        string time = File.ReadLines(fileName).Skip(i).Take(1).First();
        fileName = string.Format(@"sorting_files\Magnitude_{0}.txt", j);
        string magnitude = File.ReadLines(fileName).Skip(i).Take(1).First();
        fileName = string.Format(@"sorting_files\Latitude_{0}.txt", j);
        string latitude = File.ReadLines(fileName).Skip(i).Take(1).First();
        fileName = string.Format(@"sorting_files\Longitude_{0}.txt", j);
        string longitude = File.ReadLines(fileName).Skip(i).Take(1).First();
        fileName = string.Format(@"sorting_files\Depth_{0}.txt", j);
        string depth = File.ReadLines(fileName).Skip(i).Take(1).First();
        fileName = string.Format(@"sorting_files\Region_{0}.txt", j);
        string region = File.ReadLines(fileName).Skip(i).Take(1).First();
        fileName = string.Format(@"sorting_files\IRIS_ID_{0}.txt", j);
        string iris = File.ReadLines(fileName).Skip(i).Take(1).First();
        fileName = string.Format(@"sorting_files\Timestamp_{0}.txt", j);
        string timestamp = File.ReadLines(fileName).Skip(i).Take(1).First();
        DateTime dateStamp = new DateTime();
        dateStamp = DateTime.Parse(string.Format("{0} {1} {2} {3}", day, month, year, time));
        Seismic s = new Seismic(year, month, day, time, magnitude, latitude, longitude, depth, region, iris, timestamp, dateStamp);
        _dataList.Add(s);
      }
    }
    public static void printStart()
    {
      Console.Clear();
      Console.BufferHeight = Int16.MaxValue - 1;
      var w = Console.WindowWidth;
      var h = Console.WindowHeight;
      if(w < 200 || h < 75)
      {
        Console.SetWindowSize(200, 75);
      }
      Console.WriteLine("==================================================");
      Console.WriteLine("-Welcome to Harry's seismic data sorting program!-");
      Console.WriteLine("==================================================\n");
    }

    static void Main()
    {
      printStart();
      Console.WriteLine("Please choose a Data type to sort by!");
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

      Console.Write("Data type letter: ");
      bool dataTypeSelect = false;
      _whichArray = Console.ReadLine().ToLower();
      string[] dataTypeValue = new string[11] {"a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k" };
      while (!dataTypeSelect) {
        if(dataTypeValue.Contains(_whichArray))
        {
          dataTypeSelect = true;
          break;
        }
        else
        {
          Console.Write("\nPlease enter a valid Data type letter: ");
          _whichArray = Console.ReadLine().ToLower();
        }
      }


      int totalEntry = 0;
      foreach (string s in File.ReadAllLines(@"sorting_files\Year_1.txt"))
      {
        totalEntry++;
      }

      bool foundSet = false;
      Console.Write("\nWhich data set would you like analyse: 1 | 2 | M for Merge: ");
      whatAnalysis = Console.ReadLine().ToLower();
      while (!foundSet)
      {
        if (whatAnalysis == "1")
        {
          inputFiles("1");
          whatSet = "1";
          foundSet = true;
          break;
        }
        else if (whatAnalysis == "2")
        {
          inputFiles("2");
          whatSet = "2";
          foundSet = true;
          break;
        }
        else if (whatAnalysis == "m")
        {
          inputFiles("1");
          inputFiles("2");
          whatSet = "1 and 2";
          foundSet = true;
          break;
        }
        else
        {
          printStart();
          Console.Write("Please enter a correct value for the data set: 1 | 2 | M for Merge: ");
          whatAnalysis = Console.ReadLine().ToLower();
        }
      }



      bool isDesc = false;
      Console.Write("\nType A for Ascending, or D for Descending: ");
      string inputAscDec = Console.ReadLine().ToLower();
      while (!isDesc)
      {
        if (inputAscDec == "a") {
          ascDesc = "Ascending";
          isDesc = true;
          break;
        }
        else if (inputAscDec == "d")
        {
          ascDesc = "Descending";
          isDesc = true;
          break;
        }
        else
        {
          printStart();
          Console.Write("Please enter a valid letter, A for Ascending, or D for Descending: ");
          inputAscDec = Console.ReadLine().ToLower();
          isDesc = false;
        }
      }
      quickSort q = new quickSort();
      q.quickSorting(_dataList, 0, _dataList.Count() - 1);
      Console.WriteLine("Got to here");


      if (_whichArray == "a")
      {
        whichData = "Year";
      }
      else if (_whichArray == "b")
      {
        whichData = "Month";
      }
      else if (_whichArray == "c")
      {
        whichData = "Day";
      }
      else if (_whichArray == "d")
      {
        whichData = "Time";
      }
      else if (_whichArray == "e")
      {
        whichData = "Magnitude";
      }
      else if (_whichArray == "f")
      {
        whichData = "Latitude";
      }
      else if (_whichArray == "g")
      {
        whichData = "Longitude";
      }
      else if (_whichArray == "h")
      {
        whichData = "Depth";
      }
      else if (_whichArray == "i")
      {
        whichData = "Region";
      }
      else if (_whichArray == "j")
      {
        whichData = "Iris_ID";
      }
      else if (_whichArray == "k")
      {
        whichData = "Timestamp";
      }


      Console.Write("\nType in the key search item for Data type |{0}|: ", whichData);
      string keySearch = Console.ReadLine().ToLower();
      printStart();

      bool isFound = false;
      bool printed = false;
      while (!isFound)
      {
        for (int i = 0; i < _dataList.Count; i++)
        {
          string v = getData(i);
          //Console.WriteLine("Value {0}, Search key {1}", v, keySearch);

         
          if (String.Equals(v.ToLower(), keySearch.ToLower()))
          {
            if (!printed)
            {
              Console.WriteLine("Data set --> |{0}| Data type -->|{1}| Sorted -->|{2}| \n", whatSet, whichData, ascDesc);
              dataPrint();
              printed = true;
            }
            _dataList.ElementAt(i).printData();
            isFound = true;
          }
        }
        if (!isFound)
        {
          Console.WriteLine("Data set --> |{0}| Data type -->|{1}| Sorted -->|{2}|\n", whatSet, whichData, ascDesc);
          Console.WriteLine("No value found in Data type\n");
          Console.Write("Please enter another entry or type R to reset: ");
          keySearch = Console.ReadLine().ToLower();
          if (keySearch == "r")
          {
            Main();
          }
          printStart();
        }
        else if (isFound)
        {
          break;
        }

      }
      bool exit = false;
      Console.Write("\n\n\n\n\nType N for Next entry, or E to Exit the application: ");
      while (!exit) {
        string userExit = Console.ReadLine().ToLower();
        if(userExit == "n")
        {
          exit = true;
          Console.Write("\nReloading application");
          Console.Write(".");
          System.Threading.Thread.Sleep(500);
          Console.Write(".");
          System.Threading.Thread.Sleep(500);
          Console.Write(".");
          System.Threading.Thread.Sleep(500);
          Main();
          break;
        }
        else if (userExit == "e")
        {
          break;
        }
        else
        {
          Console.Write("\nPlease enter a valid letter: ");
          exit = false;
        }
      }
      Console.Write("\nExiting application in 3 seconds");
      Console.Write(".");
      System.Threading.Thread.Sleep(1000);
      Console.Write(".");
      System.Threading.Thread.Sleep(1000);
      Console.Write(".");
      System.Threading.Thread.Sleep(1000);
      Console.Clear();
      Environment.Exit(0);
    }
    private static void dataPrint()
    {
      Console.WriteLine();
      Console.WriteLine("|Year   |Month       |Day    |Time      |Magni  |Lati     |Long     |Depth     |Region                          |Iris        |Timestamp");
      Console.WriteLine("|-------|------------|-------|----------|-------|---------|---------|----------|--------------------------------|------------|----------");
    }
  }

  public class Seismic
  {
    public int year;
    public string syear;
    public string month;
    public int day;
    public string sday;
    public string time;
    public DateTime dateStamp;
    public float magnitude;
    public string smagnitude;
    public float latitude;
    public string slatitude;
    public float longitude;
    public string slongitude;
    public float depth;
    public string sdepth;
    public string region;
    public int iris;
    public string siris;
    public int timestamp;
    public string stimestamp;
    public string whatSearch;

    public Seismic(string pyear, string pmonth, string pday, string ptime, string pmagnitude, string platitude, string plongitude, string pdepth, string pregion, string piris, string ptimestamp, DateTime finalDate)
    {
      year = Convert.ToInt32(pyear);
      syear = pyear.Trim();
      month = pmonth.Trim();
      day = Convert.ToInt32(pday);
      sday = pday.Trim();
      time = ptime.Trim();
      dateStamp = finalDate;
      magnitude = float.Parse(pmagnitude);
      smagnitude = pmagnitude.Trim();
      latitude = float.Parse(platitude);
      slatitude = platitude.Trim();
      longitude = float.Parse(plongitude);
      slongitude = plongitude.Trim();
      depth = float.Parse(pdepth);
      sdepth = pdepth.Trim();
      region = pregion.Trim();
      iris = Convert.ToInt32(piris);
      siris = piris.Trim();
      timestamp = Convert.ToInt32(ptimestamp);
      stimestamp = ptimestamp.Trim();

    }
    public void printData()
    {
      Console.WriteLine("|{0,-5}  |{1,-10}  |{2,-5}  |{3,-5}  |{4,-5}  |{5,-7}  |{6,-7}  |{7,-8}  |{8,-30}  |{9,-10}  |{10,-15}  ", year, month, day, time, magnitude, latitude, longitude, depth, region, iris, timestamp);
    }
  }

  public class quickSort
  {
    public void quickSorting(List<Seismic> dataObjects, int left, int right)
    {
      int i = left, j = right;
      var pivot = dataObjects.ElementAt((left + right)/2).dateStamp;

      while(i <= j)
      {
        while (dataObjects.ElementAt(i).dateStamp.CompareTo(pivot) < 0)
        {
          Console.WriteLine("moving pivot right");
          i++;
        }
        while (dataObjects.ElementAt(j).dateStamp.CompareTo(pivot) > 0)
        {
          Console.WriteLine("moving pivot left");
          j--;
        }
        if (i <= j)
        {
          // Swap
          var tmp = dataObjects.ElementAt(i).dateStamp;
          dataObjects.ElementAt(i).dateStamp = dataObjects.ElementAt(j).dateStamp;
          dataObjects.ElementAt(j).dateStamp = tmp;
          i++;
          j--;
        }
      }
      if (left < j)
      {
        Console.WriteLine("recursive");
        quickSorting(dataObjects, left, j);
      }

      if (i < right)
      {
        Console.WriteLine("recursive");
        quickSorting(dataObjects, i, right);
      }



    }
  }

  public class compare
  {
    public int dateCompare(DateTime a, DateTime b)
    {
      if(a > b)
      {
        return 1;
      }
      else if (a < b)
      {
        return -1;
      }
      else
      {
        return 0;
      }
    }
  }
}

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
  public class Sort
  {
    private static string _whichArray;
    private static List<Seismic> _dataList = new List<Seismic>();
    private static string whichData;
    private static string whatAnalysis;

    private static void printField(int i)
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
    }
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
        Seismic s = new Seismic(year, month, day, time, magnitude, latitude, longitude, depth, region, iris, timestamp);
        _dataList.Add(s);
      }
    }
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
      Console.WriteLine("Please choose an item to sort by!");
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
      int totalEntry = 0;
      foreach (string s in File.ReadAllLines(@"sorting_files\Year_1.txt"))
      {
        totalEntry++;
      }
      Console.WriteLine("What set would you like analyse: 1 | 2 | M: ");
      whatAnalysis = Console.ReadLine().ToLower();
      if(whatAnalysis == "1")
      {
        inputFiles("1");
      }
      else if(whatAnalysis == "2")
      {
        inputFiles("2");
      }
      else if(whatAnalysis == "m")
      {
        inputFiles("1");
        inputFiles("2");
      }



      Console.WriteLine("");
      Console.Write("Type A for Ascending, or D for Decending: ");
      string inputAscDec = Console.ReadLine().ToLower();
      Console.WriteLine();
      Console.Write("Type in the key search item: ");
      string keySearch = Console.ReadLine().ToLower();
      printStart();


      if (_whichArray == "a")
      {
        if (inputAscDec == "a")
        {
          _dataList.Sort((x, y) => x.dateStamp.CompareTo(y.dateStamp));
        }
        else if (inputAscDec == "d")
        {
          _dataList.Sort((x, y) => y.dateStamp.CompareTo(x.dateStamp));
        }
        whichData = "year";
      }
      else if (_whichArray == "b")
      {
        if (inputAscDec == "a")
        {
          _dataList.Sort((x, y) => x.dateStamp.CompareTo(y.dateStamp));
        }
        else if (inputAscDec == "d")
        {
          _dataList.Sort((x, y) => y.dateStamp.CompareTo(x.dateStamp));
        }
        whichData = "month";
      }
      else if (_whichArray == "c")
      {
        if (inputAscDec == "a")
        {
          _dataList.Sort((x, y) => x.dateStamp.CompareTo(y.dateStamp));
        }
        else if (inputAscDec == "d")
        {
          _dataList.Sort((x, y) => y.dateStamp.CompareTo(x.dateStamp));
        }
        whichData = "day";
      }
      else if (_whichArray == "d")
      {
        if (inputAscDec == "a")
        {
          _dataList.Sort((x, y) => x.dateStamp.CompareTo(y.dateStamp));
        }
        else if (inputAscDec == "d")
        {
          _dataList.Sort((x, y) => y.dateStamp.CompareTo(x.dateStamp));
        }
        whichData = "time";
      }
      else if (_whichArray == "e")
      {
        if (inputAscDec == "a")
        {
          _dataList.Sort((x, y) => x.magnitude.CompareTo(y.magnitude));
        }
        else if (inputAscDec == "d")
        {
          _dataList.Sort((x, y) => y.magnitude.CompareTo(x.magnitude));
        }
        whichData = "magnitude";
      }
      else if (_whichArray == "f")
      {
        if (inputAscDec == "a")
        {
          _dataList.Sort((x, y) => x.latitude.CompareTo(y.latitude));
        }
        else if (inputAscDec == "d")
        {
          _dataList.Sort((x, y) => y.latitude.CompareTo(x.latitude));
        }
        whichData = "latitude";
      }
      else if (_whichArray == "g")
      {
        if (inputAscDec == "a")
        {
          _dataList.Sort((x, y) => x.longitude.CompareTo(y.longitude));
        }
        else if (inputAscDec == "d")
        {
          _dataList.Sort((x, y) => y.longitude.CompareTo(x.longitude));
        }
        whichData = "longitude";
      }
      else if (_whichArray == "h")
      {
        if (inputAscDec == "a")
        {
          _dataList.Sort((x, y) => x.depth.CompareTo(y.depth));
        }
        else if (inputAscDec == "d")
        {
          _dataList.Sort((x, y) => y.depth.CompareTo(x.depth));
        }
        whichData = "depth";
      }
      else if (_whichArray == "i")
      {
        if (inputAscDec == "a")
        {
          _dataList.Sort((x, y) => x.region.CompareTo(y.region));
        }
        else if (inputAscDec == "d")
        {
          _dataList.Sort((x, y) => y.region.CompareTo(x.region));
        }
        whichData = "region";
      }
      else if (_whichArray == "j")
      {
        if (inputAscDec == "a")
        {
          _dataList.Sort((x, y) => x.iris.CompareTo(y.iris));
        }
        else if (inputAscDec == "d")
        {
          _dataList.Sort((x, y) => y.iris.CompareTo(x.iris));
        }
        whichData = "iris";
      }
      else if (_whichArray == "k")
      {
        if (inputAscDec == "a")
        {
          _dataList.Sort((x, y) => x.timestamp.CompareTo(y.timestamp));
        }
        else if (inputAscDec == "d")
        {
          _dataList.Sort((x, y) => y.timestamp.CompareTo(x.timestamp));
        }
        whichData = "timestamp";
      }
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
              dataPrint();
              printed = true;
            }
            _dataList.ElementAt(i).printData();
            isFound = true;
          }
        }
        if (!isFound)
        {
          Console.WriteLine("\nNo value found...\n");
          Console.Write("Try again: ");
          keySearch = Console.ReadLine().ToLower();
          printStart();
        }
        else if (isFound)
        {
          break;
        }

      }            
    }
    private static void dataPrint()
    {
      Console.WriteLine();
      Console.WriteLine("|Year   |Month       |Day    |Time      |Magni  |Lati   |Long   |Depth     |Region                          |Iris        |Timestamp");
      Console.WriteLine("|-------|------------|-------|----------|-------|-------|-------|----------|--------------------------------|------------|----------");
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

    public Seismic(string pyear, string pmonth, string pday, string ptime, string pmagnitude, string platitude, string plongitude, string pdepth, string pregion, string piris, string ptimestamp)
    {
      year = Convert.ToInt32(pyear);
      syear = pyear.Trim();
      month = pmonth.Trim();
      day = Convert.ToInt32(pday);
      sday = pday.Trim();
      time = ptime.Trim();
      dateStamp = new DateTime();
      dateStamp = DateTime.Parse(string.Format("{0} {1} {2} {3}", day, month, year, time));
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
      Console.WriteLine("|{0,-5}  |{1,-10}  |{2,-5}  |{3,-5}  |{4,-5}  |{5,-5}  |{6,-5}  |{7,-8}  |{8,-30}  |{9,-10}  |{10,-15}  ", year, month, day, time, magnitude, latitude, longitude, depth, region, iris, timestamp);
    }
  }
}
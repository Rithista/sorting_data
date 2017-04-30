using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Input;
using System.Text;
using System.Reflection;
using System.Diagnostics;

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
        
        Seismic s = new Seismic(year, month, day, time, magnitude, latitude, longitude, depth, region, iris, timestamp);
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


      _dataList.Clear();
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



      bool isEntered = false;
      bool isDescending = true;
      Console.Write("\nType A for Ascending, or D for Descending: ");
      string inputAscDec = Console.ReadLine().ToLower();
      while (!isEntered)
      {
        if (inputAscDec == "a") {
          ascDesc = "Ascending";
          isDescending = false;

          isEntered = true;
          break;
        }
        else if (inputAscDec == "d")
        {
          ascDesc = "Descending";
          isDescending = true;

          isEntered = true;
          break;
        }
        else
        {
          printStart();
          Console.Write("Please enter a valid letter, A for Ascending, or D for Descending: ");
          inputAscDec = Console.ReadLine().ToLower();
        }
      }
      Console.Write("\nPlease enter which sort you would like to use, Q for Quicksort or B for Bubblesort: ");
      bool sortEntered = false;
      string sortString = Console.ReadLine().ToLower();
      Stopwatch sortTimer = new Stopwatch();
      string elapsedTime;


      while (!sortEntered)
      {
        if (sortString == "q")
        {
          sortTimer.Start();
          Sorter.quickSort(_dataList, 0, _dataList.Count() - 1, isDescending);
          sortTimer.Stop();
          elapsedTime = String.Format("{0:0.0}", sortTimer.ElapsedMilliseconds);
          Console.Write("\nQuicksort has sorted the data and took {0} milliseconds\n", elapsedTime);
          sortEntered = true;
          break;
        }
        else if (sortString == "b")
        {
          sortTimer.Start();
          Sorter.bubbleSort(_dataList, isDescending);
          sortTimer.Stop();
          elapsedTime = String.Format("{0:0.0}", sortTimer.ElapsedMilliseconds);
          Console.Write("\nBubblesort has sorted the data and took {0} milliseconds\n", elapsedTime);
          sortEntered = true;
          break;
        }
        else
        {
          printStart();
          Console.Write("\nPlease enter a valid sort, Q for Quicksort or B for Bubblesort: ");
          sortString = Console.ReadLine().ToLower();
        }
        
        
      }

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
      printMinMax();

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

    private static void printMinMax()
    {
      string floatMax = float.MaxValue.ToString();
      string intMax = int.MaxValue.ToString();


      Seismic min = new Seismic("9999", "December", "31", "23:59:59", floatMax, floatMax, floatMax, floatMax, "", intMax, intMax);
      Seismic max = new Seismic("1", "January", "1", "00:00:00", "0", "0", "0", "0", "", "0", "0");
      int minYear = 9999, maxYear = 1, minMonth = 12, maxMonth = 1, minDay = 31, maxDay = 1, minHours = 23, maxHours = 0, minMinutes = 59, maxMinutes = 0, minSeconds = 59, maxSeconds = 0, minIris = int.MaxValue, maxIris = 0, minTimestamp = int.MaxValue, maxTimestamp = 0;
      float minMagnitude = float.MaxValue, maxMagnitude = 0, minLatitude = float.MaxValue, maxLatitude = 0, minLongitude = float.MaxValue, maxLongitude = 0, minDepth = float.MaxValue, maxDepth = 0;
      string minRegion = "~", maxRegion = "";
      int regionCompare;
      for(int i = 0; i < _dataList.Count(); i++)
      {
        Seismic tmp = _dataList.ElementAt(i);
        if(tmp.dateStamp.Year > maxYear)
        {
          maxYear = tmp.dateStamp.Year;
        }
        if (tmp.dateStamp.Year < minYear)
        {
          minYear = tmp.dateStamp.Year;
        }
        if (tmp.dateStamp.Month > maxMonth)
        {
          maxMonth = tmp.dateStamp.Month;
        }
        if (tmp.dateStamp.Month < minMonth)
        {
          minMonth = tmp.dateStamp.Month;
        }
        if (tmp.dateStamp.Day > maxDay)
        {
          maxDay = tmp.dateStamp.Day;
        }
        if (tmp.dateStamp.Day < minDay)
        {
          minDay = tmp.dateStamp.Day;
        }
        if (tmp.dateStamp.Hour > maxHours)
        {
          maxHours = tmp.dateStamp.Hour;
          maxMinutes = tmp.dateStamp.Minute;
          maxSeconds = tmp.dateStamp.Second;
        }
        if(tmp.dateStamp.Hour == maxHours)
        {
          if (tmp.dateStamp.Minute > maxMinutes)
          {
            maxMinutes = tmp.dateStamp.Minute;
            maxSeconds = tmp.dateStamp.Second;
          }
          if (tmp.dateStamp.Minute == maxMinutes)
          {
            if(tmp.dateStamp.Second > maxSeconds)
            {
              maxSeconds = tmp.dateStamp.Second;
            }
          }
        }
        regionCompare = String.CompareOrdinal(tmp.region, minRegion);
        if (regionCompare < 0)
        {
          minRegion = tmp.region;
        }
        regionCompare = String.CompareOrdinal(tmp.region, maxRegion);
        if (regionCompare > 0)
        {
          maxRegion = tmp.region;
        }
        if (tmp.dateStamp.Hour < minHours)
        {
          minHours = tmp.dateStamp.Hour;
          minMinutes = tmp.dateStamp.Minute;
          minSeconds = tmp.dateStamp.Second;
        }
        if (tmp.dateStamp.Hour == minHours)
        {
          if (tmp.dateStamp.Minute < minMinutes)
          {
            minMinutes = tmp.dateStamp.Minute;
            minSeconds = tmp.dateStamp.Second;
          }
          if (tmp.dateStamp.Minute == minMinutes)
          {
            if (tmp.dateStamp.Second < minSeconds)
            {
              minSeconds = tmp.dateStamp.Second;
            }
          }
        }
        if (tmp.magnitude > maxMagnitude)
        {
          maxMagnitude = tmp.magnitude;
        }
        if (tmp.magnitude < minMagnitude)
        {
          minMagnitude = tmp.magnitude;
        }
        if (tmp.latitude > maxLatitude)
        {
          maxLatitude = tmp.latitude;
        }
        if (tmp.latitude < minLatitude)
        {
          minLatitude = tmp.latitude;
        }
        if (tmp.longitude > maxLongitude)
        {
          maxLongitude = tmp.longitude;
        }
        if (tmp.longitude < minLongitude)
        {
          minLongitude = tmp.longitude;
        }
        if (tmp.depth > maxDepth)
        {
          maxDepth = tmp.depth;
        }
        if (tmp.depth < minDepth)
        {
          minDepth = tmp.depth;
        }
        if (tmp.iris > maxIris)
        {
          maxIris = tmp.iris;
        }
        if (tmp.iris < minIris)
        {
          minIris = tmp.iris;
        }
        if (tmp.timestamp > maxTimestamp)
        {
          maxTimestamp = tmp.timestamp;
        }
        if (tmp.timestamp < minTimestamp)
        {
          minTimestamp = tmp.timestamp;
        }
      }
      string[] months = new string[] {"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

      Console.WriteLine("|Minimum Values");
      Console.WriteLine("|{0,-5}  |{1,-10}  |{2,-5}  |{3,-5}  |{4,-5}  |{5,-7}  |{6,-7}  |{7,-8}  |{8,-30}  |{9,-10} |{10,-10}", minYear, months[minMonth - 1], minDay, String.Format("{0:00}:{1:00}:{2:00}", minHours, minMinutes, minSeconds), String.Format("{0:0.000}", minMagnitude), String.Format("{0:0.000}", minLatitude), String.Format("{0:0.000}", minLongitude), String.Format("{0:0.000}", minDepth), minRegion, minIris, minTimestamp);
      Console.WriteLine("Maximum Values in data...");
      Console.WriteLine("|{0,-5}  |{1,-10}  |{2,-5}  |{3,-5}  |{4,-5}  |{5,-7}  |{6,-7}  |{7,-8}  |{8,-30}  |{9,-10} |{10,-10}", maxYear, months[maxMonth - 1], maxDay, String.Format("{0:00}:{1:00}:{2:00}", maxHours, maxMinutes, maxSeconds), String.Format("{0:0.000}", maxMagnitude), String.Format("{0:0.000}", maxLatitude), String.Format("{0:0.000}", maxLongitude), String.Format("{0:0.000}", maxDepth), maxRegion, maxIris, maxTimestamp);
    }
  }

  public class Seismic : IComparable
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
      dateStamp = DateTime.Parse(string.Format("{0} {1} {2} {3}", day, month, year, time));

    }


    public void printData()
    {
      Console.WriteLine("|{0,-5}  |{1,-10}  |{2,-5}  |{3,-5}  |{4,-5}  |{5,-7}  |{6,-7}  |{7,-8}  |{8,-30}  |{9,-10}  |{10,-15}  ", year, month, day, time, String.Format("{0:0.000}", magnitude), String.Format("{0:00.000}", latitude), String.Format("{0:00.000}", longitude), String.Format("{0:0.000}", depth), region, iris, timestamp);
    }

    public int CompareTo(object obj)
    {
      if(obj == null)
      {
        return 1;
      }
      Seismic other = obj as Seismic;
      if(other != null)
      {
        return this.dateStamp.CompareTo(other.dateStamp);
      }
      else
      {
        throw new ArgumentException("Object is not a Seismic");
      }
    }
  }

  public class Sorter
  {
    public static void quickSort(List<Seismic> dataObjects, int left, int right, bool isDescending)
    {
      int i = left, j = right;
      Seismic pivot = dataObjects.ElementAt((left + right)/2);

      while(i <= j)
      {
        if (isDescending)
        {
          while (dataObjects.ElementAt(i).CompareTo(pivot) > 0)
          {
            i++;
          }
        }
        else {
          while (dataObjects.ElementAt(i).CompareTo(pivot) < 0)
          {
            i++;
          }
        }

        if (isDescending)
        {
          while (dataObjects.ElementAt(j).CompareTo(pivot) < 0)
          {
            j--;
          }
        }
        else
        {
          while (dataObjects.ElementAt(j).CompareTo(pivot) > 0)
          {
            j--;
          }
        }
        if (i <= j)
        {
          // Swap
          Seismic tmp = dataObjects.ElementAt(i);
          dataObjects[i] = dataObjects.ElementAt(j);
          dataObjects[j] = tmp;
          i++;
          j--;
        }
      }
      if (left < j)
      {
        
        quickSort(dataObjects, left, j, isDescending);
      }

      if (i < right)
      {
        
        quickSort(dataObjects, i, right, isDescending);
      }
    }
    public static void bubbleSort(List<Seismic> dataObjects, bool isDescending)
    {
      Seismic tmp;
      for (int i = 0; i < dataObjects.Count(); i++)
      {
        for (int sort = 0; sort < dataObjects.Count() - 1; sort++)
        {
          if (!isDescending)
          {
            if (dataObjects.ElementAt(sort).CompareTo(dataObjects.ElementAt(sort + 1)) > 0)
            {
              tmp = dataObjects.ElementAt(sort + 1);
              dataObjects[sort + 1] = dataObjects[sort];
              dataObjects[sort] = tmp;
            }
          }
          if (isDescending)
          {
            if (dataObjects.ElementAt(sort).CompareTo(dataObjects.ElementAt(sort + 1)) < 0)
            {
              tmp = dataObjects.ElementAt(sort + 1);
              dataObjects[sort + 1] = dataObjects[sort];
              dataObjects[sort] = tmp;
            }
          }
        }
      }
    }
  }
 }


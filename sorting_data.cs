/*
+------------------------------------------------------------+
| Module Name: Algorithms and Complexity                     |
| Module Purpose: Sort Seismic data (Earthquake)             |
| Inputs: User                                               |
| Outputs: Console                                           |
| Programmer name: Harry Jones                               |
+------------------------------------------------------------+
 */

//Importing C# syntax
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Input;
using System.Text;
using System.Reflection;
using System.Diagnostics;

namespace sorting_data //Namespace to cover whole program
{
  public class Program //Start of class Program
  {
    //Private static variables initalised at the top so they are accessable throughout the class
    private static string _whichArray;
    private static List<Seismic> _dataList = new List<Seismic>();
    private static string whichData;
    private static string whatAnalysis;
    private static string whatSet;
    private static string ascDesc;

    //static method which gets the current data so it can be compared against to be printed
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

    //static method which imports the data depending on the users input with args j
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
        Seismic s = new Seismic(year, month, day, time, magnitude, latitude, longitude, depth, region, iris, timestamp); //creates a new Seismic object from the imported data
        _dataList.Add(s); //Add object to the data list
      }
    }

    //static method which clears the console, sets its height and width, and prints out a fancy screen display (not really needed)
    public static void printStart()
    {
      Console.Clear();
      Console.BufferHeight = Int16.MaxValue - 1;
      var w = Console.WindowWidth;
      var h = Console.WindowHeight;
      if (w < 200 || h < 75)
      {
        Console.SetWindowSize(200, 75);
      }
      Console.ForegroundColor = ConsoleColor.Red;
      Console.WriteLine("=======================================================");
      Console.ForegroundColor = ConsoleColor.Yellow;
      System.Threading.Thread.Sleep(10);
      Console.WriteLine("                | | | |                     | |       ");
      Console.ForegroundColor = ConsoleColor.Green;
      System.Threading.Thread.Sleep(10);
      Console.WriteLine("  ___  __ _ _ __| |_| |__   __ _ _   _  __ _| | _____ ");
      Console.ForegroundColor = ConsoleColor.Magenta;
      System.Threading.Thread.Sleep(10);
      Console.WriteLine(" / _ \\/ _` | '__| __| '_ \\ / _` | | | |/ _` | |/ / _ \\");
      Console.ForegroundColor = ConsoleColor.Cyan;
      System.Threading.Thread.Sleep(10);
      Console.WriteLine("|  __/ (_| | |  | |_| | | | (_| | |_| | (_| |   <  __/");
      Console.ForegroundColor = ConsoleColor.DarkBlue;
      System.Threading.Thread.Sleep(10);
      Console.WriteLine(" \\___|\\__,_|_|   \\__|_| |_|\\__, |\\__,_|\\__,_|_|\\_\\___|");
      Console.ForegroundColor = ConsoleColor.DarkCyan;
      System.Threading.Thread.Sleep(10);
      Console.WriteLine("                              | |                     ");
      Console.ForegroundColor = ConsoleColor.DarkYellow;
      System.Threading.Thread.Sleep(10);
      Console.WriteLine("                              |_|                   ");
      Console.ForegroundColor = ConsoleColor.DarkGreen;
      System.Threading.Thread.Sleep(10);
      Console.WriteLine("=======================================================");
      Console.ForegroundColor = ConsoleColor.Red;
      System.Threading.Thread.Sleep(10);
      Console.SetCursorPosition(0, 0);
      Console.ForegroundColor = ConsoleColor.White;
      Console.WriteLine("=======================================================");
      System.Threading.Thread.Sleep(10);
      Console.WriteLine("                | | | |                     | |       ");
      System.Threading.Thread.Sleep(10);
      Console.WriteLine("  ___  __ _ _ __| |_| |__   __ _ _   _  __ _| | _____ ");
      System.Threading.Thread.Sleep(10);
      Console.WriteLine(" / _ \\/ _` | '__| __| '_ \\ / _` | | | |/ _` | |/ / _ \\");
      System.Threading.Thread.Sleep(10);
      Console.WriteLine("|  __/ (_| | |  | |_| | | | (_| | |_| | (_| |   <  __/");
      System.Threading.Thread.Sleep(10);
      Console.WriteLine(" \\___|\\__,_|_|   \\__|_| |_|\\__, |\\__,_|\\__,_|_|\\_\\___|");
      System.Threading.Thread.Sleep(10);
      Console.WriteLine("                              | |                     ");
      System.Threading.Thread.Sleep(10);
      Console.WriteLine("                              |_|                   ");
      System.Threading.Thread.Sleep(10);
      Console.WriteLine("=======================================================");
      System.Threading.Thread.Sleep(10);

    }


    static void Main() //Start of Main
    {
      //prints the start of the program
      //then prints out all the options the user
      //has for data types to select
      printStart();
      Console.WriteLine("Please choose a Data type to sort by!");
      System.Threading.Thread.Sleep(10);
      Console.WriteLine("A : Year");
      System.Threading.Thread.Sleep(10);
      Console.WriteLine("B : Month");
      System.Threading.Thread.Sleep(10);
      Console.WriteLine("C : Day");
      System.Threading.Thread.Sleep(10);
      Console.WriteLine("D : Time (UTC)");
      System.Threading.Thread.Sleep(10);
      Console.WriteLine("E : Magnitude");
      System.Threading.Thread.Sleep(10);
      Console.WriteLine("F : Latitude");
      System.Threading.Thread.Sleep(10);
      Console.WriteLine("G : Longitude");
      System.Threading.Thread.Sleep(10);
      Console.WriteLine("H : Depth");
      System.Threading.Thread.Sleep(10);
      Console.WriteLine("I : Region");
      System.Threading.Thread.Sleep(10);
      Console.WriteLine("J : IRIS_ID");
      System.Threading.Thread.Sleep(10);
      Console.WriteLine("K : Timestamp\n");
      System.Threading.Thread.Sleep(10);
      Console.Write("Data type letter: ");

      //while loop which checks to see if the entered letter from the user
      //is a letter on the list
      //if not then it asks for the users input again
      bool dataTypeSelect = false;
      _whichArray = Console.ReadLine().ToLower();
      string[] dataTypeValue = new string[11] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k" };
      while (!dataTypeSelect)
      {
        if (dataTypeValue.Contains(_whichArray))
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

      //Clears out the previous object list if the program has been restarted
      //asks for the users input on what data sets to use
      //while loop which runs while the user input is not
      //of the correct type
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

      //gets users input for ascending and descending
      //while loop runs until the users input matches the criteria
      bool isEntered = false;
      bool isDescending = true;
      Console.Write("\nType A for Ascending, or D for Descending: ");
      string inputAscDec = Console.ReadLine().ToLower();
      while (!isEntered)
      {
        if (inputAscDec == "a")
        {
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
      //If block which converts the users input
      //at the beggining into a string which can
      //be used to display their data type selection
      if (_whichArray == "a")
      {
        whichData = "Year";
        Sorter.key = 1;

      }
      else if (_whichArray == "b")
      {
        whichData = "Month";
        Sorter.key = 2;
      }
      else if (_whichArray == "c")
      {
        whichData = "Day";
        Sorter.key = 3;
      }
      else if (_whichArray == "d")
      {
        whichData = "Time";
        Sorter.key = 4;
      }
      else if (_whichArray == "e")
      {
        whichData = "Magnitude";
        Sorter.key = 5;
      }
      else if (_whichArray == "f")
      {
        whichData = "Latitude";
        Sorter.key = 6;
      }
      else if (_whichArray == "g")
      {
        whichData = "Longitude";
        Sorter.key = 7;
      }
      else if (_whichArray == "h")
      {
        whichData = "Depth";
        Sorter.key = 8;
      }
      else if (_whichArray == "i")
      {
        whichData = "Region";
        Sorter.key = 9;
      }
      else if (_whichArray == "j")
      {
        whichData = "Iris_ID";
        Sorter.key = 10;
      }
      else if (_whichArray == "k")
      {
        whichData = "Timestamp";
        Sorter.key = 11;
      }

      //gets users input for which sort to use, Quicksort or bubblesort
      //creates a stop watch to show the user the time effeciency
      //while loop runs until user input matches criteria
      Console.Write("\nPlease enter which sort you would like to use, Q for Quicksort or B for Bubblesort: ");
      bool sortEntered = false;
      string sortString = Console.ReadLine().ToLower();
      Stopwatch sortTimer = new Stopwatch();
      string elapsedTime;
      string whichSort = "";
      while (!sortEntered)
      {
        if (sortString == "q") //Quicksort
        {
          whichSort = "Quicksort";
          sortTimer.Start();
          Sorter.quickSort(_dataList, 0, _dataList.Count() - 1, isDescending);
          sortTimer.Stop();
          elapsedTime = String.Format("{0:0.0}", sortTimer.ElapsedMilliseconds);
          whichSort = String.Format("\nQuicksort has sorted the data and took {0} milliseconds with {1} operations\n", elapsedTime, Sorter.quickSortTotal());
          sortEntered = true;
          break;
        }
        else if (sortString == "b") //Bubblesort
        {
          whichSort = "Bubblesort";
          sortTimer.Start();
          Sorter.bubbleSort(_dataList, isDescending);
          sortTimer.Stop();
          elapsedTime = String.Format("{0:0.0}", sortTimer.ElapsedMilliseconds);
          whichSort = String.Format("\nBubblesort has sorted the data and took {0} milliseconds with {1} operations\n", elapsedTime, Sorter.bubbleSortTotal());
          sortEntered = true;
          break;
        }
        else //Try again
        {
          printStart();
          Console.Write("Please enter a valid sort, Q for Quicksort or B for Bubblesort: ");
          sortString = Console.ReadLine().ToLower();
        }
      }

      //Print out single sorted data set
      Console.ForegroundColor = ConsoleColor.Green;
      Console.WriteLine("|{0,-5}|{1,-24}|", whichData, ascDesc);
      Console.ForegroundColor = ConsoleColor.White;
      Console.WriteLine("|------------------------------|");
      for(int i = 0; i < _dataList.Count; i++)
      {
        _dataList.ElementAt(i).printValue(Sorter.key);
      }
      //Print out timing data from the sort
      Console.ForegroundColor = ConsoleColor.Cyan;
      Console.WriteLine(whichSort);
      Console.ForegroundColor = ConsoleColor.White;

      //Set sort key back to 0 so the sorter can sort everything by DateTime
      //DateTime will then show the data better
      Sorter.key = 0;

      //Recalling quicksort to sort new Sorter.Key because it is the quickest
      Sorter.quickSort(_dataList, 0, _dataList.Count() - 1, isDescending);



      //Asks users what they would like to search for
      //in the current selected data type
      //while loop runs for each entry from their search
      //loop also prints out error message if no search is found
      Console.Write("\nType in the key search item for Data type |{0}|: ", whichData);
      string keySearch = Console.ReadLine().ToLower();
      printStart();
      bool isFound = false;
      bool printed = false;
      while (!isFound)
      {
        for (int i = 0; i < _dataList.Count; i++)
        {
          string v = getData(i); //Finds current data type key word


          if (String.Equals(v.ToLower(), keySearch.ToLower())) //Compares current data type key word with users search word
          {
            if (!printed) //only runs once
            {
              Console.ForegroundColor = ConsoleColor.Yellow;
              Console.WriteLine("Data set --> |{0}| Data type -->|{1}| Sorted -->|{2}| Search -->|{3}| \n", whatSet, whichData, ascDesc, keySearch);
              Console.ForegroundColor = ConsoleColor.White;
              dataPrint();
              printed = true;
            }
            _dataList.ElementAt(i).printData(); //Prints out the current record if the string compare is true
            isFound = true; //lets the while loop know not to run again once the for loop has finished
          }
        }
        if (!isFound) //If the search didn't find any matching data words, print out error message
        {
          Console.ForegroundColor = ConsoleColor.Red;
          Console.WriteLine("Data set --> |{0}| Data type -->|{1}| Sorted -->|{2}|\n", whatSet, whichData, ascDesc);
          Console.ForegroundColor = ConsoleColor.White;
          Console.WriteLine("No value found in Data type\n");
          Console.Write("Please enter another entry or type R to reset: "); //Give the user an option to try again or reset
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
      printMinMax(); //Print out the minimum and maximum values in the dataset once outside of the loop
                     //you can only make it outside of this loop if you found atleast one data word match

      //Gives choice to user
      //another entry of exit the application
      //while loop runs until user input matches criteria
      bool exit = false;
      Console.Write("\n\n\n\n\nType N for Next entry, or E to Exit the application: ");
      while (!exit)
      {
        string userExit = Console.ReadLine().ToLower();
        if (userExit == "n")
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
    }//End of main

    //static method which prints out the head of record table, this is only called once in the while loop
    private static void dataPrint()
    {
      Console.WriteLine();
      Console.ForegroundColor = ConsoleColor.Magenta;
      Console.WriteLine("|===============================================================|Found Records|========================================================|");
      Console.ForegroundColor = ConsoleColor.White;
      Console.WriteLine("|Year   |Month       |Day    |Time      |Magni  |Lati     |Long     |Depth     |Region                          |Iris       |Timestamp |");
      Console.WriteLine("|-------|------------|-------|----------|-------|---------|---------|----------|--------------------------------|-----------|----------|");
    }

    //static method which finds the minimum and maximum of the imported data
    //this is done through a linear search
    private static void printMinMax()
    {
      //variable declaring at the top of the method
      string floatMax = float.MaxValue.ToString();
      string intMax = int.MaxValue.ToString();
      int minYear = 9999, maxYear = 1, minMonth = 12, maxMonth = 1, minDay = 31, maxDay = 1, minHours = 23, maxHours = 0, minMinutes = 59, maxMinutes = 0,
          minSeconds = 59, maxSeconds = 0, minIris = int.MaxValue, maxIris = 0, minTimestamp = int.MaxValue, maxTimestamp = 0;
      float minMagnitude = float.MaxValue, maxMagnitude = 0, minLatitude = float.MaxValue, maxLatitude = 0, minLongitude = float.MaxValue, maxLongitude = 0, minDepth = float.MaxValue, maxDepth = 0;
      string minRegion = "~", maxRegion = "";
      int regionCompare;

      for (int i = 0; i < _dataList.Count(); i++)//For loop which runs for each of the entries in the data list of objects
      {
        Seismic tmp = _dataList.ElementAt(i); //tmp = Current data object

        if (tmp.dateStamp.Year > maxYear)
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
        if (tmp.dateStamp.Hour == maxHours)
        {
          if (tmp.dateStamp.Minute > maxMinutes)
          {
            maxMinutes = tmp.dateStamp.Minute;
            maxSeconds = tmp.dateStamp.Second;
          }
          if (tmp.dateStamp.Minute == maxMinutes)
          {
            if (tmp.dateStamp.Second > maxSeconds)
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
      //string array which will convert the DateTime output into a month string
      string[] months = new string[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

      //Console printout for minimum and maximum values found in the linear search
      Console.ForegroundColor = ConsoleColor.Cyan;
      Console.WriteLine("\n\n|==================================================|Minimum Values in data set {0,-7}|================================================|", whatSet);
      Console.ForegroundColor = ConsoleColor.White;
      Console.WriteLine("|Year   |Month       |Day    |Time      |Magni  |Lati     |Long     |Depth     |Region                          |Iris       |Timestamp |");
      Console.WriteLine("|-------|------------|-------|----------|-------|---------|---------|----------|--------------------------------|-----------|----------|");
      Console.WriteLine("|{0,-5}  |{1,-10}  |{2,-5}  |{3,-5}  |{4,-5}  |{5,-7}  |{6,-7}  |{7,-8}  |{8,-30}  |{9,-10} |{10,-10}|", minYear, months[minMonth - 1], minDay, String.Format("{0:00}:{1:00}:{2:00}", minHours, minMinutes, minSeconds), String.Format("{0:0.000}", minMagnitude), String.Format("{0:0.000}", minLatitude), String.Format("{0:0.000}", minLongitude), String.Format("{0:0.000}", minDepth), minRegion, minIris, minTimestamp);
      Console.WriteLine("|______________________________________________________________________________________________________________________________________|");
      Console.ForegroundColor = ConsoleColor.Green;
      Console.WriteLine("\n\n|==================================================|Maximum Values in data set {0,-7}|================================================|", whatSet);
      Console.ForegroundColor = ConsoleColor.White;
      Console.WriteLine("|Year   |Month       |Day    |Time      |Magni  |Lati     |Long     |Depth     |Region                          |Iris       |Timestamp |");
      Console.WriteLine("|-------|------------|-------|----------|-------|---------|---------|----------|--------------------------------|-----------|----------|");
      Console.WriteLine("|{0,-5}  |{1,-10}  |{2,-5}  |{3,-5}  |{4,-5}  |{5,-7}  |{6,-7}  |{7,-8}  |{8,-30}  |{9,-10} |{10,-10}|", maxYear, months[maxMonth - 1], maxDay, String.Format("{0:00}:{1:00}:{2:00}", maxHours, maxMinutes, maxSeconds), String.Format("{0:0.000}", maxMagnitude), String.Format("{0:0.000}", maxLatitude), String.Format("{0:0.000}", maxLongitude), String.Format("{0:0.000}", maxDepth), maxRegion, maxIris, maxTimestamp);
      Console.WriteLine("|______________________________________________________________________________________________________________________________________|");
    }
  }//End of class Program

  //Start of class Seismic
  public class Seismic : IComparable
  {
    //public variable declaring at top of class
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

    //public constructor which builds the seismic objects from Program.getData()
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
      dateStamp = DateTime.Parse(string.Format("{0} {1} {2} {3}", day, month, year, time)); //dateStamp which will be used to sort the data
    }

    //public method to print out the current Seismic object when this method is called
    public void printData()
    {
      Console.WriteLine("|{0,-5}  |{1,-10}  |{2,-5}  |{3,-5}  |{4,-5}  |{5,-7}  |{6,-7}  |{7,-8}  |{8,-30}  |{9,-9}  |{10}|", year, month, day, time, String.Format("{0:0.000}", magnitude), String.Format("{0:00.000}", latitude), String.Format("{0:00.000}", longitude), String.Format("{0:0.000}", depth), region, iris, timestamp);
    }

    public void printValue(int key)
    {
      switch (key)
      {
        case 0:
          Console.WriteLine("|{0,-30}|", this.dateStamp);
          break;
        case 1:
          Console.WriteLine("|{0,-30}|", this.year);
          break;
        case 2:
          Console.WriteLine("|{0,-30}|", this.month);
          break;
        case 3:
          Console.WriteLine("|{0,-30}|", this.day);
          break;
        case 4:
          Console.WriteLine("|{0,-30}|", this.time);
          break;
        case 5:
          Console.WriteLine("|{0,-30}|", this.magnitude);
          break;
        case 6:
          Console.WriteLine("|{0,-30}|", this.latitude);
          break;
        case 7:
          Console.WriteLine("|{0,-30}|", this.longitude);
          break;
        case 8:
          Console.WriteLine("|{0,-30}|", this.depth);
          break;
        case 9:
          Console.WriteLine("|{0,-30}|", this.region);
          break;
        case 10:
          Console.WriteLine("|{0,-30}|", this.iris);
          break;
        case 11:
          Console.WriteLine("|{0,-30}|", this.timestamp);
          break;
        default: Console.WriteLine("No data found");
          break;

      }
    }

    //public method which compares an object with dateStamp, used in sorting
    public int CompareTo(object obj)
    {
      if (obj == null) //if the comparing object doesn't have an inherent value
      {
        return 1;
      }
      Seismic other = obj as Seismic; //Sets other to to be the argument object Seismic
      if (other != null) //Runs if the argument has a value
      {
        switch (Sorter.key)
        {
          case 0:
            return this.dateStamp.CompareTo(other.dateStamp);
          case 1:
            return this.year.CompareTo(other.year);
          case 2:
            return this.dateStamp.Month.CompareTo(other.dateStamp.Month);
          case 3:
            return this.day.CompareTo(other.day);
          case 4:
            return this.dateStamp.TimeOfDay.CompareTo(other.dateStamp.TimeOfDay);
          case 5:
            return this.magnitude.CompareTo(other.magnitude);
          case 6:
            return this.latitude.CompareTo(other.latitude);
          case 7:
            return this.longitude.CompareTo(other.longitude);
          case 8:
            return this.depth.CompareTo(other.depth);
          case 9:
            return this.region.CompareTo(other.region);
          case 10:
            return this.iris.CompareTo(other.iris);
          case 11:
            return this.timestamp.CompareTo(other.timestamp);
          default: return 0;
        }

      }
      else //returns error message if it doesn't understand what the object is
      {
        throw new ArgumentException("Object is not a Seismic");
      }
    }
  }//end of class Seismic

  //Start of public class Sorter
  public class Sorter
  {
    public static int quickSortCount = 0;
    public static int bubbleSortCount = 0;
    public static int key = 0;



    //Quicksort method
    public static void quickSort(List<Seismic> dataObjects, int left, int right, bool isDescending)
    {
      int i = left, j = right;
      Seismic pivot = dataObjects.ElementAt((left + right) / 2);

      while (i <= j) //while loop runs left and right are not set as each other
      {
        if (isDescending) //depends on users input for asc or desc
        {
          while (dataObjects.ElementAt(i).CompareTo(pivot) > 0)
          {
            quickSortCount++;
            i++;
          }
        }
        else
        {
          while (dataObjects.ElementAt(i).CompareTo(pivot) < 0)
          {
            quickSortCount++;
            i++;
          }
        }

        if (isDescending) //depends on users input for asc or desc
        {
          while (dataObjects.ElementAt(j).CompareTo(pivot) < 0)
          {
            quickSortCount++; //increases the operations count by 1
            j--;
          }
        }
        else
        {
          while (dataObjects.ElementAt(j).CompareTo(pivot) > 0)
          {
            quickSortCount++; //increases the operations count by 1
            j--;
          }
        }
        if (i <= j)
        {
          // Swap
          //creates temporary object tmp to swap the objects through
          Seismic tmp = dataObjects.ElementAt(i);
          dataObjects[i] = dataObjects.ElementAt(j);
          dataObjects[j] = tmp;
          i++;
          j--;
        }
      }
      //recursive methods
      if (left < j)
      {
        quickSort(dataObjects, left, j, isDescending); //Calls quicksort again
      }

      if (i < right)
      {
        quickSort(dataObjects, i, right, isDescending); //Calls quicksort again
      }
    }

    //Bubblesort method
    public static void bubbleSort(List<Seismic> dataObjects, bool isDescending)
    {
      Seismic tmp; //temporary Seismic object tmp

      for (int i = 0; i < dataObjects.Count(); i++)
      {
        for (int sort = 0; sort < dataObjects.Count() - 1; sort++)
        {
          if (!isDescending) //If user chose ascending
          {
            if (dataObjects.ElementAt(sort).CompareTo(dataObjects.ElementAt(sort + 1)) > 0)
            {
              //Swap
              //moves data into temporary tmp object and then swaps them around
              tmp = dataObjects.ElementAt(sort + 1);
              dataObjects[sort + 1] = dataObjects[sort];
              dataObjects[sort] = tmp;
              bubbleSortCount++; //increases the operations count by 1
            }
          }
          if (isDescending)//If user chose descending
          {
            if (dataObjects.ElementAt(sort).CompareTo(dataObjects.ElementAt(sort + 1)) < 0)
            {
              //Swap
              //moves data into temporary tmp object and then swaps them around
              tmp = dataObjects.ElementAt(sort + 1);
              dataObjects[sort + 1] = dataObjects[sort];
              dataObjects[sort] = tmp;
              bubbleSortCount++; //increases the operations count by 1
            }
          }
        }
      }
    }

    //public static methods to return the operations total for each of the sorting methods
    public static int quickSortTotal()
    {
      return quickSortCount;
    }
    public static int bubbleSortTotal()
    {
      return bubbleSortCount;
    }
  }//End of class Sorter
}//End of namespace sorting_data
//End of C# program


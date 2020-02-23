using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


/*ESCAPE SEQUENCES*/
// Escape sequences represent non-printable and special characters in literal strings. 
// Originally used to send commands to hardware devices like printers and display terminal
// They are still useful for embedded tabs, line feed and similar into the string

// use the \ to indicate the start of the escape sequence.

// \', \", \\

// Console.WriteLine("The customer said, \"I want a refund\".");

// // \r carriage return, \n new line
// Console.WriteLine("The first line.\r\nThe second line");

// // \t horizontal tab, \v vertical tab
// Console.WriteLine("aaa\tbbb\tccc\vddd\teee\tfff");

// 			//	\\ Backslash used for file path
// Console.WriteLine("C:\\users\\walt\\documents");

// 			// \u to inject unicode into string
// Console.WriteLine("Add any Unicode code point:\v\u2600 \u2614 \u2615 \u273F \r\n\u2600 \u2614 \u2615 \u273F ");

//dollarString = String.Format("{0:C}", num1);
//percentageString = String.Format("{0:P}", num1);
//interpolatedString = $"{header}{num1:P}, {num2:C}";

/*SPLIT STRINGS

		private void ButtonA_Click(object sender, RoutedEventArgs e)
		{
			string foods = "apple banana cherry durian eggplant fig grape  honey";
			OutputTextBox.Text += $"{foods}\r\n";
			// Split is used to break a delimited string into individual strings. 
			// which are added to a string array 

			var foodArray = foods.Split();
			foreach (var food in foodArray)
			{
				OutputTextBox.Text += $"{food}\r\n";
			}
		}
        //SPLIT BY COMMA
		private void ButtonB_Click(object sender, RoutedEventArgs e)
		{
			string foods = "kiwi, lemon, mushroom, onion, potato, radish, spinach, tomato";
			OutputTextBox.Text += $"{foods}\r\n";

			string[] comma = { ", " };
			var foodArray = foods.Split(comma, StringSplitOptions.None);

			foreach (var food in foodArray)
			{
				OutputTextBox.Text += $"{food}\r\n";
			}

		}
        //SPLIT USING MULTIPLE DELIMITERS
		private void ButtonC_Click(object sender, RoutedEventArgs e)
		{
			string foods = "kiwi--banana--mushroom # eggplant # potato # grape.spinach.honey";
			OutputTextBox.Text += $"{foods}\r\n";
			string[] splitters = { ", ", "--", ".", " # " };

			var foodArray = foods.Split(splitters, StringSplitOptions.None);

			foreach (var food in foodArray)
			{
				OutputTextBox.Text += $"{food}\r\n";
			}
		}
        //SPLIT BY COMMA, REMOVE EMPTY ENTRIES
		private void ButtonD_Click(object sender, RoutedEventArgs e)
		{
			string foods = "kiwi, , mushroom, onion, potato, , spinach, tomato";
			OutputTextBox.Text += $"{foods}\r\n";
			string[] comma = { ", " };
			var foodArray = foods.Split(comma, StringSplitOptions.RemoveEmptyEntries);

			foreach (var food in foodArray)
			{
				OutputTextBox.Text += $"{food}\r\n";
			}
		}

        // USING LINQ TO QUERY STRING ARRAY
        private void ButtonA_Click(object sender, RoutedEventArgs e) {
			string foods = "kiwi, lemon, kiwi, onion, potato, lemon, spinach, tomato, lemon, onion";
			OutputTextBox.Text += foods + "\r\n";
			string[] comma = { ", " };


			var foodArray = foods.Split(comma, StringSplitOptions.RemoveEmptyEntries);
            //GROUP BY EACH WORD, THEN OUTPUT FOODS THAT OCCUR MORE THAN ONCE
			var countQuery = foodArray.GroupBy(x => x).Where(x => x.Count() > 1);
			foreach (var food in foodArray)
			{
				OutputTextBox.Text += $"{food}\r\n";
			}

		}
        //convert to string array, then search for substring
		private void ButtonB_Click(object sender, RoutedEventArgs e) {

			string statusCodes = "#kr032,#rt887,#kr932,#wt187,#aa321,#bb872,#dm554";
			OutputTextBox.Text += statusCodes + "\r\n";
			var statusArray = statusCodes.Split(',');



			foreach (var status in statusArray)
			{
				OutputTextBox.Text += $"{status} \r\n";
			}
			OutputTextBox.Text += "------------\r\n";

            var query = statusArray.Where(x=>x.Contains("87"))

            foreach(var status in query)
            {
                OutputTextBox.Text += $"{status} \r\n";
            }
		}
        //join a string array and parse a delimiter
        		private void ButtonA_Click(object sender, RoutedEventArgs e)
		{
			string[] foodArray = { "banana", "celery", "kiwi", "onion", "potato", "cherry" };

			string foodString = string.Join("--=--", foodArray);

			this.OutputTextBox.Text = foodString;

		}

		private void ButtonB_Click(object sender, RoutedEventArgs e)
		{
			List<string> foodList = new List<string> { "banana", "celery", "kiwi", "onion", "potato", "cherry" };

			string foodString = String.Join("#", foodList);

			this.OutputTextBox.Text = foodString;
		}

		private void ButtonC_Click(object sender, RoutedEventArgs e)
		{

			List<double> numbers = new List<double> { 1.5, 2.5, 3.5, 8.5, 7.5, 6.5 };

			string numbersString = String.Join(" + ", numbers);
			this.OutputTextBox.Text = numbersString;
		}

        //REMOVE WHITESPACE FROM START AND END OF A STRING USING TRIM METHOD
        		private void ButtonA_Click(object sender, RoutedEventArgs e) {
			string sample = "   At Roux, our mission is to teach and inspire the next generation’s artists to create work that changes the way people think, and hopefully, even the way they act. We believe art inspires compassion by providing audiences with an empathetic outlet.  ";


			string trimmedString  = string.Empty;
			trimmedString = sample.Trim();
			OutputTextBox.Text = trimmedString;
		}
        //FIRST TRIM, THEN TRIM THE UNWANTED CHARS (specified by charsToTrim) FROM START
		private void ButtonB_Click(object sender, RoutedEventArgs e) {
			string sample = " ,,../   At Roux, our mission is to teach and inspire the next generation’s artists to create work that changes the way people think, and hopefully, even the way they act. We believe art inspires compassion by providing audiences with an empathetic outlet.  ";
			char[] charsToTrim = { ',', '.', ' ','/' };
			var trimmedString = sample.Trim().TrimStart(charsToTrim);
			OutputTextBox.Text = trimmedString;
		}
        //SEARCH FOR A SUBSTRING
        		private void ButtonA_Click(object sender, RoutedEventArgs e) {
			string longString = "01-02-03-04-05-06-07-08-09-10-11-12-13-14-15-16-17-18-19-20";

			string sub1 = longString.Substring(18);
			string sub2 = longString.Substring(18, 8);


			OutputTextBox.Text += sub1 + "\r\n";
			OutputTextBox.Text += sub2 + "\r\n";
		}

		private void ButtonB_Click(object sender, RoutedEventArgs e) {
			string longString = "AA212-BB102-CC453-BT455-TR376-GH003-QR417-NV018-AG204-LJ122";
			string result = string.Empty;
			// use Contains to determine if a sub string exists
			// use IndexOf to get index of substring
			OutputTextBox.Text += longString + "\r\n";
			string searchString = InputTextBox.Text;
            //FINDS THE SEARCHSTRING - ARRIVES AT INDEXOF SKIPS 2 CHAR, THEN GET THE NEXT 3
			if (longString.Contains(searchString))
			{
				int index = longString.IndexOf(searchString);
				result = longString.Substring(index + 2, 3); 

				OutputTextBox.Text += $"Ticket Code: {searchString} is {result}\r\n";
			}
		}
        //verify that string contains search characters
        private void ButtonA_Click(object sender, RoutedEventArgs e) {
			// #BFR--443!
			string inputString = InputTextBox.Text;
			string message = String.Empty;
			// String supports three methods to determine if a substring exists
			// Contains, StartsWith, EndsWith

			bool hasStartString, hasEndString, containsString;

			hasStartString = inputString.StartsWith("#");
			hasEndString = inputString.EndsWith("!");
			containsString = inputString.Contains("--");

			message = $"Starts with (#) :{hasStartString}, Contains (--): {containsString}, Ends with (!): {hasEndString}";
			OutputTextBox.Text = message;

		}
        //REMOVE SUBSTRING
        private void ButtonA_Click(object sender, RoutedEventArgs e) {
			// 0123456
			// 01234--	Remove(2)
			// ---3456  Remove(0,3)
			// 01----6	Remove(2,4)

			string sample = this.InputTextBox.Text;
			string prefix = "https://";

			if (sample.StartsWith(prefix))
			{
				OutputTextBox.Text = sample.Remove(0, prefix.Length);
			}
			else
			{
				OutputTextBox.Text = sample;
			}
		}
        //REMOVE SUBSTRING CASE INSENSITIVE
		private void ButtonB_Click(object sender, RoutedEventArgs e) {
			string sample = this.InputTextBox.Text;
			string prefix = "https://";

			if (sample.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
			{
				OutputTextBox.Text = sample.Remove(0, prefix.Length);
			}
			else
			{
				OutputTextBox.Text = sample;
			}
		}
        //REPLACE
		private void ButtonC_Click(object sender, RoutedEventArgs e) {
			this.OutputTextBox.Text = string.Empty;
			string sample = "aa-ss-ee-dd-we-ss-44-ss-11-ss-d-ddf-ers";
			this.OutputTextBox.Text += sample + "\r\n";
			string replacedString = sample.Replace("-",", ") ;
			OutputTextBox.Text += replacedString + "\r\n";
		}
        //REPLACE MULTIPLE
		private void ButtonD_Click(object sender, RoutedEventArgs e) {
			string sample = "ace-bow-cow-dew @elf @fig @gum hue# icy# jam#";

			this.OutputTextBox.Text += sample + "\r\n";
			string replacedString = sample.Replace("-", ", ").Replace("@", ", ").Replace("#", ", ");
			OutputTextBox.Text += replacedString + "\r\n";
		}
        //CODING CHALLENGE BETTER SUBSTRING
        private void ButtonA_Click(object sender, RoutedEventArgs e) {
			// code challenge #1
			// write a method that takes a start word and end word and returns
			// the substring contained between those words.

			// code challenge #2
			// write another method that takes a start word and end word and replacement string
			// and returns a string containing the substitute text.

			string sample = "At Roux Academy, our mission is to teach and inspire the next generation’s artists...";
			string startWord = "our";
			string endWord = "the ";
			OutputTextBox.Text += sample + "\r\n";

			string result = string.Empty;

			result = sample.Substring(20, 33);
			result = GetSubStringBetweenWords(sample, startWord, endWord);
			OutputTextBox.Text += result + "\r\n";
			result = ReplaceBetweenWords(sample, startWord, endWord, " quest is to inspire and mentor ");

			OutputTextBox.Text += result + "\r\n";
		}

		#region "Code Challenge solution"

		public string GetSubStringBetweenWords(string candidate, string firstWord, string lastWord) {
			string result = string.Empty;
			int firstSnipPointIndex, lastSnipPointIndex;

			if (DoesFirstAndLastWordExist(candidate, firstWord, lastWord))
			{
				firstSnipPointIndex = candidate.IndexOf(value: firstWord, startIndex: 0) + firstWord.Length;
				lastSnipPointIndex = candidate.IndexOf(value: lastWord, startIndex: firstSnipPointIndex);
				return candidate.Substring(startIndex: firstSnipPointIndex, length: lastSnipPointIndex - firstSnipPointIndex);
			}
			else
			{
				return string.Empty;
			}

		}
		private bool DoesFirstAndLastWordExist(string candidate, string firstWord, string lastWord) {
			return (candidate.Contains(firstWord) && candidate.Contains(lastWord));

		}
		public string ReplaceBetweenWords(string candidate, string firstWord, string lastWord, string replacementText) {
			int firstSnipPointIndex, lastSnipPointIndex;

			// "this is " "the new value " "in the string"

			if (DoesFirstAndLastWordExist(candidate, firstWord, lastWord))
			{
				firstSnipPointIndex = candidate.IndexOf(value: firstWord, startIndex: 0) + firstWord.Length;
				string firstSubstring = candidate.Substring(startIndex: 0, length: firstSnipPointIndex);

				lastSnipPointIndex = candidate.IndexOf(value: lastWord, startIndex: firstSnipPointIndex);
				
				// use remove or substring to get the end part of the string!
				string lastSubString = candidate.Remove(startIndex: 0, count: lastSnipPointIndex);
				lastSubString = candidate.Substring(startIndex: lastSnipPointIndex, length: candidate.Length - lastSnipPointIndex);

				return $"{firstSubstring}{replacementText}{lastSubString}"; ;
			}
			else
			{
				return string.Empty;
			}
		}


//CUSTOM FORMATTER CLASS
        using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleApp {
	public class RayPoint : Object, IFormattable {
        //comma
		public override string ToString() {
			return ToString("C");
		}
        //format using user's culture
		public string ToString(string format) {

			var currentCulture = System.Threading.Thread.CurrentThread.CurrentCulture;
			return ToString(format, currentCulture);
			
		}

        //format using differing separators
		public string ToString(string format, IFormatProvider formatProvider)
		{
            //cast using 
			var cultureInfo = formatProvider as System.Globalization.CultureInfo; 
		
			var separator = cultureInfo.TextInfo.ListSeparator;
			var numSeparator = cultureInfo.NumberFormat.NumberDecimalSeparator;
			string formattedString;
			switch (format)
			{
				case "C":
					formattedString = $"X: {X}{separator} Y:{Y}";
					break;
				case "H":
					formattedString = $"X: {X} - Y:{Y}";
					break;
				case "F":
					formattedString = $"X: {X} --++-- Y:{Y}";
					break;
				default:
					formattedString = $"X: {X}{separator} Y:{Y}";
					break;
			}
			return formattedString;
		}

		#region Constructors
		public RayPoint() {

		}

		public RayPoint(int x, int y) {
			_x = x;
			_y = y;
		}
		#endregion
		#region Properties


		private int _x;

		public int X
		{
			get { return _x; }
			set { _x = value; }
		}

		private int _y;

		public int Y
		{
			get { return _y; }
			set { _y = value; }
		}

		#endregion
	}
}

        */

private void doesCharExist(object sender, RoutedEventArgs e)
{
    // determine if a char exists within string
    char c3 = 'm';
    char resultChar;

    string letters = "abc-def-ghi-jkl-mno-pqr-stu-vwx-yz";

    if (letters.Contains(c3))
    {
        var index = letters.IndexOf(c3);
        resultChar = letters[index];
    }
}
private void isItPunctuation(object sender, RoutedEventArgs e)
{
    Char c1 = '.';
    // use the Char methods to test for Unicode categories.

    if (Char.IsPunctuation(c1))
    {
        // determine if this char is considered a punctuation
        // by the Unicode Standards.
        return "Is punctuation";
    }
    else
    {
        return "Is not punctuation";
    }
}

private void isItADigit(object sender, TextCompositionEventArgs e)
{
    Char currentChar = e.Text[0];

    if (Char.IsDigit(currentChar))
    {
        return true;
    }
}

/*TRY PARSE

private List<string> _inputStrings = new List<string> { "123", "-45", "1,543", "(46)", "123.5", "", "hi" };

		private void ButtonA_Click(object sender, RoutedEventArgs e) {

			// The TryParse method is like the Parse method, 
			// except the TryParse method does not throw an exception 
			// if the conversion fails. 
			// It eliminates the need to use exception handling to test for a FormatException

			int intResult;

			foreach (var input in _inputStrings)
			{
				if (Int32.TryParse(input, System.Globalization.NumberStyles.Any, null, out intResult))
				{
					OutputTextBox.Text += $"{input}: converted to {intResult}\r\n";
				}
				else

				{
					OutputTextBox.Text += $"Cannot parse {input}: to Int32\r\n";
				}
			}
		}

		private void ButtonB_Click(object sender, RoutedEventArgs e) {
			double doubleResult;

			foreach (var input in _inputStrings)
			{
				if (Double.TryParse(input, System.Globalization.NumberStyles.Any, null, out doubleResult))
				{
					OutputTextBox.Text += $"{input}: converted to {doubleResult}\r\n";
				}
				else

				{
					OutputTextBox.Text += $"Cannot parse {input}: to Double\r\n";
				}
			}
		}

		private void ButtonC_Click(object sender, RoutedEventArgs e) {
			var _inputStrings = new List<string> { "5/5/1925", "4/5", "July 21, 2002", "46", "January", "4:32:10", "4-4-44" };
			DateTime dateResult;
			foreach (var input in _inputStrings)
			{
				if (DateTime.TryParse(input,  null, System.Globalization.DateTimeStyles.AllowInnerWhite, out dateResult))
				{
					OutputTextBox.Text += $"{input}: converted to {dateResult}\r\n";
				}
				else

				{
					OutputTextBox.Text += $"Cannot parse {input}: to DateTime\r\n";
				}
			}
		} 
        */

        /*CULTURE INFO TRANSLATION
        		private CultureInfo _ciUS = new CultureInfo("en-US");
		private CultureInfo _ciDE = new CultureInfo("de-DE");
		private CultureInfo _ciBN = new CultureInfo("bn-IN");
		private CultureInfo _ciCN = new CultureInfo("zh-CN");


		private void ButtonA_Click(object sender, RoutedEventArgs e) {
			decimal amount = 36450.89M;
			OutputTextBox1.Text += $"{_ciUS.EnglishName}:\t\t{amount.ToString("C", _ciUS)}\r\n";
			OutputTextBox1.Text += $"{_ciDE.EnglishName}:\t\t{amount.ToString("C", _ciDE)}\r\n";
			OutputTextBox1.Text += $"{_ciBN.EnglishName}:\t\t\t{amount.ToString("C", _ciBN)}\r\n";
			OutputTextBox1.Text += $"{_ciCN.EnglishName}:\t\t{amount.ToString("C", _ciCN)}\r\n";
		}

		private void ButtonB_Click(object sender, RoutedEventArgs e) {
			DateTime saleDate = DateTime.Parse("7/21/2002 13:15:58", _ciUS);

			OutputTextBox2.Text += $"{_ciUS.EnglishName}:\t{saleDate.ToString("D", _ciUS)}\r\n";
			OutputTextBox2.Text += $"{_ciDE.EnglishName}:\t{saleDate.ToString("D", _ciDE)}\r\n";
			OutputTextBox2.Text += $"{_ciBN.EnglishName}:\t\t{saleDate.ToString("D", _ciBN)}\r\n";
			OutputTextBox2.Text += $"{_ciCN.EnglishName}:\t{saleDate.ToString("D", _ciCN)}\r\n";

			OutputTextBox2.Text += $"--------------\r\n";

			OutputTextBox2.Text += $"{_ciUS.EnglishName}:\t{saleDate.ToString("d", _ciUS)}\r\n";
			OutputTextBox2.Text += $"{_ciDE.EnglishName}:\t{saleDate.ToString("d", _ciDE)}\r\n";
			OutputTextBox2.Text += $"{_ciBN.EnglishName}:\t\t{saleDate.ToString("d", _ciBN)}\r\n";
			OutputTextBox2.Text += $"{_ciCN.EnglishName}:\t{saleDate.ToString("d", _ciCN)}\r\n";

			OutputTextBox2.Text += $"--------------\r\n";
			OutputTextBox2.Text += $"{_ciUS.EnglishName}:\t{saleDate.ToString("T", _ciUS)}\r\n";
			OutputTextBox2.Text += $"{_ciDE.EnglishName}:\t{saleDate.ToString("T", _ciDE)}\r\n";
			OutputTextBox2.Text += $"{_ciBN.EnglishName}:\t\t{saleDate.ToString("T", _ciBN)}\r\n";
			OutputTextBox2.Text += $"{_ciCN.EnglishName}:\t{saleDate.ToString("T", _ciCN)}\r\n";
		}
        */

        /*CULTURE INFO INVARIANT

        		private CultureInfo _cultureUS = new CultureInfo("en-US");
		private CultureInfo _cultureDE = new CultureInfo("de-DE");
		private CultureInfo _cultureInvariant = new CultureInfo("");
		private Decimal _saleAmountUS, _saleAmountDE;
		private string _amountAsUsCurrency1, _amountAsDeCurrency1, _amountAsInvariantCurrency1;
		private string _amountAsUsCurrency2, _amountAsDeCurrency2, _amountAsInvariantCurrency2;

		private void ButtonA_Click(object sender, RoutedEventArgs e) {
			try
			{
				ParseDataUS();
				OutputTextBox1.Text += $"US:\t\t{_amountAsUsCurrency1}\r\n";
				OutputTextBox1.Text += $"DE:\t\t{_amountAsDeCurrency1}\r\n";
				OutputTextBox1.Text += $"Invariant:\t{_amountAsInvariantCurrency1}\r\n";
			} catch (Exception)
			{
				throw;
			}
		}

	

		private void ButtonB_Click(object sender, RoutedEventArgs e) {
			try
			{
				ParseDataDE();

				OutputTextBox2.Text += $"US:\t\t{_amountAsUsCurrency2}\r\n";
				OutputTextBox2.Text += $"DE:\t\t{_amountAsDeCurrency2}\r\n";
				OutputTextBox2.Text += $"Invariant:\t{_amountAsInvariantCurrency2}\r\n";
			} catch (Exception)
			{
				throw;
			}
		}

		private void ParseDataUS() {
			_saleAmountUS = Decimal.Parse(InputTextBox.Text, NumberStyles.Any, _cultureUS);
			_amountAsUsCurrency1 = _saleAmountUS.ToString("C", _cultureUS);
			_amountAsDeCurrency1 = _saleAmountUS.ToString("C", _cultureDE);
			_amountAsInvariantCurrency1 = _saleAmountUS.ToString("C", _cultureInvariant); ;
		}

		private void ParseDataDE() {
			_saleAmountDE = Decimal.Parse(InputTextBoxDE.Text, NumberStyles.Any, _cultureDE);
			_amountAsUsCurrency2 = _saleAmountDE.ToString("C", _cultureUS);
			_amountAsDeCurrency2 = _saleAmountDE.ToString("C", _cultureDE);
			_amountAsInvariantCurrency2 = _saleAmountDE.ToString("C", _cultureInvariant);
		}

		private void ButtonC_Click(object sender, RoutedEventArgs e) {
			// use invariant versions for comparison where culture isn't important
		
			ParseDataUS();
			ParseDataDE();
			if (_amountAsInvariantCurrency1 == _amountAsInvariantCurrency2)
			{
				OutputTextBox3.Text += $"{_amountAsInvariantCurrency1} == {_amountAsInvariantCurrency2}\r\n";
			}
			else

			{
				OutputTextBox3.Text += $"{_amountAsInvariantCurrency1} != {_amountAsInvariantCurrency2}\r\n";
			}
		}
		private void ButtonD_Click(object sender, RoutedEventArgs e) {
			InputTextBox.Text = "4,615.44";
			InputTextBoxDE.Text = "4.615,44";
		}
        */
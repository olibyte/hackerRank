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
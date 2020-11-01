import java.io.*;
import java.math.*;
import java.security.*;
import java.text.*;
import java.util.*;
import java.util.concurrent.*;
import java.util.function.*;
import java.util.regex.*;
import java.util.stream.*;
import static java.util.stream.Collectors.joining;
import static java.util.stream.Collectors.toList;



class Result {

    /*
     * Complete the 'getTotalGoals' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. STRING team
     *  2. INTEGER year
     */
     string urlHomeTeam = "https://jsonmock.hackerrank.com/api/football_matches?year=<year>&team1=<team>&page=<page>";
     string urlAwayTeam = "https://jsonmock.hackerrank.com/api/football_matches?year=<year>&team2=<team>&page=<page>";
     string urlHome1 = "https://jsonmock.hackerrank.com/api/football_matches?year=";
     string urlHome2 = "&team1=";
     string urlHome3 = "&page=";

    public static int getTotalGoals(String team, int year) {
        int goals = urlHome1+year+
    }

}

public class Solution {
    public static void main(String[] args) throws IOException {
        BufferedReader bufferedReader = new BufferedReader(new InputStreamReader(System.in));
        BufferedWriter bufferedWriter = new BufferedWriter(new FileWriter(System.getenv("OUTPUT_PATH")));

        String team = bufferedReader.readLine();

        int year = Integer.parseInt(bufferedReader.readLine().trim());

        int result = Result.getTotalGoals(team, year);

        bufferedWriter.write(String.valueOf(result));
        bufferedWriter.newLine();

        bufferedReader.close();
        bufferedWriter.close();
    }
}

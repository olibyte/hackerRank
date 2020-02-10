import java.util.*;

class Player {
	String name;
	int score;

	Player(String name, int score) {
		this.name = name;
		this.score = score;
	}
}

class Checker implements Comparator<Player> {
  	// complete this method
	public int compare(Player a, Player b) {
    int result = a.score - b.score;
        if (result == 0) {
            result = a.name.compareTo(b.name); //string comparator
            return result < 0 ? -1 : 1;
        }
        return result < 0 ? 1 : -1;
    }
    // //simpler version
    // public int compare(Player a, Player b) {
    //     if(a.score == b.score)
    //     {
    //         return a.name.compareTo(b.name);
    //     }
    //     return b.score - a.score;
    // }
}


public class Solution {

    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        int n = scan.nextInt();

        Player[] player = new Player[n];
        Checker checker = new Checker();
        
        for(int i = 0; i < n; i++){
            player[i] = new Player(scan.next(), scan.nextInt());
        }
        scan.close();

        Arrays.sort(player, checker);
        for(int i = 0; i < player.length; i++){
            System.out.printf("%s %s\n", player[i].name, player[i].score);
        }
    }
}
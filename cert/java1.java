import java.util.*;
import java.util.Scanner;
class Parser {
    boolean isBalanced(String s) {
        //opening brackets
        Set<String> openers = new HashSet<>(Arrays.asList("{", "("));
        //store these in a hashmap with their closing brackets
        Map<String, String> bracketsMap = new HashMap<>();
        bracketsMap.put("}", "{");
        bracketsMap.put(")", "(");
        
        Stack<String> stack = new Stack<>();
        //iterate through s - log our openers in the stack - when iterating through, if the next closing bracket maps to its opener we pop the opener from the stack
        for (int i = 0; i < s.length(); i++) {
            String bracket = String.valueOf(s.charAt(i));
            //if it's an opener, push this onto the stack
            if (openers.contains(bracket)) {
                stack.push(bracket);
            }//otherwise it's a closing bracket - refer to it as a key in the hashmap 
            else if (bracketsMap.containsKey(bracket)) {
                //if there's no opener currently in the stack for this closer, string is not balanced
                if (stack.isEmpty()) {
                    return false;
                }
                //otherwise there's an opener in the stack - get the correct closer from the hashmap and pop its respective opener  from the stack
                String expected = bracketsMap.get(bracket);
                String opener = stack.pop();
                //if it's not the opener we're expecting
                if (!expected.equals(opener)) {
                    return false;
                }
            }
        }//if stack is empty all closers have popped their opener from the stack. otherwise, there's an excess opener in the stack and we return false
        return stack.isEmpty();

    }
}
// Write your code here. DO NOT use an access modifier in your class declaration.
class Solution {
	
	public static void main(String[] args) {
		Parser parser = new Parser();
        
		Scanner in = new Scanner(System.in);

		while (in.hasNext()) {
			System.out.println(parser.isBalanced(in.next()));
		}
        
		in.close();
	}
}

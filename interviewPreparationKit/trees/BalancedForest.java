import java.io.*;
import java.math.*;
import java.security.*;
import java.text.*;
import java.util.*;
import java.util.concurrent.*;
import java.util.regex.*;
//5 out of 8 tests passed
public class BalancedForest {

    private int[] values;
    private int[][] edges;
    private long[] sums;
    private int[] parents;
    
    public BalancedForest( int[] values , int[][] edges ) {
        this.values = values;
        this.edges = edges;
        this.sums = new long[edges.length];
        this.parents = new int[values.length];
        this.fillSumsAndGetSum();
    }
    

    private long fillSumsAndGetSum() {
        return getChainSum(1, 0, 1 );
    }
    

    private long getChainSum(int edgeIndex,int parentNodeIndex,int nodeIndex) {
        long sum = 0;
        this.parents[nodeIndex-1] = parentNodeIndex-1;
        for( int i = 0; i < edges.length; ++i ) {
            if ( contains( edges[i] , nodeIndex ) && !contains( edges[i], parentNodeIndex ) ) {
                sums[i] = getChainSum(i,nodeIndex,edges[i][0]==nodeIndex ? edges[i][1] : edges[i][0]);
                sum += sums[i];
                if ( edges[i][1] == nodeIndex ) {
                    int v = edges[i][0];
                    edges[i][0] = edges[i][1];
                    edges[i][1] = v;
                }
            }
        }
        return sum + values[nodeIndex-1];
    }

    public static int balancedForest(int[] values, int[][] edges) {
        BalancedForest bf = new BalancedForest(values, edges);
        long sum = bf.fillSumsAndGetSum();
//        System.out.println( "Sum : " + sum );
//        System.out.println( "Sums : " + LongStream.of( bf.sums ).boxed().collect( Collectors.toList() ) );
//        System.out.println( "Parents : " + IntStream.of( bf.parents ).boxed().collect( Collectors.toList() ) ); 
        
        int result = -1;
        for( int i = 0; i < edges.length; ++i ) {
            long sum1 = sum - bf.sums[i];
            long sum2 = bf.sums[i];
//            System.out.println( String.format( "Dividing by %s->%s : %s , %s", edges[i][0], edges[i][1], sum1, sum2 ) );
            if ( sum1 == sum2 ) {
//                System.out.println( String.format( "    %s = %s" , sum1 , sum2 ) );
                result = getMinValue(result,(int)sum1);
//                System.out.println( String.format( "    Current result: %s" , result ) );
            }else{
//                System.out.println( String.format( "    %s < %s" , sum1 , sum2  ) ); 
                for( int j = i + 1; j < edges.length; ++j ) {
                    Long s1 = null;
                    Long s2 = null;
                    Long s3 = null;
                    if ( bf.isChild( i , j ) ) { 
                        s1 = sum - bf.sums[i];
                        s2 = bf.sums[i] - bf.sums[j];
                        s3 = bf.sums[j];
                    }else if ( !bf.isChild(i, j) && bf.isChild(j, i) ) {
                        s1 = bf.sums[j] - bf.sums[i];
                        s2 = bf.sums[i];
                        s3 = sum - bf.sums[j];
                    }else if ( !bf.isChild(i, j) && !bf.isChild(j, i) ) {
                        s1 = sum - bf.sums[i] - bf.sums[j];
                        s2 = bf.sums[i];
                        s3 = bf.sums[j];
                    }
                    if ( s1 != null ) {
//                        System.out.println( String.format( "    Dividing by %s->%s: %s,%s,%s" ,edges[j][0],edges[j][1],s1,s2,s3 ) );
                        result = getMinValue(result,getAddValue(s1, s2, s3 ));
//                        System.out.println( String.format( "    Current result: %s" , result ) );
                    }
                }
            }
        }        
        return result;
    }
    
    private boolean isChild(int i, int j) {
        int parentNodeIndexToFind = edges[i][1] -1;
        int currentNodeIndex = edges[j][0] - 1;
        if ( currentNodeIndex == parentNodeIndexToFind ) {
            return true;
        }
        while( true ) {
            int parentIndex = parents[currentNodeIndex];
            if ( parentIndex == -1 ) {
                return false;
            }else if ( parentIndex == parentNodeIndexToFind ) {
                return true;
            }else {
                currentNodeIndex = parentIndex;
            }
        }
    }


    private static int getAddValue( long sum1 , long sum2 , long sum3 ) {
        if ( sum1 == sum2 && sum1 > sum3 ) {
            return (int) (sum1 - sum3);
        }else if ( sum1 == sum3 && sum1 > sum2 ) {
            return (int) (sum1 - sum2);
        }else if ( sum2 == sum3 && sum2 > sum1 ) {
            return (int) (sum2 - sum1);
        }else {
            return -1;
        }
    }
    
    private static int getMinValue( int oldValue , int newValue ) {
        return oldValue < 0 || newValue > 0 && oldValue > 0 && newValue < oldValue ?
                newValue: oldValue;
    }

    private static boolean contains(int[] edge, int i) {
        return edge[0] == i || edge[1] == i;
    }

    private static final Scanner scanner = new Scanner(System.in);

    public static void main(String[] args) throws IOException {
        BufferedWriter bufferedWriter = new BufferedWriter(new FileWriter(System.getenv("OUTPUT_PATH")));

        int q = scanner.nextInt();
        scanner.skip("(\r\n|[\n\r\u2028\u2029\u0085])?");

        for (int qItr = 0; qItr < q; qItr++) {
            int n = scanner.nextInt();
            scanner.skip("(\r\n|[\n\r\u2028\u2029\u0085])?");

            int[] c = new int[n];

            String[] cItems = scanner.nextLine().split(" ");
            scanner.skip("(\r\n|[\n\r\u2028\u2029\u0085])?");

            for (int i = 0; i < n; i++) {
                int cItem = Integer.parseInt(cItems[i]);
                c[i] = cItem;
            }

            int[][] edges = new int[n - 1][2];

            for (int i = 0; i < n - 1; i++) {
                String[] edgesRowItems = scanner.nextLine().split(" ");
                scanner.skip("(\r\n|[\n\r\u2028\u2029\u0085])?");

                for (int j = 0; j < 2; j++) {
                    int edgesItem = Integer.parseInt(edgesRowItems[j]);
                    edges[i][j] = edgesItem;
                }
            }

            int result = balancedForest(c, edges);

            bufferedWriter.write(String.valueOf(result));
            bufferedWriter.newLine();
        }

        bufferedWriter.close();

        scanner.close();
    }
}

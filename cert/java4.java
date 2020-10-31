class SampleDemo implements Runnable {
    private Thread t;
    private String threadName;
    
    SampleDemo (String threadName) {
        this.threadName = threadName;
    }
    
    public void run()
    {
        // while (true)
        for (int i = 0; i < 10; i++)
            System.out.print(threadName);
    }
    
    public void start()
    {
        if (t == null)
        {
            t = new Thread (this, threadName);
            t.start();
        }
    }
}
public class TestThread {
    public static void main(String args[]) {
        SampleDemo A = new SampleDemo("A");
        SampleDemo B = new SampleDemo("B");
        
        B.start();
        A.start();
    }
}